using System;
using System.Collections.Generic;
using System.Text;


namespace StudentSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        // Default constructor
        public Student()
        {
            Name = "";
            Email = "";
        }

        // Parameterized constructor
        public Student(int studentId, string name, string email, int age)
        {
            StudentId = studentId;
            Name = name;
            Email = email;
            Age = age;
        }
    }
}
