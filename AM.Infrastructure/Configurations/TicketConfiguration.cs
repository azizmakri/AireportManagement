using AM.ApplicatinCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(t => new { t.flightFK, t.passengerFk, t.numTicket });
            builder.HasOne(t=>t.Flight).WithMany(f=>f.Tickets).HasForeignKey(t=>t.flightFK);
            builder.HasOne(t => t.Passenger).WithMany(p => p.Tickets).HasForeignKey(p => p.passengerFk);
        }
    }
}
