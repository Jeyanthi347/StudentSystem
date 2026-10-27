using System;
using System.Collections.Generic;
using System.Text;


using Microsoft.Data.SqlClient;
using StudentSystem.Models;

namespace StudentSystem.Repository;

public class EnrollmentRepository(string connectionString)
{
    private readonly string _connectionString = connectionString;

    public async Task AddEnrollmentAsync(Enrollment enrollment)
    {
        const string query = """
            INSERT INTO Enrollments (StudentId, CourseId)
            VALUES (@StudentId, @CourseId)
            """;

        await using var connection =
            new SqlConnection(_connectionString);

        await using var command =
            new SqlCommand(query, connection);

        command.Parameters.AddWithValue(
            "@StudentId", enrollment.StudentId);

        command.Parameters.AddWithValue(
            "@CourseId", enrollment.CourseId);

        await connection.OpenAsync();
        await command.ExecuteNonQueryAsync();
    }

    public async Task<List<Enrollment>> GetAllEnrollmentsAsync()
    {
        const string query = """
            SELECT e.EnrollmentId,
                   e.StudentId,
                   s.Name,
                   e.CourseId,
                   c.CourseName,
                   e.EnrollmentDate
            FROM Enrollments e
            INNER JOIN Students s
                ON e.StudentId = s.StudentId
            INNER JOIN Courses c
                ON e.CourseId = c.CourseId
            ORDER BY e.EnrollmentId
            """;

        List<Enrollment> enrollments = new List<Enrollment>();

        await using var connection =
            new SqlConnection(_connectionString);

        await using var command =
            new SqlCommand(query, connection);

        await connection.OpenAsync();

        await using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            enrollments.Add(new Enrollment
            {
                EnrollmentId = reader.GetInt32(0),
                StudentId = reader.GetInt32(1),
                StudentName = reader.GetString(2),
                CourseId = reader.GetInt32(3),
                CourseName = reader.GetString(4),
                EnrollmentDate = reader.GetDateTime(5)
            });
        }

        return enrollments;
    }

    public async Task<Enrollment?> GetEnrollmentByIdAsync(int id)
    {
        const string query = """
            SELECT e.EnrollmentId,
                   e.StudentId,
                   s.Name,
                   e.CourseId,
                   c.CourseName,
                   e.EnrollmentDate
            FROM Enrollments e
            INNER JOIN Students s
                ON e.StudentId = s.StudentId
            INNER JOIN Courses c
                ON e.CourseId = c.CourseId
            WHERE e.EnrollmentId = @EnrollmentId
            """;

        await using var connection =
            new SqlConnection(_connectionString);

        await using var command =
            new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@EnrollmentId", id);

        await connection.OpenAsync();

        await using var reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            return new Enrollment
            {
                EnrollmentId = reader.GetInt32(0),
                StudentId = reader.GetInt32(1),
                StudentName = reader.GetString(2),
                CourseId = reader.GetInt32(3),
                CourseName = reader.GetString(4),
                EnrollmentDate = reader.GetDateTime(5)
            };
        }

        return null;
    }


    public async Task<bool> DeleteEnrollmentAsync(int id)
    {
        const string query = """
        DELETE FROM Enrollments
        WHERE EnrollmentId = @EnrollmentId
        """;

        await using var connection =
            new SqlConnection(_connectionString);

        await using var command =
            new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@EnrollmentId", id);

        await connection.OpenAsync();

        int rowsAffected = await command.ExecuteNonQueryAsync();

        return rowsAffected > 0;
    }


    public async Task<List<Enrollment>> GetEnrollmentsByStudentIdAsync(int studentId)
    {
        const string query = """
        SELECT e.EnrollmentId,
               e.StudentId,
               s.Name,
               e.CourseId,
               c.CourseName,
               e.EnrollmentDate
        FROM Enrollments e
        INNER JOIN Students s
            ON e.StudentId = s.StudentId
        INNER JOIN Courses c
            ON e.CourseId = c.CourseId
        WHERE e.StudentId = @StudentId
        ORDER BY e.EnrollmentId
        """;

        List<Enrollment> enrollments = new List<Enrollment>();

        await using var connection = new SqlConnection(_connectionString);
        await using var command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@StudentId", studentId);

        await connection.OpenAsync();

        await using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            enrollments.Add(new Enrollment
            {
                EnrollmentId = reader.GetInt32(0),
                StudentId = reader.GetInt32(1),
                StudentName = reader.GetString(2),
                CourseId = reader.GetInt32(3),
                CourseName = reader.GetString(4),
                EnrollmentDate = reader.GetDateTime(5)
            });
        }

        return enrollments;
    }


}
