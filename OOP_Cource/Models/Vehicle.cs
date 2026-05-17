namespace OOP_Cource.Models
{
    /// <summary>
    /// Модель транспортного средства автопарка
    /// </summary>
    public class Vehicle
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

        /// <summary>
        /// Конструктор по умолчанию с начальными значениями полей
        /// </summary>
        public Vehicle()
        {
            Number = string.Empty;
            District = string.Empty;
            Model = string.Empty;
            Capacity = 0;
            Status = "Активен";
        }

        /// <summary>
        /// Конструктор с параметрами для создания нового транспортного средства
        /// </summary>
        public Vehicle(string number, string district, string model, int capacity, string status)
        {
            Number = number;
            District = district;
            Model = model;
            Capacity = capacity;
            Status = status;
        }
    }
}
