using System.Threading;
using System.Threading.Tasks;
using DanfossHomeTrackingService.Core;
using DanfossHomeTrackingService.Persistance.Ef;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DanfossHomeTrackingService.Application.Homes.Handlers
{
    public class EditHomeRequestHandler : AsyncRequestHandler<EditHomeRequest>
    {
        private readonly DanfossDbContext _db;

        public EditHomeRequestHandler(DanfossDbContext db)
        {
            _db = db;
        }
        
        protected override async Task Handle(EditHomeRequest request, CancellationToken cancellationToken)
        {
            var home = await _db.Homes.SingleOrDefaultAsync(x => x.Id == request.Id);
            if (home == null)
                throw DanfossApplicationException.HomeNotFoundException(request.Id);

            home.Address = request.Address;
            await _db.SaveChangesAsync();
        }
    }
}