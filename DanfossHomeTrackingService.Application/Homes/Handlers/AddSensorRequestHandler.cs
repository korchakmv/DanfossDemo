using System.Threading;
using System.Threading.Tasks;
using DanfossHomeTrackingService.Core;
using DanfossHomeTrackingService.Domain;
using DanfossHomeTrackingService.Persistance.Ef;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DanfossHomeTrackingService.Application.Homes.Handlers
{
    public class AddSensorRequestHandler : IRequestHandler<AddSensorRequest, int>
    {
        private readonly DanfossDbContext _db;

        public AddSensorRequestHandler(DanfossDbContext db)
        {
            _db = db;
        }
        
        public async Task<int> Handle(AddSensorRequest request, CancellationToken cancellationToken)
        {
            var home = await _db.Homes.SingleOrDefaultAsync(x => x.Id == request.HomeId);
            if (home == null)
                throw DanfossApplicationException.HomeNotFoundException(request.HomeId);
            
            var sensor = new Sensor(request.NewSensor.SerialNumber, request.NewSensor.SensorType, home);
            home.AddSensor(sensor);

            await _db.SaveChangesAsync();

            return sensor.Id;
        }
    }
}