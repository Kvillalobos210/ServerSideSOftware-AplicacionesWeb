using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DhomeApp.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DhomeApp.Data.Mapping
{
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee")
                .HasKey(e => e.EmployeeId);

            builder.Property(e => e.Firstname)
               .HasColumnName("Firstname")
               .IsUnicode(false);

            builder.Property(e => e.Lastname)
               .HasColumnName("Lastname")
               .IsUnicode(false);

            builder.Property(e => e.Dni)
                .HasColumnName("Dni")
                .IsUnicode(false);

            builder.Property(e => e.Email)
                .HasColumnName("Email")
                .IsUnicode(false);

            builder.Property(e => e.IdCity)
                .HasColumnName("idCity")
                .IsUnicode(false);

            builder.Property(e => e.Description)
                .HasColumnName("Description")
                .IsUnicode(false);

            builder.Property(e => e.Cellphone)
                .HasColumnName("Cellphone")
                .IsUnicode(false);

            builder.Property(e => e.IdSpecialty)
                .HasColumnName("idSpecialty")
                .IsUnicode(false);

            builder.Property(e => e.IdDistrict)
                .HasColumnName("idDistrict")
                .IsUnicode(false);

            builder.Property(e => e.IdAccount)
                .HasColumnName("idAccount")
                .IsUnicode(false);

        }
    }
}
