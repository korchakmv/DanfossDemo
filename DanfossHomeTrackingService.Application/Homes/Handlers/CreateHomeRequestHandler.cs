using System.Threading;
using System.Threading.Tasks;
using DanfossHomeTrackingService.Domain;
using DanfossHomeTrackingService.Persistance.Ef;
using MediatR;

namespace DanfossHomeTrackingService.Application.Homes.Handlers
{
    public class CreateHomeRequestHandler : IRequestHandler<CreateHomeRequest, int>
    {
        private readonly DanfossDbContext _db;

        public CreateHomeRequestHandler(DanfossDbContext db)
        {
            _db = db;
        }
        
        public async Task<int> Handle(CreateHomeRequest request, CancellationToken cancellationToken)
        {
            var home = new Home(request.Address);
            _db.Homes.Add(home);

            await _db.SaveChangesAsync();

            return home.Id;
        }
    }
}