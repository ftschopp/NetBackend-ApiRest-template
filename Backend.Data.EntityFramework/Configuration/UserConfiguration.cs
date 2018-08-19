using Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Data.EntityFramework.Configuration
{
    internal class UserConfiguration : EntityTypeConfiguration<User>
    {
        internal UserConfiguration()
        {
            ToTable("User");

            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("UserId")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            Property(x => x.Email)
               .HasColumnName("Email")
               .HasColumnType("nvarchar")
               .IsMaxLength()
               .IsRequired();

            Property(x => x.Password)
                .HasColumnName("Password")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsRequired();

            Property(x => x.SecurityStamp)
                .HasColumnName("SecurityStamp")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsOptional();

            Property(x => x.FullName)
                .HasColumnName("Fullname")
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsRequired();

            Property(x => x.RefreshToken)
                .HasColumnName("RefreshToken")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsOptional();

            HasMany(x => x.Roles)
                .WithMany(x => x.Users)
                .Map(x =>
                {
                    x.ToTable("UserRole");
                    x.MapLeftKey("UserId");
                    x.MapRightKey("RoleId");
                });
        }
    }
}
