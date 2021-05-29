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
    public class DistrictMap : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.ToTable("District")
                .HasKey(d => d.DistrictId);

            builder.Property(d => d.DistrictName)
                .HasColumnName("DistrictName")
                .IsUnicode(false);

            builder.HasOne(d => d.City)
                .WithMany(d => d.Districts)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("fk_district_city")
                .IsRequired(true);
        }
    }
}
