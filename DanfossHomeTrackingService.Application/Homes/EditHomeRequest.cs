using MediatR;

namespace DanfossHomeTrackingService.Application.Homes
{
    public class EditHomeRequest : IRequest
    {
        public int Id { get; set; }
        public string Address { get; set; }
    }
}