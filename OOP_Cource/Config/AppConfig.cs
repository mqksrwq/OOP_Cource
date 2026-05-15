namespace OOP_Cource.Config
{
    /// <summary>
    /// Статический класс для хранения конфигурации приложения
    /// </summary>
    public static class AppConfig
    {
        /// <summary>
        /// Строка подключения к базе данных PostgreSQL
        /// </summary>
        public static string ConnectionString =>
            "Host=localhost;Port=5432;Database=BusParkDB;Username=postgres;Password=root";
    }
}
