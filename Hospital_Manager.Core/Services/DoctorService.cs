using Data_Hospital;
using Data_Hospital.Entities;
using Hospital_Manager.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Manager.Core.Services
{
    public class DoctorService:IDoctorService
    {
        private readonly HospitalDbContext context;
        public DoctorService(HospitalDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Doctor>> GetAllDoctorsAsync(string?search,string?specialty,string?sortOrder)
        {
            var query=context.Doctors.Include(d => d.Hospital).Where(d=>true);

            //IQueryable<Doctor> query = context.Doctors.Include(h=>h.Hospital);

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(d => d.FirstName.Contains(search) || d.LastName.Contains(search));
            }

            if (!string.IsNullOrEmpty(specialty))
            {
                query = query.Where(d => d.Specialty.Contains(specialty));
            }
            switch(sortOrder)
            {
                case "name_desc":
                    query = query.OrderByDescending(d => d.FirstName)
                        .ThenByDescending(d=>d.LastName);
                    break;
                case "name_asc":
                    query = query.OrderBy(d => d.FirstName)
                        .ThenBy(d => d.LastName);
                    break;
                case "specialty":
                    query = query.OrderBy(d => d.Specialty)
                        .ThenBy(d => d.FirstName);
                    break;
                default:
                    query = query.OrderBy(d => d.FirstName)
                        .ThenBy(d => d.LastName);
                    break;
            }
            return await query.ToListAsync();
        }
        public async Task<Doctor?> GetDoctorByIdAsync(int id)
        {
            return await context.Doctors.FindAsync(id);
        }
        public async Task<Doctor?> GetDoctorDetailsAsync(int id)
        {
            return await context.Doctors.Include(x => x.Hospital)
                .Include(x=>x.Patients)
                .ThenInclude(x=>x.Patient)
                .FirstOrDefaultAsync(d => d.Id == id);
        }
        public async Task AddDoctorAsync(Doctor doctor)
        {
            context.Doctors.Add(doctor);
            await context.SaveChangesAsync();
        }
        public async Task UpdateDoctorAsync(Doctor doctor)
        {
            await context.SaveChangesAsync();
        }
        public async Task DeleteDoctorAsync(int id)
        {
            var doctor = await context.Doctors.Include(d=>d.Patients).FirstOrDefaultAsync(d=>d.Id==id);

            if (doctor != null)
            {
                context.DoctorPatients.RemoveRange(doctor.Patients);
                context.Doctors.Remove(doctor);
                await context.SaveChangesAsync();
            }
        }
    }
}
