using System.Threading;
using System.Threading.Tasks;
using DanfossHomeTrackingService.Core;
using DanfossHomeTrackingService.Persistance.Ef;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DanfossHomeTrackingService.Application.Homes.Handlers
{
    public class AddSensorValueBySensorRequestHandler : AsyncRequestHandler<AddSensorValueBySensorRequest>
    {
        private readonly DanfossDbContext _db;

        public AddSensorValueBySensorRequestHandler(DanfossDbContext db)
        {
            _db = db;
        }
        
        protected override async Task Handle(AddSensorValueBySensorRequest request, CancellationToken cancellationToken)
        {
            var sensor = await _db.Sensors
                .Include(x => x.Values)
                .SingleOrDefaultAsync(x => x.SerialNumber.ToLowerInvariant() == request.Serial.ToLowerInvariant());
            
            if (sensor == null)
                throw DanfossApplicationException.SensorNotFoundException(request.Serial);
            
            sensor.AddValue(request.Value);

            await _db.SaveChangesAsync();
        }
    }
}