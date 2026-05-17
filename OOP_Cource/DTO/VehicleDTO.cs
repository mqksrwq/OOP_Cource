namespace OOP_Cource.DTO
{
    /// <summary>
    /// DTO для передачи данных о транспортном средстве между слоями приложения
    /// </summary>
    public class VehicleDTO
    {
        /// <summary>
        /// Уникальный идентификатор транспортного средства
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Государственный номер транспортного средства
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Район обслуживания транспортного средства
        /// </summary>
        public string District { get; set; }

        /// <summary>
        /// Модель транспортного средства
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Вместимость транспортного средства в пассажирах
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// Текущий статус транспортного средства
        /// </summary>
        public string Status { get; set; }
    }
}
