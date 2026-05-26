using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Npgsql;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;

namespace KursProject_Boyarkin_OOP
{
    /// <summary>
    /// Статический класс для взаимодействия с базой данных PostgreSQL.
    /// Инкапсулирует все операции CRUD, управление схемой (создание, удаление БД и таблиц),
    /// резервное копирование через <c>pg_dump</c>/<c>psql</c> и экспорт данных в PDF-отчёт.
    /// Параметры подключения читаются из файла <c>App.config</c>.
    /// </summary>
    internal class Database
    {
        // ================= ПАРАМЕТРЫ ПОДКЛЮЧЕНИЯ =================

        /// <summary>
        /// Адрес сервера PostgreSQL (по умолчанию <c>localhost</c>).
        /// </summary>
        private static string PgHost =>
            ConfigurationManager.AppSettings["PgHost"] ?? "localhost";

        /// <summary>
        /// Порт сервера PostgreSQL (по умолчанию <c>5432</c>).
        /// </summary>
        private static int PgPort =>
            int.TryParse(ConfigurationManager.AppSettings["PgPort"], out int p) ? p : 5432;

        /// <summary>
        /// Имя пользователя для подключения к PostgreSQL (по умолчанию <c>postgres</c>).
        /// </summary>
        private static string PgUser =>
            ConfigurationManager.AppSettings["PgUser"] ?? "postgres";

        /// <summary>
        /// Пароль пользователя PostgreSQL, читаемый из конфигурации.
        /// </summary>
        private static string PgPassword =>
            ConfigurationManager.AppSettings["PgPassword"] ?? "password";

        /// <summary>
        /// Путь к каталогу <c>bin</c> установленного PostgreSQL, содержащему утилиты
        /// <c>psql.exe</c> и <c>pg_dump.exe</c>.
        /// Определяется автоматически методом <see cref="FindPgBinPath"/>.
        /// </summary>
        private static string PgBinPath => FindPgBinPath();

        /// <summary>
        /// Автоматически определяет каталог <c>bin</c> установленного PostgreSQL.
        /// Использует три стратегии поиска: конфигурация, сканирование Program Files,
        /// переменная окружения PATH.
        /// </summary>
        /// <returns>
        /// Путь к каталогу <c>bin</c> с завершающим обратным слешем,
        /// или значение из конфигурации, если путь не удалось определить.
        /// </returns>
        private static string FindPgBinPath()
        {
            // Попытка 1: явно указанный путь в App.config — используем, только если psql.exe там есть
            string configured = ConfigurationManager.AppSettings["PgBinPath"];
            if (!string.IsNullOrEmpty(configured) &&
                File.Exists(Path.Combine(configured, "psql.exe")))
                return configured;

            // Попытка 2: автопоиск по всем установленным версиям в Program Files (от новых к старым)
            string pgBase = @"C:\Program Files\PostgreSQL\";
            if (Directory.Exists(pgBase))
            {
                string[] dirs = Directory.GetDirectories(pgBase);
                Array.Sort(dirs);
                Array.Reverse(dirs);
                foreach (string dir in dirs)
                {
                    string bin = Path.Combine(dir, "bin");
                    if (File.Exists(Path.Combine(bin, "psql.exe")))
                        return bin + @"\";
                }
            }

            // Попытка 3: psql.exe присутствует в одном из каталогов PATH
            foreach (string pathDir in (Environment.GetEnvironmentVariable("PATH") ?? "").Split(';'))
            {
                try
                {
                    if (File.Exists(Path.Combine(pathDir.Trim(), "psql.exe")))
                        return pathDir.Trim() + @"\";
                }
                catch { }
            }

            // Возвращаем значение из конфигурации как запасной вариант
            return configured ?? @"C:\Program Files\PostgreSQL\";
        }

