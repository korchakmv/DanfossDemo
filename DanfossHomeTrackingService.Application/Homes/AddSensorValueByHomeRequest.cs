using MediatR;

namespace DanfossHomeTrackingService.Application.Homes
{
    public class AddSensorValueByHomeRequest : IRequest
    {
        public int HomeId { get; set; }
        public string SensorSerialNumber { get; set; }
        public int SensorValue { get; set; }
    }
}