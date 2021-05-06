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
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer")
                .HasKey(c => c.CustomerId);

            builder.Property(c => c.Firstname)
                .HasColumnName("Firstname")
                .IsUnicode(false);

            builder.Property(c => c.Lastname)
                .HasColumnName("Lastname")
                .IsUnicode(false);

            builder.Property(c => c.Dni)
                .HasColumnName("Dni")
                .IsUnicode(false);

            builder.Property(c => c.Email)
                .HasColumnName("Email")
                .IsUnicode(false);

            builder.Property(c => c.Password)
                .HasColumnName("Password")
                .IsUnicode(false);

            builder.Property(c => c.City)
                .HasColumnName("City")
                .IsUnicode(false);
        }
    }
}
