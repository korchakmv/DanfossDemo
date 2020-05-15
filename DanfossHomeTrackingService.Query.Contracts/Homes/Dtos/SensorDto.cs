using DanfossHomeTrackingService.Domain;

namespace DanfossHomeTrackingService.Query.Contracts.Homes.Dtos
{
    public class SensorDto
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public SensorType SensorType { get; set; }
    }
}