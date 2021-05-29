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
    public class SpecialtyMap : IEntityTypeConfiguration<Specialty>
    {
        public void Configure(EntityTypeBuilder<Specialty> builder)
        {
            builder.ToTable("Specialty")
                .HasKey(s => s.SpecialtyId);
            builder.Property(s => s.SpecialtyName)
                .HasColumnName("SpecialtyName")
                .IsUnicode(false);
        }
    }
}
