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
               .HasColumnName("firstname")
               .IsUnicode(false);

            builder.Property(e => e.Lastname)
               .HasColumnName("lastname")
               .IsUnicode(false);

            builder.Property(e => e.Dni)
                .HasColumnName("dni")
                .IsUnicode(false);

            builder.Property(e => e.Email)
                .HasColumnName("email")
                .IsUnicode(false);

            builder.Property(e => e.Password)
                .HasColumnName("password")
                .IsUnicode(false);

            builder.Property(e => e.City)
                .HasColumnName("city")
                .IsUnicode(false);

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .IsUnicode(false);


        }
    }
}
