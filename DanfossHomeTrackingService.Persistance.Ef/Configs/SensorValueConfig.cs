using DanfossHomeTrackingService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DanfossHomeTrackingService.Persistance.Ef.Configs
{
    public class SensorValueConfig : IEntityTypeConfiguration<SensorValue>
    {
        public void Configure(EntityTypeBuilder<SensorValue> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Value)
                .IsRequired();

            builder.Property(x => x.SensorId)
                .IsRequired();

            builder.HasOne(x => x.Sensor)
                .WithMany(x => x.Values)
                .HasForeignKey(x => x.SensorId);
        }
    }
}