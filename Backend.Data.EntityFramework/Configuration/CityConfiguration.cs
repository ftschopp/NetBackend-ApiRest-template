using Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Data.EntityFramework.Configuration
{
    internal class CityConfiguration : EntityTypeConfiguration<City>
    {
        internal CityConfiguration()
        {
            ToTable("City");

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

            HasRequired<State>(x => x.State)
                 .WithMany(x => x.Cities)
                 .HasForeignKey(x => x.State_Id);
        }
    }
}
