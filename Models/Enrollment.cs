using System;
using System.Collections.Generic;
using System.Text;


namespace StudentSystem.Models;

public class Enrollment
{
    public int EnrollmentId { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public DateTime EnrollmentDate { get; set; }

    public string StudentName { get; set; } = "";
    public string CourseName { get; set; } = "";

    public Enrollment()
    {
    }

    public Enrollment(
        int enrollmentId,
        int studentId,
        int courseId,
        DateTime enrollmentDate)
    {
        EnrollmentId = enrollmentId;
        StudentId = studentId;
        CourseId = courseId;
        EnrollmentDate = enrollmentDate;
    }
}
