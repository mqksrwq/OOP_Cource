namespace OOP_Cource.Models
{
    /// <summary>
    /// Модель маршрута транспортного средства
    /// </summary>
    public class Route
    {
        /// <summary>
        /// Уникальный идентификатор маршрута
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Код маршрута
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Начальная точка маршрута
        /// </summary>
        public string StartPoint { get; set; }

        /// <summary>
        /// Конечная точка маршрута
        /// </summary>
        public string EndPoint { get; set; }

        /// <summary>
        /// Протяжённость маршрута в километрах
        /// </summary>
        public decimal DistanceKm { get; set; }

        /// <summary>
        /// Стоимость проезда по маршруту
        /// </summary>
        public decimal Fare { get; set; }
    }
}
