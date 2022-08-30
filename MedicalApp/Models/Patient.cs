using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ReasonForIntenation { get; set; }
        public bool IsCured { get; set; }
        public bool IsInTreatment { get; set; }

        public Patient(int id, string name, string reasonForIntenation)
        {
            Id = id;
            Name = name;
            ReasonForIntenation = reasonForIntenation;
        }

        
    }
}
