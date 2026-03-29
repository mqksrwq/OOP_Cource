namespace OOP_Cource.Models
{
    public class Route
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public decimal DistanceKm { get; set; }
        public decimal Fare { get; set; }
    }
}
