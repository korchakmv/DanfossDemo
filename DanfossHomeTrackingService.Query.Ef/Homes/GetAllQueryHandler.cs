using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DanfossHomeTrackingService.Persistance.Ef;
using DanfossHomeTrackingService.Query.Contracts.Homes;
using DanfossHomeTrackingService.Query.Contracts.Homes.Dtos;
using DanfossHomeTrackingService.Query.Contracts.Homes.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DanfossHomeTrackingService.Query.Ef.Homes
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, HomeDto[]>
    {
        private readonly DanfossDbContext _db;

        public GetAllQueryHandler(DanfossDbContext db)
        {
            _db = db;
        }
        
        public Task<HomeDto[]> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            return _db.Homes.AsNoTracking()
                .Select(x => new HomeDto
                {
                    Id = x.Id,
                    Address = x.Address,
                    Sensors = x.Sensors.Select(sensor => new SensorDto
                    {
                        Id = sensor.Id,
                        SerialNumber = sensor.SerialNumber,
                        SensorType = sensor.SensorType
                    }).ToArray()
                }).ToArrayAsync();
        }
    }
}