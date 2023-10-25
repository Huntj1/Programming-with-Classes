public class Patient
{
    public int PatientID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public string Height { get; set; } // Add Height property
    public string Weight { get; set; } // Add Weight property
    public string GenderIdentity { get; set; } // Add GenderIdentity property
    public string Birthday { get; set; } // Add Birthday property
    public string SmokingStatus { get; set; } // Add SmokingStatus property
    public string Medications { get; set; } // Add Medications property
    public string Surgeries { get; set; } // Add Surgeries property
    public string ChronicIllness { get; set; } // Add ChronicIllness property
    public List<MedicalRecords> Records { get; set; }

    public Patient(int patientID, string name)
    {
        PatientID = patientID;
        Name = name;
        Records = new List<MedicalRecords>();
    }
}