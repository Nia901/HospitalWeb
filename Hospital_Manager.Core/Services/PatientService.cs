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
    public class PatientService:IPatientService
    {
        private readonly HospitalDbContext context;
        public PatientService(HospitalDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            return await context.Patients.Include(x=>x.Doctors).ThenInclude(x=>x.Doctor).ToListAsync();
        }
        public async Task<Patient?> GetPatientByIdAsync(int id)
        {
            return await context.Patients.FindAsync(id);
        }   
        //Details,Edit GET, Edit POST
        public async Task<Patient?> GetPatientWithDoctorsAsync(int id)
        {
            return await context.Patients.Include(x => x.Doctors)
                .ThenInclude(x => x.Doctor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        //create post
        public async Task AddPatientAsync(Patient patient)
        {
            context.Patients.Add(patient);
            await context.SaveChangesAsync();
        }
        public async Task UpdatePatientAsync(Patient patient,List<int> doctorIds)
        {
            patient.Doctors.Clear();
            foreach (var item in doctorIds)
            {
                patient.Doctors.Add(new DoctorPatient { DoctorId = item, PatientId = patient.Id });
            }
            await context.SaveChangesAsync();
        }
        public async Task DeletePatientAsync(int id)
        {
            var patient = await context.Patients.Include(p => p.Doctors).FirstOrDefaultAsync(p => p.Id == id);

            if (patient != null)
            {
                context.DoctorPatients.RemoveRange(patient.Doctors);
                context.Patients.Remove(patient);
                await context.SaveChangesAsync();
            }
        }
    }
}
