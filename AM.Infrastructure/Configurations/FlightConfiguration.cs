using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicatinCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)

        {
            builder.HasMany(f => f.passes).WithMany(p => p.Flights)
                .UsingEntity(j => j.ToTable("Reservation"));
            builder.HasOne(f=>f.Plane).WithMany(p=>p.Flights)
                .HasForeignKey(p=>p.planeId).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
