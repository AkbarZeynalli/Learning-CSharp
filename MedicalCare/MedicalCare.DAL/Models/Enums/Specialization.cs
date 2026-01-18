using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCare.DAL.Models.Enums
{
    public enum Specialization
    {
        // General
        GeneralPractitioner = 0,
        FamilyMedicine = 1,
        InternalMedicine = 2,

        // Surgery
        GeneralSurgeon = 10,
        Neurosurgeon = 11,
        CardiacSurgeon = 12,
        OrthopedicSurgeon = 13,
        PlasticSurgeon = 14,

        // Medical Specialists
        Cardiologist = 20,
        Dermatologist = 21,
        Neurologist = 22,
        Psychiatrist = 23,
        Psychologist = 24,
        Oncologist = 25,
        Endocrinologist = 26,
        Gastroenterologist = 27,
        Nephrologist = 28,
        Urologist = 29,

        // Women & Children
        Gynecologist = 30,
        Obstetrician = 31,
        Pediatrician = 32,

        // Eyes, Ears, Nose, Throat
        Ophthalmologist = 40,
        ENTSpecialist = 41,
        Dentist = 42,
        Orthodontist = 43,

        // Other
        Radiologist = 50,
        Anesthesiologist = 51,
        Pathologist = 52,
        PhysicalTherapist = 53,
        Nutritionist = 54,
        Other = 99
    }
}
