using Data_Hospital.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Hospital.Configurations
{
    public class PatientConfiguration:IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(p => p.Email)
                .IsRequired();

            builder.Property(p => p.PhoneNumber)
                .IsRequired();

            builder.HasData(
                new Patient
                {
                    Id = 1,
                    FirstName="Ivan",
                    LastName= "Petrov",
                    Email="ivanpetrov1@abv.bg",
                    PhoneNumber = "0888 123 456"
                },
                new Patient
                {
                    Id = 2,
                    FirstName = "Petar",
                    LastName = "Ivanov",
                    Email = "petarivanov1@abv.bg",
                    PhoneNumber = "0888 123 457"
                },
                 new Patient
                 {
                     Id = 3,
                     FirstName = "Iordan",
                     LastName = "Iordanov",
                     Email = "iordaniordanov1@abv.bg",
                     PhoneNumber = "0888 123 458"
                 }
            );
        }
    }
}
