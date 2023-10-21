using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Nurse> nurses = new List<Nurse>();
    static string dataPath = "ehrdata.txt";

    static void Main(string[] args)
    {
        LoadData();

        while (true)
        {
            Console.WriteLine("1. Nurse Login");
            Console.WriteLine("2. Patient Login");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    NurseLogin();
                    break;
                case 2:
                    // Handle patient login or any other patient-related functionality here
                    Console.WriteLine("Patient Login is not yet implemented.");
                    break;
                case 3:
                    SaveData();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void NurseLogin()
    {
        Console.Write("Enter Nurse ID: ");
        int nurseID = int.Parse(Console.ReadLine());

        Nurse nurse = nurses.Find(n => n.NurseID == nurseID);

        if (nurse == null)
        {
            Console.WriteLine("Nurse not found. Create a new nurse profile.");
            Console.Write("Enter Nurse Name: ");
            string nurseName = Console.ReadLine();

            nurse = new Nurse(nurseID, nurseName);
            nurses.Add(nurse);
        }

        bool nurseMenu = true;

        while (nurseMenu)
        {
            Console.WriteLine("Nurse: " + nurse.Name);
            Console.WriteLine("1. Add Patient");
            Console.WriteLine("2. View Patient Records");
            Console.WriteLine("3. Back to Main Menu");
            Console.Write("Choose an option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddPatient(nurse);
                    break;
                case 2:
                    ViewPatientRecords(nurse);
                    break;
                case 3:
                    nurseMenu = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void PatientLogin()
    {
        // Handle patient login or any other patient-related functionality here
        Console.WriteLine("Patient Login is not yet implemented.");
    }

    static void AddPatient(Nurse nurse)
    {
        Console.Write("Enter Patient ID: ");
        int patientID = int.Parse(Console.ReadLine());

        // Check if the patient already exists in the nurse's list
        if (nurse.Patients.Exists(p => p.PatientID == patientID))
        {
            Console.WriteLine("Patient already exists.");
            return;
        }

        Console.Write("Enter Patient Name: ");
        string patientName = Console.ReadLine();

        Console.Write("Enter Patient Age: ");
        int patientAge = int.Parse(Console.ReadLine());

        Console.Write("Enter Patient Gender: ");
        string patientGender = Console.ReadLine();

        // Create a new patient and add it to the nurse's list of patients
        Patient newPatient = new Patient(patientID, patientName);
        newPatient.Age = patientAge;
        newPatient.Gender = patientGender;

        nurse.Patients.Add(newPatient);

        Console.WriteLine("Patient added successfully.");
    }

    static void ViewPatientRecords(Nurse nurse)
    {
        // View patient records logic
        // You can list the records for patients associated with this nurse.
    }

    static void LoadData()
    {
        if (File.Exists(dataPath))
        {
            using (StreamReader reader = new StreamReader(dataPath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Parse and load data into the application
                    // You would need to define the data format and parsing logic
                }
            }
        }
    }

    static void SaveData()
    {
        using (StreamWriter writer = new StreamWriter(dataPath))
        {
            foreach (var nurse in nurses)
            {
                writer.WriteLine($"Nurse,{nurse.NurseID},{nurse.Name}");
                foreach (var patient in nurse.Patients)
                {
                    writer.WriteLine($"Patient,{patient.PatientID},{patient.Name},{patient.Age},{patient.Gender}");
                    foreach (var record in patient.Records)
                    {
                        writer.WriteLine($"Record,{record.Notes},{record.Timestamp}");
                    }
                }
            }
        }
    }
}
