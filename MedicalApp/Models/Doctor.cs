using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Models
{
    public class Doctor
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int NrOfPatients { get; set; }
        public List<string> Specialization = new List<string>();

        public List<Patient> Patients { get; set; }

        public Doctor(string name)
        {
            Name = name;
        }
        public string AddPatientToList(Patient patient)
        {
            if (Specialization.Contains(patient.ReasonForIntenation))
            {
                if (Patients.Count == 0)
                {
                    Patients.Add(patient);
                    NrOfPatients = 0;
                    return "First patient added";
                }

                if (Patients.Count >= 1)
                {
                    Patients.Add(patient);
                    NrOfPatients++;
                    return "Patient added";
                }

                return "No more slots left at this doctor";
            }
            else
            {
                return "The patient could not have been added";
            }
        }

        public string AddSpecialization(string specialization)
        {
            if (specialization.Length > 0)
            {
                Specialization.Add(specialization);
                return specialization;
            }
            else
            {
                return "Specialization can't be empty";
            }
        }

        public void AddDescription(string description)
        {
            Description=description;
        }

        public string TreatPatient(Patient patient)
        {
            if (Specialization.Contains(patient.ReasonForIntenation))
            {
                if (patient.IsInTreatment == true)
                {
                    patient.IsCured = true;
                    return "Patient is cured";
                }
                else
                {
                    return "Patient is not in treatment";
                }
                
            }
            else
            {
                return "Patient is not allocated to this doctor";
            }
        }
    }
}
