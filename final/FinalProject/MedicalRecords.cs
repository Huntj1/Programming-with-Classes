public class MedicalRecords
{
    public string Notes { get; set; }
    public DateTime Timestamp { get; set; }

    public MedicalRecords(string notes)
    {
        Notes = notes;
        Timestamp = DateTime.Now;
    }
}
// Super Cool Project!