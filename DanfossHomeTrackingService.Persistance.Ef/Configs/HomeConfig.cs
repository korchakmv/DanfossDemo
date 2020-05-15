using DanfossHomeTrackingService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DanfossHomeTrackingService.Persistance.Ef.Configs
{
    public class HomeConfig : IEntityTypeConfiguration<Home>
    {
        public void Configure(EntityTypeBuilder<Home> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Address)
                .IsUnique();
        }
    }
}