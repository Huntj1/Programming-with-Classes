using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Nurse> nurses = new List<Nurse>();
    static string dataPath = "ehrdata.txt";

    static void Main(string[] args)
    {
        Console.Clear();
        LoadData();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to Huntco EHR! \nIts another great day to save a life! Thank you for all you do!");
            Console.WriteLine("\n1. Nurse Login");
            Console.WriteLine("2. Patient Login");
            Console.WriteLine("\n3. Save to File");
            Console.WriteLine("4. Exit");
            Console.Write("\nChoose an option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    NurseLogin();
                    break;
                case 2:
                Console.Clear();
                    PatientLogin();
                    break;
                case 3:
                    Console.Clear();
                    SaveToFile();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("\nThank you for your service! You are changing the world one by one!");
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
        Console.Write("\n\nEnter Nurse ID: ");
        int nurseID = int.Parse(Console.ReadLine());

        Nurse nurse = nurses.Find(n => n.NurseID == nurseID);

        if (nurse == null)
        {
            Console.WriteLine("\nNurse not found. Create a new nurse profile.");
            Console.Write("\nEnter Nurse Name: ");
            string nurseName = Console.ReadLine();

            nurse = new Nurse(nurseID, nurseName);
            nurses.Add(nurse);
        }

        bool nurseMenu = true;

        while (nurseMenu)
        {
            Console.Clear();
            Console.WriteLine(nurse.Name);
            Console.WriteLine("How can I be of assistance today?");
            Console.WriteLine("\n1. Add Patient");
            Console.WriteLine("2. View Patient Records");
            Console.WriteLine("3. Back to Main Menu");
            Console.Write("\nChoose an option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                Console.Clear();
                    AddPatient(nurse);
                    break;
                case 2:
                Console.Clear();
                    ViewPatientRecords(nurse);
                    break;
                case 3:
                    nurseMenu = false;
                    break;
                default:
                    Console.WriteLine("\nInvalid option. Please try again.");
                    break;
            }
        }
    }

    static void PatientLogin()
{
    Console.Write("\nEnter Patient ID: ");
    int patientID = int.Parse(Console.ReadLine());

    Patient patient = null;

    // Loop through nurses to find the patient
    foreach (var nurse in nurses)
    {
        patient = nurse.Patients.Find(p => p.PatientID == patientID);
        if (patient != null)
            break;
    }

    if (patient == null)
    {
        Console.WriteLine("\nPatient not found.");
        return;
    }

    Console.Clear();
    Console.WriteLine("Patient ID: " + patient.PatientID + ", Name: " + patient.Name + ", Age:" + patient.Age + ", Gender Indentity: " + patient.Gender + ", Medications:" + patient.Medications);
    Console.WriteLine("\nPatient Records for " + patient.Name + ":");
    foreach (var record in patient.Records)
    {
        Console.WriteLine("\nTimestamp: " + record.Timestamp);
        Console.WriteLine("Information: " + record.Notes);
    }

    GoBackToMainMenu(); // Provide an option to go back to the main menu
}
static void GoBackToMainMenu()
{
    Console.WriteLine("\nPress any key to return to the main menu...");
    Console.ReadKey();
    Console.Clear();
    Main(new string[0]); // Restart the main menu
}


    static void AddPatient(Nurse nurse)
{
    Console.Clear();
    Console.Write("Enter Patient ID: ");
    int patientID = int.Parse(Console.ReadLine());

    Console.Clear();
    Console.Write("Enter Patient Name: ");
    string patientName = Console.ReadLine();

    Console.Clear();
    Console.Write("Age: ");
    int age = int.Parse(Console.ReadLine());

    // Prompt for additional patient information
    Console.Clear();
    Console.Write("Height (in inches): ");
    string height = Console.ReadLine();

    Console.Clear();
    Console.Write("Weight (in pounds): ");
    string weight = Console.ReadLine();

    Console.Clear();
    Console.Write("Gender Identity: ");
    string genderIdentity = Console.ReadLine();

    Console.Clear();
    Console.Write("Birthday (YYYY-MM-DD): ");
    string birthday = Console.ReadLine();

    Console.Clear();
    Console.Write("Do you smoke, vape, or use drugs? ");
    string smokingStatus = Console.ReadLine();

    Console.Clear();
    Console.Write("Do you take any medication? If yes, list them (If you are separating items use ':'): ");
    string medications = Console.ReadLine();

    Console.Clear();
    Console.Write("Do you have a history of surgeries? If yes, please describe (If you are separating items use ':'): ");
    string surgeries = Console.ReadLine();

    Console.Clear();
    Console.Write("Do you or any family members have a chronic illness? If yes, please describe (If you are separating items use ':'): ");
    string chronicIllness = Console.ReadLine();

    Console.WriteLine("\nPatient added successfully.");

    // Create a new patient and add it to the nurse's list of patients
    Patient newPatient = new Patient(patientID, patientName);

    // Set the additional patient information
    newPatient.Age = age;
    newPatient.Height = height;
    newPatient.Weight = weight;
    newPatient.GenderIdentity = genderIdentity;
    newPatient.Birthday = birthday;
    newPatient.SmokingStatus = smokingStatus;
    newPatient.Medications = medications;
    newPatient.Surgeries = surgeries;
    newPatient.ChronicIllness = chronicIllness;

    nurse.Patients.Add(newPatient);

    Console.WriteLine("\nPatient added successfully.");
    SaveData();
}


    static void ViewPatientRecords(Nurse nurse)
{
    if (nurse.Patients.Count == 0)
    {
        Console.WriteLine("\nNo patients under this nurse.");
        return;
    }

    Console.WriteLine("\nPatients under Nurse " + nurse.Name + ":");
    foreach (var patient in nurse.Patients)
    {
        Console.WriteLine("\nPatient ID: " + patient.PatientID + ", Name: " + patient.Name + ", Age: " + patient.Age + ", Gender Indentity: " + patient.GenderIdentity + ", Medications: " + patient.Medications);
    }

    Console.Write("\nEnter Patient ID to view records: ");
    int selectedPatientID = int.Parse(Console.ReadLine());

    Patient selectedPatient = nurse.Patients.Find(p => p.PatientID == selectedPatientID);

    if (selectedPatient == null)
    {
        Console.WriteLine("Patient not found.");
        return;
    }
    Console.Clear();
    Console.WriteLine("\nPatient Records for " + selectedPatient.Name + ":");
    foreach (var record in selectedPatient.Records)
    {
        Console.WriteLine("\nTimestamp: " + record.Timestamp);
        Console.WriteLine("Information: " + record.Notes);
    }
    

    Console.WriteLine("\n1. Add Patient Note");
    Console.WriteLine("2. Go Back");
    Console.Write("\nChoose an option: ");
    int choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case 1:
            Console.Clear();
            Console.Write("\nEnter Note (If you need to space out your notes use a ':' not a ','): ");
            string note = Console.ReadLine();
            selectedPatient.Records.Add(new MedicalRecords(note));
            SaveData();
            Console.WriteLine("\nNote added successfully.");
            break;
        case 2:
            // Returning to the main menu
            return;
        default:
            Console.WriteLine("\nInvalid option. Please try again.");
            break;
    }
}
    static void LoadData()
{
    if (File.Exists(dataPath))
    {
        using (StreamReader reader = new StreamReader(dataPath))
        {
            string line;
            Nurse currentNurse = null;
            Patient currentPatient = null;

            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 0) continue;

                if (parts[0] == "Nurse")
                {
                    int nurseID = int.Parse(parts[1]);
                    string nurseName = parts[2];
                    currentNurse = new Nurse(nurseID, nurseName);
                    nurses.Add(currentNurse);
                }
                else if (parts[0] == "Patient")
                {
                    int patientID = int.Parse(parts[1]);
                    string patientName = parts[2];
                    int age = int.Parse(parts[3]);
                    string genderIdentity = parts[4];
                    string birthday = parts[5];
                    string smokingStatus = parts[6];
                    string medications = parts[7];
                    string surgeries = parts[8];
                    string chronicIllness = parts[9];

                    currentPatient = new Patient(patientID, patientName);
                    currentPatient.Age = age;
                    currentPatient.GenderIdentity = genderIdentity;
                    currentPatient.Birthday = birthday;
                    currentPatient.SmokingStatus = smokingStatus;
                    currentPatient.Medications = medications;
                    currentPatient.Surgeries = surgeries;
                    currentPatient.ChronicIllness = chronicIllness;
                    currentNurse.Patients.Add(currentPatient);
                }
                else if (parts[0] == "Record" && currentPatient != null)
                {
                    string notes = parts[1];
                    DateTime timestamp = DateTime.Parse(parts[2]);
                    currentPatient.Records.Add(new MedicalRecords(notes) { Timestamp = timestamp });
                }
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
                writer.WriteLine($"Patient,{patient.PatientID},{patient.Name},{patient.Age},{patient.GenderIdentity},{patient.Birthday},{patient.SmokingStatus},{patient.Medications},{patient.Surgeries},{patient.ChronicIllness}");
                foreach (var record in patient.Records)
                {
                    writer.WriteLine($"Record,{record.Notes},{record.Timestamp}");
                }
            }
        }
    }
}


    static void SaveToFile()
    {
        SaveData();
        Console.WriteLine("\nData saved to file successfully.");
    }
}
