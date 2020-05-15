using MediatR;

namespace DanfossHomeTrackingService.Application.Homes
{
    public class CreateHomeRequest : IRequest<int>
    {
        public string Address { get; set; }
    }
}