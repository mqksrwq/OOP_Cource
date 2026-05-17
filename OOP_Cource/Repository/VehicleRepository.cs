using Npgsql;
using OOP_Cource.Config;
using OOP_Cource.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OOP_Cource.Repository
{
    /// <summary>
    /// Репозиторий транспорта с хранением данных в PostgreSQL
    /// </summary>
    public class VehicleRepository : IVehicleRepository
    {
        private readonly string _connectionString;

        /// <summary>
        /// Инициализирует репозиторий и создаёт базу данных с таблицей при первом запуске
        /// </summary>
        public VehicleRepository()
        {
            _connectionString = AppConfig.ConnectionString;
            EnsureCreated();
        }

        /// <summary>
        /// Создаёт базу данных vehicles_db и таблицу vehicles, если они не существуют
        /// </summary>
        private void EnsureCreated()
        {
            using var masterConn = new NpgsqlConnection(AppConfig.MasterConnectionString);
            masterConn.Open();

            using var checkCmd = new NpgsqlCommand(
                "SELECT 1 FROM pg_database WHERE datname = 'vehicles_db'", masterConn);
            var dbExists = checkCmd.ExecuteScalar() != null;

            if (!dbExists)
            {
                using var createDbCmd = new NpgsqlCommand("CREATE DATABASE vehicles_db", masterConn);
                createDbCmd.ExecuteNonQuery();
            }

            masterConn.Close();

            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            using var tableCmd = new NpgsqlCommand(@"
                CREATE TABLE IF NOT EXISTS vehicles (
                    id       SERIAL       PRIMARY KEY,
                    number   VARCHAR(20)  NOT NULL,
                    district VARCHAR(100) NOT NULL,
                    model    VARCHAR(100) NOT NULL,
                    capacity INTEGER      NOT NULL,
                    status   VARCHAR(50)  NOT NULL
                )", conn);
            tableCmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Считывает объект Vehicle из текущей строки результата запроса
        /// </summary>
        private static Vehicle ReadVehicle(NpgsqlDataReader reader)
        {
            return new Vehicle
            {
                Id       = reader.GetInt32(0),
                Number   = reader.GetString(1),
                District = reader.GetString(2),
                Model    = reader.GetString(3),
                Capacity = reader.GetInt32(4),
                Status   = reader.GetString(5)
            };
        }

        /// <summary>
        /// Возвращает все записи транспорта из базы данных
        /// </summary>
        public async Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            var vehicles = new List<Vehicle>();
            await using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();
            await using var cmd = new NpgsqlCommand(
                "SELECT id, number, district, model, capacity, status FROM vehicles ORDER BY id", conn);
            await using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
                vehicles.Add(ReadVehicle(reader));
            return vehicles;
        }

        /// <summary>
        /// Возвращает транспорт по идентификатору или null, если не найден
        /// </summary>
        public async Task<Vehicle> GetByIdAsync(int id)
        {
            await using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();
            await using var cmd = new NpgsqlCommand(
                "SELECT id, number, district, model, capacity, status FROM vehicles WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("id", id);
            await using var reader = await cmd.ExecuteReaderAsync();
            return await reader.ReadAsync() ? ReadVehicle(reader) : null;
        }

        /// <summary>
        /// Возвращает транспорт по вхождению гос. номера без учёта регистра
        /// </summary>
        public async Task<IEnumerable<Vehicle>> GetByNumberAsync(string number)
        {
            var vehicles = new List<Vehicle>();
            await using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();
            await using var cmd = new NpgsqlCommand(
                "SELECT id, number, district, model, capacity, status FROM vehicles WHERE number ILIKE @val ORDER BY id", conn);
            cmd.Parameters.AddWithValue("val", "%" + number + "%");
            await using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
                vehicles.Add(ReadVehicle(reader));
            return vehicles;
        }

        /// <summary>
        /// Возвращает транспорт по вхождению названия района без учёта регистра
        /// </summary>
        public async Task<IEnumerable<Vehicle>> GetByDistrictAsync(string district)
        {
            var vehicles = new List<Vehicle>();
            await using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();
            await using var cmd = new NpgsqlCommand(
                "SELECT id, number, district, model, capacity, status FROM vehicles WHERE district ILIKE @val ORDER BY id", conn);
            cmd.Parameters.AddWithValue("val", "%" + district + "%");
            await using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
                vehicles.Add(ReadVehicle(reader));
            return vehicles;
        }

        /// <summary>
        /// Возвращает транспорт по вхождению названия модели без учёта регистра
        /// </summary>
        public async Task<IEnumerable<Vehicle>> GetByModelAsync(string model)
        {
            var vehicles = new List<Vehicle>();
            await using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();
            await using var cmd = new NpgsqlCommand(
                "SELECT id, number, district, model, capacity, status FROM vehicles WHERE model ILIKE @val ORDER BY id", conn);
            cmd.Parameters.AddWithValue("val", "%" + model + "%");
            await using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
                vehicles.Add(ReadVehicle(reader));
            return vehicles;
        }

        /// <summary>
        /// Возвращает транспорт с указанной вместимостью
        /// </summary>
        public async Task<IEnumerable<Vehicle>> GetByCapacityAsync(int capacity)
        {
            var vehicles = new List<Vehicle>();
            await using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();
            await using var cmd = new NpgsqlCommand(
                "SELECT id, number, district, model, capacity, status FROM vehicles WHERE capacity = @capacity ORDER BY id", conn);
            cmd.Parameters.AddWithValue("capacity", capacity);
            await using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
                vehicles.Add(ReadVehicle(reader));
            return vehicles;
        }

        /// <summary>
        /// Возвращает транспорт по вхождению статуса без учёта регистра
        /// </summary>
        public async Task<IEnumerable<Vehicle>> GetByStatusAsync(string status)
        {
            var vehicles = new List<Vehicle>();
            await using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();
            await using var cmd = new NpgsqlCommand(
                "SELECT id, number, district, model, capacity, status FROM vehicles WHERE status ILIKE @val ORDER BY id", conn);
            cmd.Parameters.AddWithValue("val", "%" + status + "%");
            await using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
                vehicles.Add(ReadVehicle(reader));
            return vehicles;
        }

        /// <summary>
        /// Добавляет новый транспорт в базу данных и присваивает ему сгенерированный id
        /// </summary>
        public async Task AddAsync(Vehicle newVehicle)
        {
            await using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();
            await using var cmd = new NpgsqlCommand(
                "INSERT INTO vehicles (number, district, model, capacity, status) VALUES (@number, @district, @model, @capacity, @status) RETURNING id", conn);
            cmd.Parameters.AddWithValue("number",   newVehicle.Number);
            cmd.Parameters.AddWithValue("district", newVehicle.District);
            cmd.Parameters.AddWithValue("model",    newVehicle.Model);
            cmd.Parameters.AddWithValue("capacity", newVehicle.Capacity);
            cmd.Parameters.AddWithValue("status",   newVehicle.Status);
            newVehicle.Id = (int)await cmd.ExecuteScalarAsync();
        }

        /// <summary>
        /// Обновляет данные транспорта в базе данных
        /// </summary>
        public async Task UpdateAsync(Vehicle editVehicle)
        {
            await using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();
            await using var cmd = new NpgsqlCommand(
                "UPDATE vehicles SET number = @number, district = @district, model = @model, capacity = @capacity, status = @status WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("id",       editVehicle.Id);
            cmd.Parameters.AddWithValue("number",   editVehicle.Number);
            cmd.Parameters.AddWithValue("district", editVehicle.District);
            cmd.Parameters.AddWithValue("model",    editVehicle.Model);
            cmd.Parameters.AddWithValue("capacity", editVehicle.Capacity);
            cmd.Parameters.AddWithValue("status",   editVehicle.Status);
            await cmd.ExecuteNonQueryAsync();
        }

        /// <summary>
        /// Удаляет транспорт по идентификатору
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            await using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();
            await using var cmd = new NpgsqlCommand("DELETE FROM vehicles WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("id", id);
            await cmd.ExecuteNonQueryAsync();
        }

        /// <summary>
        /// Удаляет все записи транспорта из базы данных
        /// </summary>
        public async Task DeleteAllAsync()
        {
            await using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();
            await using var cmd = new NpgsqlCommand("DELETE FROM vehicles", conn);
            await cmd.ExecuteNonQueryAsync();
        }

        /// <summary>
        /// Удаляет все записи транспорта по названию района без учёта регистра
        /// </summary>
        public async Task DeleteByDistrictAsync(string district)
        {
            await using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();
            await using var cmd = new NpgsqlCommand(
                "DELETE FROM vehicles WHERE LOWER(district) = LOWER(@district)", conn);
            cmd.Parameters.AddWithValue("district", district);
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
