using DhomeApp.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhomeApp.Data.Mapping
{
    public class AppointmentMap : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("appointment")
                .HasKey(a => a.AppointmentId);

            builder.Property(a => a.Description)
               .HasColumnName("description")
               .IsUnicode(false);

            builder.Property(a => a.AppointmentDate)
               .HasColumnName("appointmentDate")
               .IsUnicode(false);

            builder.Property(a => a.Address)
               .HasColumnName("address")
               .IsUnicode(false);

            builder.Property(a => a.Valorization)
               .HasColumnName("valorization")
               .IsUnicode(false);

            builder.Property(a => a.Status)
               .HasColumnName("status")
               .IsUnicode(false);

            builder.HasOne(a => a.Customer)
                .WithMany(a => a.Appointments)
                .HasForeignKey(a => a.CustomerId)
                .HasConstraintName("fk_appointment_customer")
                .IsRequired(true);

            builder.HasOne(a => a.Employee)
                .WithMany(a => a.Appointments)
                .HasForeignKey(a => a.EmployeeId)
                .HasConstraintName("fk_appointment_employee")
                .IsRequired(true);

            builder.HasOne(e => e.PaymentMethod)
                .WithMany(e => e.Appointments)
                .HasForeignKey(e => e.PaymentMethodId)
                .HasConstraintName("fk_appointment_paymentMethod")
                .IsRequired(true);
        }
    }
}
