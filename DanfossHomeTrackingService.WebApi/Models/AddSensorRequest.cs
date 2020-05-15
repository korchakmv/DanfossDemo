using DanfossHomeTrackingService.Domain;

namespace DanfossHomeTrackingService.WebApi.Models
{
    public class AddSensorRequest
    {
        public string SerialNumber { get; set; }
        public SensorType SensorType { get; set; }
    }
}