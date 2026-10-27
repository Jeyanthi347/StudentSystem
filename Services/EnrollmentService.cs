using System;
using System.Collections.Generic;
using System.Text;


using StudentSystem.Models;
using StudentSystem.Repository;

namespace StudentSystem.Services;

public class EnrollmentService(EnrollmentRepository enrollmentRepository)
{
    public async Task AddEnrollmentAsync(Enrollment enrollment)
    {
        if (enrollment.StudentId <= 0)
        {
            throw new ArgumentException(
                "Student ID must be greater than zero.");
        }

        if (enrollment.CourseId <= 0)
        {
            throw new ArgumentException(
                "Course ID must be greater than zero.");
        }

        await enrollmentRepository.AddEnrollmentAsync(enrollment);
    }

    public async Task<List<Enrollment>> GetAllEnrollmentsAsync()
    {
        return await enrollmentRepository.GetAllEnrollmentsAsync();
    }

    public async Task<Enrollment?> GetEnrollmentByIdAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException(
                "Enrollment ID must be greater than zero.");
        }

        return await enrollmentRepository.GetEnrollmentByIdAsync(id);
    }

    public async Task<bool> DeleteEnrollmentAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException(
                "Enrollment ID must be greater than zero.");
        }

        return await enrollmentRepository.DeleteEnrollmentAsync(id);
    }



    public async Task<List<Enrollment>> GetEnrollmentsByStudentIdAsync(int studentId)
    {
        if (studentId <= 0)
        {
            throw new ArgumentException(
                "Student ID must be greater than zero.");
        }

        return await enrollmentRepository.GetEnrollmentsByStudentIdAsync(studentId);
    }


}