        /// <summary>
        /// Имя текущей активной базы данных.
        /// Изменяется при создании, открытии или удалении БД.
        /// Начальное значение берётся из ключа <c>DefaultDatabase</c> в <c>App.config</c>.
        /// </summary>
        public static string CurrentDatabase =
            ConfigurationManager.AppSettings["DefaultDatabase"] ?? "bus_park";

        /// <summary>
        /// Строка подключения к текущей активной базе данных.
        /// </summary>
        private static string ConnectionString =>
            $"Host={PgHost};Port={PgPort};Database={CurrentDatabase};Username={PgUser};Password={PgPassword};";

        /// <summary>
        /// Строка подключения к служебной базе данных <c>postgres</c>.
        /// Используется для создания и удаления пользовательских БД.
        /// </summary>
        private static string MasterConnectionString =>
            $"Host={PgHost};Port={PgPort};Database=postgres;Username={PgUser};Password={PgPassword};";

        // ================= ПРОВЕРКА СУЩЕСТВОВАНИЯ БД =================

        /// <summary>
        /// Проверяет наличие текущей базы данных на сервере и создаёт её, если она отсутствует.
        /// </summary>
        public static void EnsureDatabaseExists()
        {
            try
            {
                using (var conn = new NpgsqlConnection(MasterConnectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(
                        "SELECT 1 FROM pg_database WHERE datname = @db;", conn))
                    {
                        cmd.Parameters.AddWithValue("db", CurrentDatabase);
                        var exists = cmd.ExecuteScalar();

                        // БД не найдена — создаём её
                        if (exists == null)
                            new NpgsqlCommand($"CREATE DATABASE \"{CurrentDatabase}\";", conn)
                                .ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                new Exceptions("Ошибка проверки БД: " + ex.Message);
            }
        }

        // ================= ИНИЦИАЛИЗАЦИЯ =================

        /// <summary>
        /// Создаёт таблицу <c>buses</c> в текущей базе данных, если она ещё не существует.
        /// Операция идемпотентна благодаря конструкции <c>CREATE TABLE IF NOT EXISTS</c>.
        /// </summary>
        public static void InitializeDatabase()
        {
            try
            {
                using (var conn = new NpgsqlConnection(ConnectionString))
                {
                    conn.Open();
                    string sql = @"CREATE TABLE IF NOT EXISTS buses (
                        id           SERIAL PRIMARY KEY,
                        plate_number VARCHAR(20)    NOT NULL,
                        driver       VARCHAR(100)   NOT NULL,
                        route        VARCHAR(100)   NOT NULL,
                        income       NUMERIC(12,2)  NOT NULL,
                        expense      NUMERIC(12,2)  NOT NULL,
                        mileage      INT            NOT NULL
                    );";
                    using (var cmd = new NpgsqlCommand(sql, conn))
                        cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                new Exceptions("Ошибка инициализации БД: " + ex.Message);
            }
        }

        // ================= ЗАГРУЗКА =================

        /// <summary>
        /// Загружает все записи из таблицы <c>buses</c> в статический список <see cref="BusPark.Buses"/>.
        /// Перед загрузкой список полностью очищается.
        /// </summary>
        public static void LoadFromDatabase()
        {
            try
            {
                BusPark.Buses.Clear();
                using (var conn = new NpgsqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("SELECT * FROM buses ORDER BY id;", conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var bus = new BusPark(
                                reader["plate_number"].ToString(),
                                reader["driver"].ToString(),
                                reader["route"].ToString(),
                                Convert.ToDecimal(reader["income"]),
                                Convert.ToDecimal(reader["expense"]),
                                Convert.ToInt32(reader["mileage"])
                            );
                            bus.Id = Convert.ToInt32(reader["id"]);
                            BusPark.Buses.Add(bus);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new Exceptions("Ошибка загрузки данных: " + ex.Message);
            }
        }

        // ================= СИНХРОНИЗАЦИЯ СПИСКА С БД =================

        /// <summary>
        /// Полностью перезаписывает таблицу <c>buses</c> данными из <see cref="BusPark.Buses"/>.
        /// Выполняется в транзакции: при ошибке все изменения откатываются.
        /// Используется перед созданием дампа через <c>pg_dump</c>.
        /// </summary>
        public static void SaveToDatabase()
        {
            try
            {
                using (var conn = new NpgsqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Очищаем таблицу и сбрасываем счётчик первичного ключа
                            new NpgsqlCommand("TRUNCATE TABLE buses RESTART IDENTITY;", conn, transaction)
                                .ExecuteNonQuery();

                            // Вставляем все записи из текущего списка
                            foreach (var bus in BusPark.Buses)
                            {
                                string sql = "INSERT INTO buses (plate_number, driver, route, income, expense, mileage) " +
                                             "VALUES (@p, @d, @r, @i, @e, @m);";
                                using (var cmd = new NpgsqlCommand(sql, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("p", bus.PlateNumber);
                                    cmd.Parameters.AddWithValue("d", bus.Driver);
                                    cmd.Parameters.AddWithValue("r", bus.Route);
                                    cmd.Parameters.AddWithValue("i", bus.Income);
                                    cmd.Parameters.AddWithValue("e", bus.Expense);
                                    cmd.Parameters.AddWithValue("m", bus.Mileage);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            transaction.Commit();
                        }
                        catch
                        {
                            // Откатываем транзакцию при любой ошибке
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new Exceptions("Ошибка сохранения данных: " + ex.Message);
            }
        }

        // ================= INSERT =================

        /// <summary>
        /// Добавляет одну запись о транспортном средстве в таблицу <c>buses</c>.
        /// После успешной вставки присваивает объекту <paramref name="bus"/> идентификатор,
        /// возвращённый сервером через <c>RETURNING id</c>.
        /// </summary>
        /// <param name="bus">Объект транспортного средства для сохранения в БД.</param>
        public static void InsertBus(BusPark bus)
        {
            try
            {
                using (var conn = new NpgsqlConnection(ConnectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO buses (plate_number, driver, route, income, expense, mileage) " +
                                 "VALUES (@p, @d, @r, @i, @e, @m) RETURNING id;";
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("p", bus.PlateNumber);
                        cmd.Parameters.AddWithValue("d", bus.Driver);
                        cmd.Parameters.AddWithValue("r", bus.Route);
                        cmd.Parameters.AddWithValue("i", bus.Income);
                        cmd.Parameters.AddWithValue("e", bus.Expense);
                        cmd.Parameters.AddWithValue("m", bus.Mileage);

                        // Присваиваем объекту идентификатор, сгенерированный базой данных
                        bus.Id = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                new Exceptions("Ошибка добавления записи: " + ex.Message);
            }
        }

        // ================= UPDATE =================

        /// <summary>
        /// Обновляет все поля записи в таблице <c>buses</c> по значению <see cref="BusPark.Id"/>.
        /// </summary>
        /// <param name="bus">Объект с актуальными данными; идентификатор должен быть установлен.</param>
        public static void UpdateBus(BusPark bus)
        {
            try
            {
                using (var conn = new NpgsqlConnection(ConnectionString))
                {
                    conn.Open();
                    string sql = "UPDATE buses SET plate_number=@p, driver=@d, route=@r, " +
                                 "income=@i, expense=@e, mileage=@m WHERE id=@id;";
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("p",  bus.PlateNumber);
                        cmd.Parameters.AddWithValue("d",  bus.Driver);
                        cmd.Parameters.AddWithValue("r",  bus.Route);
                        cmd.Parameters.AddWithValue("i",  bus.Income);
                        cmd.Parameters.AddWithValue("e",  bus.Expense);
                        cmd.Parameters.AddWithValue("m",  bus.Mileage);
                        cmd.Parameters.AddWithValue("id", bus.Id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                new Exceptions("Ошибка обновления записи: " + ex.Message);
            }
        }

        // ================= DELETE =================

        /// <summary>
        /// Удаляет запись из таблицы <c>buses</c> по указанному идентификатору.
        /// </summary>
        /// <param name="id">Первичный ключ удаляемой записи.</param>
        public static void DeleteBus(int id)
        {
            try
            {
                using (var conn = new NpgsqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("DELETE FROM buses WHERE id=@id;", conn))
                    {
                        cmd.Parameters.AddWithValue("id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                new Exceptions("Ошибка удаления записи: " + ex.Message);
            }
        }

        // ================= ОЧИСТКА =================

        /// <summary>
        /// Удаляет все записи из таблицы <c>buses</c>, не затрагивая структуру таблицы.
        /// </summary>
        public static void ClearDatabase()
        {
            try
            {
                using (var conn = new NpgsqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("DELETE FROM buses;", conn))
                        cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                new Exceptions("Ошибка очистки БД: " + ex.Message);
            }
        }

        // ================= СОЗДАТЬ БД =================

        /// <summary>
        /// Создаёт новую базу данных PostgreSQL с указанным именем,
        /// переключается на неё как на активную и инициализирует структуру таблиц.
        /// </summary>
        /// <param name="dbName">Имя создаваемой базы данных.</param>
        public static void CreateDatabase(string dbName)
        {
            try
            {
                // Создаём БД через подключение к служебной базе postgres
                using (var conn = new NpgsqlConnection(MasterConnectionString))
                {
                    conn.Open();
                    new NpgsqlCommand($"CREATE DATABASE \"{dbName}\";", conn).ExecuteNonQuery();
                }

                // Переключаемся и создаём таблицу buses
                CurrentDatabase = dbName;
                InitializeDatabase();

                MessageBox.Show($"База данных '{dbName}' создана.", "Готово",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                new Exceptions("Ошибка создания БД: " + ex.Message);
            }
        }

        // ================= УДАЛИТЬ БД =================

        /// <summary>
        /// Удаляет указанную базу данных PostgreSQL.
        /// Перед удалением принудительно завершает все активные подключения к ней.
        /// После удаления переключается на базу данных по умолчанию — <c>bus_park</c>.
        /// </summary>
        /// <param name="dbName">Имя удаляемой базы данных.</param>
        public static void DeleteDatabase(string dbName)
        {
            try
            {
                using (var conn = new NpgsqlConnection(MasterConnectionString))
                {
                    conn.Open();

                    // Принудительно завершаем все сессии, кроме текущей, перед удалением
                    new NpgsqlCommand($@"
                        SELECT pg_terminate_backend(pid)
                        FROM pg_stat_activity
                        WHERE datname = '{dbName}' AND pid <> pg_backend_pid();",
                        conn).ExecuteNonQuery();

                    new NpgsqlCommand($"DROP DATABASE IF EXISTS \"{dbName}\";", conn)
                        .ExecuteNonQuery();
                }

                CurrentDatabase = "bus_park";

                MessageBox.Show($"База данных '{dbName}' удалена.", "Готово",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                new Exceptions("Ошибка удаления БД: " + ex.Message);
            }
        }

        // ================= СОХРАНИТЬ КАК .SQL =================

        /// <summary>
        /// Экспортирует текущую базу данных в файл <c>.sql</c> с помощью утилиты <c>pg_dump</c>.
        /// Перед экспортом синхронизирует таблицу с актуальным состоянием списка <see cref="BusPark.Buses"/>.
        /// </summary>
        /// <param name="outputPath">Полный путь к файлу назначения.</param>
        public static void SaveDatabase(string outputPath)
        {
            try
            {
                string pgDump = Path.Combine(PgBinPath, "pg_dump.exe");
                if (!File.Exists(pgDump))
                {
                    new Exceptions($"pg_dump.exe не найден.\n\nПроверьте, что PostgreSQL установлен, " +
                        $"или укажите правильный путь в App.config → PgBinPath.\n\nИскали в: {pgDump}");
                    return;
                }

                // Синхронизируем список с БД перед созданием дампа
                SaveToDatabase();

                var psi = new ProcessStartInfo
                {
                    FileName               = pgDump,
                    Arguments              = $"-U {PgUser} -d \"{CurrentDatabase}\" -F p -f \"{outputPath}\"",
                    UseShellExecute        = false,
                    RedirectStandardError  = true,
                    CreateNoWindow         = true,
                    Environment            = { ["PGPASSWORD"] = PgPassword }
                };

                using (var process = Process.Start(psi))
                {
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();
                    if (process.ExitCode != 0)
                    {
                        new Exceptions("Ошибка pg_dump: " + error);
                        return;
                    }
                }

                MessageBox.Show("БД сохранена в файл: " + outputPath, "Готово",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                new Exceptions("Ошибка сохранения БД: " + ex.Message);
            }
        }

        // ================= ОТКРЫТЬ .SQL =================

        /// <summary>
        /// Восстанавливает базу данных из файла <c>.sql</c> с помощью утилиты <c>psql</c>.
        /// Если база данных с таким именем уже существует, восстановление пропускается —
        /// выполняется только подключение и загрузка данных.
        /// </summary>
        /// <param name="filePath">Полный путь к файлу дампа <c>.sql</c>.</param>
        /// <returns>
        /// <c>true</c> при успешном подключении или восстановлении;
        /// <c>false</c> при возникновении ошибки.
        /// </returns>
        public static bool OpenSqlFile(string filePath)
        {
            try
            {
                string dbName = Path.GetFileNameWithoutExtension(filePath);

                // Проверяем существование БД с таким именем в PostgreSQL
                bool dbExists;
                using (var conn = new NpgsqlConnection(MasterConnectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(
                        "SELECT 1 FROM pg_database WHERE datname = @db;", conn))
                    {
                        cmd.Parameters.AddWithValue("db", dbName);
                        dbExists = cmd.ExecuteScalar() != null;
                    }

                    if (!dbExists)
                        new NpgsqlCommand($"CREATE DATABASE \"{dbName}\";", conn).ExecuteNonQuery();
                }

                // Восстанавливаем данные из дампа только для новых баз данных
                if (!dbExists)
                {
                    string psql = Path.Combine(PgBinPath, "psql.exe");
                    if (!File.Exists(psql))
                    {
                        new Exceptions($"psql.exe не найден.\n\nПроверьте, что PostgreSQL установлен, " +
                            $"или укажите правильный путь в App.config → PgBinPath.\n\nИскали в: {psql}");
                        return false;
                    }

                    var psi = new ProcessStartInfo
                    {
                        FileName               = psql,
                        Arguments              = $"-U {PgUser} -d \"{dbName}\" -f \"{filePath}\"",
                        UseShellExecute        = false,
                        RedirectStandardError  = true,
                        CreateNoWindow         = true,
                        Environment            = { ["PGPASSWORD"] = PgPassword }
                    };

                    using (var process = Process.Start(psi))
                    {
                        string error = process.StandardError.ReadToEnd();
                        process.WaitForExit();
                        if (process.ExitCode != 0)
                        {
                            new Exceptions("Ошибка восстановления БД: " + error);
                            return false;
                        }
                    }
                }

                // Переключаемся на БД, гарантируем наличие таблицы и загружаем данные
                CurrentDatabase = dbName;
                InitializeDatabase();
                LoadFromDatabase();

                MessageBox.Show($"База данных '{dbName}' открыта.", "Готово",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                new Exceptions("Ошибка открытия файла: " + ex.Message);
                return false;
            }
        }

        // ================= ОТЧЁТ =================

        /// <summary>
        /// Экспортирует текущее содержимое <see cref="BusPark.Buses"/> в PDF-документ.
        /// Документ оформляется на листе A4 в альбомной ориентации и содержит:
        /// заголовок с именем БД, дату формирования и таблицу с данными ТС.
        /// </summary>
        /// <param name="outputPath">Полный путь к файлу PDF назначения.</param>
        public static void SaveTableToPdf(string outputPath)
        {
            try
            {
                var doc = new Document();
                doc.Info.Title = "Отчёт — Автобусный парк";

                var section = doc.AddSection();
                section.PageSetup.Orientation = MigraDoc.DocumentObjectModel.Orientation.Landscape;
                section.PageSetup.TopMargin    = "2cm";
                section.PageSetup.BottomMargin = "2cm";
                section.PageSetup.LeftMargin   = "2cm";
                section.PageSetup.RightMargin  = "2cm";

                // Заголовок документа
                var title = section.AddParagraph(
                    $"Автобусный парк — отчёт ({CurrentDatabase})");
                title.Format.Font.Name  = "Arial";
                title.Format.Font.Size  = 14;
                title.Format.Font.Bold  = true;
                title.Format.Alignment  = ParagraphAlignment.Center;
                title.Format.SpaceAfter = "0.4cm";

                // Строка с датой формирования отчёта
                var dateLine = section.AddParagraph(
                    $"Дата: {DateTime.Now:dd.MM.yyyy HH:mm}");
                dateLine.Format.Font.Name  = "Arial";
                dateLine.Format.Font.Size  = 9;
                dateLine.Format.Alignment  = ParagraphAlignment.Right;
                dateLine.Format.SpaceAfter = "0.4cm";

                var table = section.AddTable();
                table.Borders.Width = 0.5;
                table.Borders.Color = Colors.Gray;

                // Ширины столбцов (альбомный A4 ≈ 21 cm при отступах по 2 cm)
                table.AddColumn("3.5cm");  // Номер ТС
                table.AddColumn("5.5cm");  // Водитель
                table.AddColumn("2.5cm");  // Маршрут
                table.AddColumn("3cm");    // Доход
                table.AddColumn("3cm");    // Расход
                table.AddColumn("2.5cm"); // Пробег

                string[] headers = {
                    "Номер ТС", "Водитель", "№ Маршрута",
                    "Доход (руб/д)", "Расход (руб/д)", "Пробег (км/д)"
                };

                // Строка заголовков таблицы — повторяется на каждой странице
                var headerRow = table.AddRow();
                headerRow.HeadingFormat    = true;
                headerRow.Format.Font.Bold = true;
                headerRow.Format.Font.Name = "Arial";
                headerRow.Format.Font.Size = 9;
                headerRow.Shading.Color    = Colors.LightGray;
                for (int i = 0; i < headers.Length; i++)
                {
                    headerRow.Cells[i].AddParagraph(headers[i]);
                    headerRow.Cells[i].Format.Alignment  = ParagraphAlignment.Center;
                    headerRow.Cells[i].VerticalAlignment = VerticalAlignment.Center;
                }

                // Строки данных с чередующимся фоном для удобства чтения
                bool alt = false;
                foreach (var bus in BusPark.Buses)
                {
                    var row = table.AddRow();
                    row.Format.Font.Name = "Arial";
                    row.Format.Font.Size = 9;
                    if (alt) row.Shading.Color = Colors.WhiteSmoke;
                    alt = !alt;

                    string[] vals = {
                        bus.PlateNumber,
                        bus.Driver,
                        bus.Route,
                        bus.Income.ToString("F2"),
                        bus.Expense.ToString("F2"),
                        bus.Mileage.ToString()
                    };
                    for (int i = 0; i < vals.Length; i++)
                    {
                        row.Cells[i].AddParagraph(vals[i]);
                        row.Cells[i].Format.Alignment  = ParagraphAlignment.Center;
                        row.Cells[i].VerticalAlignment = VerticalAlignment.Center;
                    }
                }

                var renderer = new PdfDocumentRenderer { Document = doc };
                renderer.RenderDocument();
                renderer.PdfDocument.Save(outputPath);

                MessageBox.Show("Отчёт сохранён: " + outputPath, "Готово",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                new Exceptions("Ошибка создания отчёта: " + ex.Message);
            }
        }
    }
}
