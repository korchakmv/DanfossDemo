using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DanfossHomeTrackingService.Core;
using DanfossHomeTrackingService.Persistance.Ef;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DanfossHomeTrackingService.Application.Homes.Handlers
{
    public class AddSensorValueByHomeRequestHandler : AsyncRequestHandler<AddSensorValueByHomeRequest>
    {
        private readonly DanfossDbContext _db;

        public AddSensorValueByHomeRequestHandler(DanfossDbContext db)
        {
            _db = db;
        }
        
        protected override async Task Handle(AddSensorValueByHomeRequest request, CancellationToken cancellationToken)
        {
            var home = await _db.Homes
                .Include(x => x.Sensors)
                .SingleOrDefaultAsync(x => x.Id == request.HomeId);
            
            if (home == null)
                throw DanfossApplicationException.HomeNotFoundException(request.HomeId);

            var sensor = home.Sensors.SingleOrDefault(x =>
                x.SerialNumber.ToLowerInvariant() == request.SensorSerialNumber.ToLowerInvariant());
            
            if (sensor == null)
                throw DanfossApplicationException.SensorNotFoundException(request.SensorSerialNumber);
            
            sensor.AddValue(request.SensorValue);

            await _db.SaveChangesAsync();
        }
    }
}