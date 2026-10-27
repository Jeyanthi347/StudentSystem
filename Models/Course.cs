using System;
using System.Collections.Generic;
using System.Text;


namespace StudentSystem.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int DurationMonths { get; set; }
        public decimal Fee { get; set; }

        // Default constructor
        public Course()
        {
            CourseName = "";
        }

        // Parameterized constructor
        public Course(int courseId, string courseName,
                      int durationMonths, decimal fee)
        {
            CourseId = courseId;
            CourseName = courseName;
            DurationMonths = durationMonths;
            Fee = fee;
        }
    }
}
