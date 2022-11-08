using AM.ApplicatinCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.HasDiscriminator<String>("isTraveller")
                .HasValue<Traveller>("1")
                .HasValue<Staff>("2")
                .HasValue<Passenger>("0");
            builder.OwnsOne(p => p.fullName, fullN =>
            {
                fullN.Property(p => p.FirstName)
                .HasMaxLength(30)
                .HasColumnName("passFirstName");
                fullN.Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("passLastName");
            });
        }
    }
}
