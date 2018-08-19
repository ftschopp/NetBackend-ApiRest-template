using Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Data.EntityFramework.Configuration
{
    internal class CountryConfiguration : EntityTypeConfiguration<Country>
    {
        internal CountryConfiguration()
        {
            ToTable("Country");

            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar")
                .HasMaxLength(250)
                .IsRequired();

            HasMany<State>(x => x.States)
                .WithRequired(x => x.Country)
                .HasForeignKey(x => x.Country_Id);

        }
    }
}
