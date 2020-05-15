using DanfossHomeTrackingService.Query.Contracts.Homes.Dtos;
using MediatR;

namespace DanfossHomeTrackingService.Query.Contracts.Homes.Queries
{
    public class GetAllQuery : IRequest<HomeDto[]>
    {
        
    }
}