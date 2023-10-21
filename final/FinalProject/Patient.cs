public class Patient
{
    public int PatientID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public List<MedicalRecords> Records { get; set; }

    public Patient(int patientID, string name)
    {
        PatientID = patientID;
        Name = name;
        Records = new List<MedicalRecords>();
    }
}