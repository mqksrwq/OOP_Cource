namespace OOP_Cource.Models
{
    /// <summary>
    /// Модель водителя транспортного средства
    /// </summary>
    public class Driver
    {
        /// <summary>
        /// Уникальный идентификатор водителя
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Полное имя водителя (ФИО)
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Номер водительского удостоверения
        /// </summary>
        public string LicenseNumber { get; set; }

        /// <summary>
        /// Назначенное транспортное средство
        /// </summary>
        public string AssignedVehicle { get; set; }
    }
}
