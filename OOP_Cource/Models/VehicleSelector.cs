namespace OOP_Cource.Models
{
    /// <summary>
    /// Вспомогательная модель для отображения транспорта в выпадающем списке
    /// </summary>
    public class VehicleSelector
    {
        /// <summary>
        /// Идентификатор транспортного средства
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Отображаемое название транспортного средства
        /// </summary>
        public string Display { get; set; }
    }
}
