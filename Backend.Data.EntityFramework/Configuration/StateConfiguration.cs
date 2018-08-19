using Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Data.EntityFramework.Configuration
{
    internal class StateConfiguration : EntityTypeConfiguration<State>
    {
        internal StateConfiguration()
        {
            ToTable("State");

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

            HasRequired<Country>(x => x.Country)
                 .WithMany(x => x.States)
                 .HasForeignKey(x => x.Country_Id);

            HasMany<City>(x => x.Cities)
             .WithRequired(x => x.State)
             .HasForeignKey(x => x.State_Id);
        }
    }
}
