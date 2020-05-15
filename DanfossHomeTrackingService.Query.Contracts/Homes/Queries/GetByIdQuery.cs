using DanfossHomeTrackingService.Query.Contracts.Homes.Dtos;
using MediatR;

namespace DanfossHomeTrackingService.Query.Contracts.Homes.Queries
{
    public class GetByIdQuery : IRequest<HomeDto>
    {
        public int Id { get; set; }
    }
}