using DanfossHomeTrackingService.Domain;
using MediatR;

namespace DanfossHomeTrackingService.Application.Homes
{
    public class AddSensorRequest : IRequest<int>
    {
        public int HomeId { get; set; }
        public Sensor NewSensor { get; set; } = new Sensor();
        
        public class Sensor
        {
            public string SerialNumber { get; set; }
            public SensorType SensorType { get; set; }
        }
    }
}