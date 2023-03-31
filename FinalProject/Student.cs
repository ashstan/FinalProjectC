using System;

namespace FinalProject
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        
        public Student(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
        
        public Student()
        {
            FirstName = "Unknown First Name";
            LastName = "Unknown Last Name";
            Email = "Unknown Email";
        }
        public override string ToString()
        {
            return String.Format($"{FirstName} {LastName} | {Email}");
        }
    }
}