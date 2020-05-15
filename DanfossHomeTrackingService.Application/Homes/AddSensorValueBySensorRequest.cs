using MediatR;

namespace DanfossHomeTrackingService.Application.Homes
{
    public class AddSensorValueBySensorRequest : IRequest
    {
        public string Serial { get; set; }
        public int Value { get; set; }
    }
}