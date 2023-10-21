using System;
using System.ComponentModel.DataAnnotations;



public class Job
{
   
   
   
    public static string _jobTitle = "Physician Liaison";
    public static string _company = "Teton Radiology";
    public static int _startYear = 2021;
    public static int _endYear = 2024;

    public static void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
    public static void Main() {
        Display();
    }
}