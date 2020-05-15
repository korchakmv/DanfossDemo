using System.Threading;
using System.Threading.Tasks;
using DanfossHomeTrackingService.Core;
using DanfossHomeTrackingService.Persistance.Ef;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DanfossHomeTrackingService.Application.Homes.Handlers
{
    public class DeleteHomeRequestHandler : AsyncRequestHandler<DeleteHomeRequest>
    {
        private readonly DanfossDbContext _db;

        public DeleteHomeRequestHandler(DanfossDbContext db)
        {
            _db = db;
        }
        
        protected override async Task Handle(DeleteHomeRequest request, CancellationToken cancellationToken)
        {
            var home = await _db.Homes.SingleOrDefaultAsync(x => x.Id == request.Id);
            if (home == null)
                throw DanfossApplicationException.HomeNotFoundException(request.Id);

            _db.Homes.Remove(home);

            await _db.SaveChangesAsync();
        }
    }
}