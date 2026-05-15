namespace OOP_Cource.DTO
{
    /// <summary>
    /// DTO для отображения транспорта
    /// </summary>
    public class VehicleDTO
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public string Status { get; set; }
    }
}
