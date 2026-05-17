namespace OOP_Cource.Config
{
    /// <summary>
    /// Конфигурация приложения с параметрами подключения к PostgreSQL
    /// </summary>
    public static class AppConfig
    {
        /// <summary>
        /// Строка подключения к базе данных транспортного парка
        /// </summary>
        public static string ConnectionString =>
            "Host=localhost;Database=vehicles_db;Username=postgres;Password=87953";

        /// <summary>
        /// Строка подключения к системной базе данных для создания vehicles_db
        /// </summary>
        public static string MasterConnectionString =>
            "Host=localhost;Database=postgres;Username=postgres;Password=87953";
    }
}
