using MediatR;

namespace DanfossHomeTrackingService.Application.Homes
{
    public class DeleteHomeRequest : IRequest
    {
        public int Id { get; set; }
    }
}