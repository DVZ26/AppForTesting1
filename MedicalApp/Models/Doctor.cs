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

        public List<Patient> Patients = new List<Patient>();

        public Doctor(string name)
        {
            Name = name;
        }
        //Un doctor cu specializare incearca sa isi adauge un pacient
        //daca pacientul are nevoie de alta specializare va da eroare "Needs a different specialization"
        //daca nu mai sunt locuri la doctor va da eroare cu "No more slots left"
        //daca este primul pacient adaugat va da mesajul "First patient added"
        //daca este oricare urmatorul  va fi un mesaj simplu de "Patient added"
        public string AddPatientToList(Patient patient)
        {
            if (Patients.Count < NrOfPatients)
                return "No more slots left";
            if (Specialization.Contains(patient.ReasonForIntenation))
            {
                Patients.Add(patient);
                if (Patients.Count == 1)
                {
                    return "First patient added";
                }  
                return "Patient added";
            }
            else
            {
                return "Needs a different specialization";
            }
        }

        //Adauge o specializare la Doctor
        public string AddSpecialization(string specialization)
        {
            if (specialization.Length > 5)
            {
                Specialization.Add(specialization);
                return specialization;
            }
            else
            {
                return "Lenght can't be less then 5";
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
