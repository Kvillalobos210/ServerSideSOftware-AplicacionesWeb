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
    public class AccountMap : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account")
                .HasKey(c => c.AccountId);

            builder.Property(c => c.Username)
                .HasColumnName("Username")
                .IsUnicode(false);

            builder.Property(c => c.Password)
                .HasColumnName("Password")
                .IsUnicode(false);

            builder.Property(c => c.UserType)
                .HasColumnName("UserType")
                .IsUnicode(false);

            builder.Property(c => c.Verify)
                .HasColumnName("Verify")
                .IsUnicode(false);
        }
    }
}
