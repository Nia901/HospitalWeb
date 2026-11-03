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
    public class DoctorConfiguration:IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasData(
                new Doctor
                {
                    Id = 1,
                    FirstName = "Dr. John",
                    LastName = "Smith",
                    Specialty = "Cardiology",
                    Email="johnsmith@abv.bg",
                    PhoneNumber = "0888 123 456",
                    HospitalId = 1
                },
               new Doctor
               {
                   Id = 2,
                   FirstName = "Dr. Kiril",
                   LastName = "Manolov",
                   Specialty = "Neurology",
                   Email = "kirlimanolov@abv.bg",
                   PhoneNumber = "0888 123 457",
                   HospitalId = 2
               },
                new Doctor
                {
                    Id = 3,
                    FirstName = "Dr. Peter",
                    LastName = "Jonhson",
                    Specialty = "Dermatology",
                    Email = "petarjohnson@abv.bg",
                    PhoneNumber = "0888 123 459",
                    HospitalId = 3
                }
            );
        }
    }
}
