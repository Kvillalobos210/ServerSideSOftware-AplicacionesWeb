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
    public class CityMap : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City")
                .HasKey(b => b.CityId);

            builder.Property(b => b.CityName)
                .HasColumnName("CityName")
                .IsUnicode(false);
        }
    }
}
