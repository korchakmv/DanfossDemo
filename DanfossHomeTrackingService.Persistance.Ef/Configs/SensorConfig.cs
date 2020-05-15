using DanfossHomeTrackingService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DanfossHomeTrackingService.Persistance.Ef.Configs
{
    public class SensorConfig : IEntityTypeConfiguration<Sensor>
    {
        public void Configure(EntityTypeBuilder<Sensor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.SerialNumber)
                .HasMaxLength(64);

            builder.HasIndex(x => x.SerialNumber)
                .IsUnique();

            builder.HasOne(x => x.Home)
                .WithMany(x => x.Sensors)
                .HasForeignKey(x => x.HomeId);
        }
    }
}