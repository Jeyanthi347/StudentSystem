
//using StudentSystem.Models;
//using StudentSystem.Repository;

//namespace StudentSystem.Services;

//public class StudentService(StudentRepository studentRepository)
//{
//    public async Task AddStudentAsync(Student student)
//    {
//        if (string.IsNullOrWhiteSpace(student.Name))
//        {
//            throw new ArgumentException("Student name is required.");
//        }

//        if (string.IsNullOrWhiteSpace(student.Email) ||
//            !student.Email.Contains('@'))
//        {
//            throw new ArgumentException("Enter a valid email address.");
//        }

//        if (student.Age < 17 || student.Age > 60)
//        {
//            throw new ArgumentException("Student age must be between 17 and 60.");
//        }

//        await studentRepository.AddStudentAsync(student);
//    }

//    public async Task<List<Student>> GetAllStudentsAsync()
//    {
//        return await studentRepository.GetAllStudentsAsync();
//    }

//    public async Task<Student?> GetStudentByIdAsync(int id)
//    {
//        if (id <= 0)
//        {
//            throw new ArgumentException("Student ID must be greater than zero.");
//        }

//        return await studentRepository.GetStudentByIdAsync(id);
//    }

//    public async Task<bool> DeleteStudentAsync(int id)
//    {
//        if (id <= 0)
//        {
//            throw new ArgumentException(
//                "Student ID must be greater than zero.");
//        }

//        return await studentRepository.DeleteStudentAsync(id);
//    }

//}


using StudentSystem.Models;
using StudentSystem.Repository;

namespace StudentSystem.Services;

public class StudentService(StudentRepository studentRepository)
{
    public async Task AddStudentAsync(Student student)
    {
        if (string.IsNullOrWhiteSpace(student.Name))
            throw new ArgumentException("Student name is required.");

        if (string.IsNullOrWhiteSpace(student.Email) ||
            !student.Email.Contains('@'))
            throw new ArgumentException("Enter a valid email address.");

        if (student.Age < 17 || student.Age > 60)
            throw new ArgumentException(
                "Student age must be between 17 and 60.");

        await studentRepository.AddStudentAsync(student);
    }

    public async Task<List<Student>> GetAllStudentsAsync()
    {
        return await studentRepository.GetAllStudentsAsync();
    }

    public async Task<Student?> GetStudentByIdAsync(int id)
    {
        if (id <= 0)
            throw new ArgumentException(
                "Student ID must be greater than zero.");

        return await studentRepository.GetStudentByIdAsync(id);
    }

    public async Task<bool> DeleteStudentAsync(int id)
    {
        if (id <= 0)
            throw new ArgumentException(
                "Student ID must be greater than zero.");

        return await studentRepository.DeleteStudentAsync(id);
    }

    // Update an existing student
    public async Task<bool> UpdateStudentAsync(Student student)
    {
        if (student.StudentId <= 0)
            throw new ArgumentException(
                "Student ID must be greater than zero.");

        if (string.IsNullOrWhiteSpace(student.Name))
            throw new ArgumentException("Student name is required.");

        if (string.IsNullOrWhiteSpace(student.Email) ||
            !student.Email.Contains('@'))
            throw new ArgumentException("Enter a valid email address.");

        if (student.Age < 17 || student.Age > 60)
            throw new ArgumentException(
                "Student age must be between 17 and 60.");

        return await studentRepository.UpdateStudentAsync(student);
    }
    public async Task<Student?> GetStudentByEmailAsync(string email)
    {
        if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
        {
            throw new ArgumentException("Enter a valid email address.");
        }

        return await studentRepository.GetStudentByEmailAsync(email);
    }
}
