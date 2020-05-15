namespace DanfossHomeTrackingService.Query.Contracts.Homes.Dtos
{
    public class HomeDto
    {
        public int Id { get; set; }
        public string Address { get; set; }

        public SensorDto[] Sensors { get; set; }
    }
}