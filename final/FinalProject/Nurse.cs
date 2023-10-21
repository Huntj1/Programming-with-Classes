public class Nurse
{
    public int NurseID { get; set; }
    public string Name { get; set; }
    public List<Patient> Patients { get; set; }

    public Nurse(int nurseID, string name)
    {
        NurseID = nurseID;
        Name = name;
        Patients = new List<Patient>();
    }
}