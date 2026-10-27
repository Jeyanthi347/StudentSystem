
//using StudentSystem.Models;
//using StudentSystem.Repository;
//using StudentSystem.Services;

//namespace StudentSystem;

//public class Program
//{
//    public static async Task Main(string[] args)
//    {
//        string connectionString =
//            @"Server=.\SQLEXPRESS;Database=StudentCourseDB;Trusted_Connection=True;TrustServerCertificate=True;";

//        StudentRepository studentRepository =
//            new StudentRepository(connectionString);

//        CourseRepository courseRepository =
//            new CourseRepository(connectionString);

//        StudentService studentService =
//            new StudentService(studentRepository);

//        CourseService courseService =
//            new CourseService(courseRepository);

//        bool running = true;

//        while (running)
//        {
//            Console.WriteLine("\n===== Student System =====");
//            Console.WriteLine("1. Add Student");
//            Console.WriteLine("2. View All Students");
//            Console.WriteLine("3. Search Student by ID");
//            Console.WriteLine("4. Add Course");
//            Console.WriteLine("5. View All Courses");
//            Console.WriteLine("6. Search Course by ID");
//            Console.WriteLine("7. Delete Student");
//            Console.WriteLine("0. Exit");
//            Console.Write("Enter your choice: ");

//            string choice = Console.ReadLine() ?? "";

//            try
//            {
//                switch (choice)
//                {
//                    case "1":
//                        Console.Write("Enter student name: ");
//                        string name = Console.ReadLine() ?? "";

//                        Console.Write("Enter student email: ");
//                        string email = Console.ReadLine() ?? "";

//                        Console.Write("Enter student age: ");
//                        if (!int.TryParse(Console.ReadLine(), out int age))
//                        {
//                            Console.WriteLine("Please enter a valid age.");
//                            break;
//                        }

//                        Student student = new Student
//                        {
//                            Name = name,
//                            Email = email,
//                            Age = age
//                        };

//                        await studentService.AddStudentAsync(student);
//                        Console.WriteLine("Student added successfully!");
//                        break;

//                    case "2":
//                        List<Student> students =
//                            await studentService.GetAllStudentsAsync();

//                        if (students.Count == 0)
//                        {
//                            Console.WriteLine("No students found.");
//                        }
//                        else
//                        {
//                            foreach (Student s in students)
//                            {
//                                Console.WriteLine(
//                                    $"ID: {s.StudentId}, Name: {s.Name}, Email: {s.Email}, Age: {s.Age}");
//                            }
//                        }
//                        break;

//                    case "3":
//                        Console.Write("Enter student ID: ");
//                        if (!int.TryParse(Console.ReadLine(), out int studentId))
//                        {
//                            Console.WriteLine("Please enter a valid ID.");
//                            break;
//                        }

//                        Student? foundStudent =
//                            await studentService.GetStudentByIdAsync(studentId);

//                        if (foundStudent == null)
//                        {
//                            Console.WriteLine("Student not found.");
//                        }
//                        else
//                        {
//                            Console.WriteLine($"ID: {foundStudent.StudentId}");
//                            Console.WriteLine($"Name: {foundStudent.Name}");
//                            Console.WriteLine($"Email: {foundStudent.Email}");
//                            Console.WriteLine($"Age: {foundStudent.Age}");
//                        }
//                        break;

//                    case "4":
//                        Console.Write("Enter course name: ");
//                        string courseName = Console.ReadLine() ?? "";

//                        Console.Write("Enter duration in months: ");
//                        if (!int.TryParse(Console.ReadLine(), out int duration))
//                        {
//                            Console.WriteLine("Please enter a valid duration.");
//                            break;
//                        }

//                        Console.Write("Enter course fee: ");
//                        if (!decimal.TryParse(Console.ReadLine(), out decimal fee))
//                        {
//                            Console.WriteLine("Please enter a valid fee.");
//                            break;
//                        }

//                        Course course = new Course
//                        {
//                            CourseName = courseName,
//                            DurationMonths = duration,
//                            Fee = fee
//                        };

//                        await courseService.AddCourseAsync(course);
//                        Console.WriteLine("Course added successfully!");
//                        break;

//                    case "5":
//                        List<Course> courses =
//                            await courseService.GetAllCoursesAsync();

//                        if (courses.Count == 0)
//                        {
//                            Console.WriteLine("No courses found.");
//                        }
//                        else
//                        {
//                            foreach (Course c in courses)
//                            {
//                                Console.WriteLine(
//                                    $"ID: {c.CourseId}, Name: {c.CourseName}, Duration: {c.DurationMonths} months, Fee: {c.Fee:F2}");
//                            }
//                        }
//                        break;

//                    case "6":
//                        Console.Write("Enter course ID: ");
//                        if (!int.TryParse(Console.ReadLine(), out int courseId))
//                        {
//                            Console.WriteLine("Please enter a valid ID.");
//                            break;
//                        }

//                        Course? foundCourse =
//                            await courseService.GetCourseByIdAsync(courseId);

//                        if (foundCourse == null)
//                        {
//                            Console.WriteLine("Course not found.");
//                        }
//                        else
//                        {
//                            Console.WriteLine($"ID: {foundCourse.CourseId}");
//                            Console.WriteLine($"Name: {foundCourse.CourseName}");
//                            Console.WriteLine($"Duration: {foundCourse.DurationMonths} months");
//                            Console.WriteLine($"Fee: {foundCourse.Fee:F2}");
//                        }
//                        break;

//                    case "7":
//                        Console.Write("Enter the student ID to delete: ");

//                        if (!int.TryParse(Console.ReadLine(), out int deleteStudentId))
//                        {
//                            Console.WriteLine("Please enter a valid student ID.");
//                            break;
//                        }

//                        // Check whether the student exists first
//                        Student? studentToDelete =
//                            await studentService.GetStudentByIdAsync(deleteStudentId);

//                        if (studentToDelete == null)
//                        {
//                            Console.WriteLine("Student not found.");
//                            break;
//                        }

//                        Console.Write(
//                            $"Are you sure you want to delete {studentToDelete.Name}? (yes/no): ");

//                        string confirmation = Console.ReadLine() ?? "";

//                        if (confirmation.Equals(
//                            "yes", StringComparison.OrdinalIgnoreCase))
//                        {
//                            bool deleted =
//                                await studentService.DeleteStudentAsync(deleteStudentId);

//                            if (deleted)
//                            {
//                                Console.WriteLine("Student deleted successfully!");
//                            }
//                            else
//                            {
//                                Console.WriteLine("Student could not be deleted.");
//                            }
//                        }
//                        else
//                        {
//                            Console.WriteLine("Deletion cancelled.");
//                        }

//                        break;


//                    case "0":
//                        running = false;
//                        Console.WriteLine("Exiting Student System.");
//                        break;

//                    default:
//                        Console.WriteLine("Invalid choice. Try again.");
//                        break;
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error: {ex.Message}");
//            }
//        }
//        Console.ReadKey();
//    }
//}



using StudentSystem.Models;
using StudentSystem.Repository;
using StudentSystem.Services;

namespace StudentSystem;

public class Program
{
    public static async Task Main(string[] args)
    {
        string connectionString =
            @"Server=.\SQLEXPRESS;Database=StudentCourseDB;Trusted_Connection=True;TrustServerCertificate=True;";

        StudentRepository studentRepository =
            new StudentRepository(connectionString);

        CourseRepository courseRepository =
            new CourseRepository(connectionString);

        StudentService studentService =
            new StudentService(studentRepository);

        CourseService courseService =
            new CourseService(courseRepository);

        bool running = true;

        while (running)
        {
            Console.WriteLine("\n===== Student System =====");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Search Student by ID");
            Console.WriteLine("4. Add Course");
            Console.WriteLine("5. View All Courses");
            Console.WriteLine("6. Search Course by ID");
            Console.WriteLine("7. Update Student");
            Console.WriteLine("8. Delete Student");
            Console.WriteLine("9. Delete Course");
            Console.WriteLine("10. Search Course by Name");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine() ?? "";

            try
            {
                switch (choice)
                {
                    case "1":
                        {
                            Console.Write("Enter student name: ");
                            string name = Console.ReadLine() ?? "";

                            Console.Write("Enter student email: ");
                            string email = Console.ReadLine() ?? "";

                            Console.Write("Enter student age: ");

                            if (!int.TryParse(Console.ReadLine(), out int age))
                            {
                                Console.WriteLine("Please enter a valid age.");
                                break;
                            }

                            Student student = new Student
                            {
                                Name = name,
                                Email = email,
                                Age = age
                            };

                            await studentService.AddStudentAsync(student);

                            Console.WriteLine("Student added successfully!");
                            break;
                        }

                    case "2":
                        {
                            List<Student> students =
                                await studentService.GetAllStudentsAsync();

                            if (students.Count == 0)
                            {
                                Console.WriteLine("No students found.");
                            }
                            else
                            {
                                foreach (Student s in students)
                                {
                                    Console.WriteLine(
                                        $"ID: {s.StudentId}, Name: {s.Name}, " +
                                        $"Email: {s.Email}, Age: {s.Age}");
                                }
                            }

                            break;
                        }

                    case "3":
                        {
                            Console.Write("Enter student ID: ");

                            if (!int.TryParse(Console.ReadLine(), out int studentId))
                            {
                                Console.WriteLine("Please enter a valid ID.");
                                break;
                            }

                            Student? foundStudent =
                                await studentService.GetStudentByIdAsync(studentId);

                            if (foundStudent == null)
                            {
                                Console.WriteLine("Student not found.");
                            }
                            else
                            {
                                Console.WriteLine($"ID: {foundStudent.StudentId}");
                                Console.WriteLine($"Name: {foundStudent.Name}");
                                Console.WriteLine($"Email: {foundStudent.Email}");
                                Console.WriteLine($"Age: {foundStudent.Age}");
                            }

                            break;
                        }

                    case "4":
                        {
                            Console.Write("Enter course name: ");
                            string courseName = Console.ReadLine() ?? "";

                            Console.Write("Enter duration in months: ");

                            if (!int.TryParse(Console.ReadLine(), out int duration))
                            {
                                Console.WriteLine("Please enter a valid duration.");
                                break;
                            }

                            Console.Write("Enter course fee: ");

                            if (!decimal.TryParse(Console.ReadLine(), out decimal fee))
                            {
                                Console.WriteLine("Please enter a valid fee.");
                                break;
                            }

                            Course course = new Course
                            {
                                CourseName = courseName,
                                DurationMonths = duration,
                                Fee = fee
                            };

                            await courseService.AddCourseAsync(course);

                            Console.WriteLine("Course added successfully!");
                            break;
                        }

                    case "5":
                        {
                            List<Course> courses =
                                await courseService.GetAllCoursesAsync();

                            if (courses.Count == 0)
                            {
                                Console.WriteLine("No courses found.");
                            }
                            else
                            {
                                foreach (Course c in courses)
                                {
                                    Console.WriteLine(
                                        $"ID: {c.CourseId}, Name: {c.CourseName}, " +
                                        $"Duration: {c.DurationMonths} months, " +
                                        $"Fee: {c.Fee:F2}");
                                }
                            }

                            break;
                        }

                    case "6":
                        {
                            Console.Write("Enter course ID: ");

                            if (!int.TryParse(Console.ReadLine(), out int courseId))
                            {
                                Console.WriteLine("Please enter a valid ID.");
                                break;
                            }

                            Course? foundCourse =
                                await courseService.GetCourseByIdAsync(courseId);

                            if (foundCourse == null)
                            {
                                Console.WriteLine("Course not found.");
                            }
                            else
                            {
                                Console.WriteLine($"ID: {foundCourse.CourseId}");
                                Console.WriteLine($"Name: {foundCourse.CourseName}");
                                Console.WriteLine(
                                    $"Duration: {foundCourse.DurationMonths} months");
                                Console.WriteLine($"Fee: {foundCourse.Fee:F2}");
                            }

                            break;
                        }

                    case "7":
                        {
                            Console.Write("Enter the student ID to update: ");

                            if (!int.TryParse(Console.ReadLine(), out int updateStudentId))
                            {
                                Console.WriteLine("Please enter a valid ID.");
                                break;
                            }

                            Student? existingStudent =
                                await studentService.GetStudentByIdAsync(updateStudentId);

                            if (existingStudent == null)
                            {
                                Console.WriteLine("Student not found.");
                                break;
                            }

                            Console.WriteLine("\nCurrent student details:");
                            Console.WriteLine($"Name: {existingStudent.Name}");
                            Console.WriteLine($"Email: {existingStudent.Email}");
                            Console.WriteLine($"Age: {existingStudent.Age}");

                            Console.WriteLine("\nEnter the updated details.");

                            Console.Write("Enter new student name: ");
                            string updatedName = Console.ReadLine() ?? "";

                            Console.Write("Enter new student email: ");
                            string updatedEmail = Console.ReadLine() ?? "";

                            Console.Write("Enter new student age: ");

                            if (!int.TryParse(Console.ReadLine(), out int updatedAge))
                            {
                                Console.WriteLine("Please enter a valid age.");
                                break;
                            }

                            Student updatedStudent = new Student
                            {
                                StudentId = updateStudentId,
                                Name = updatedName,
                                Email = updatedEmail,
                                Age = updatedAge
                            };

                            bool isUpdated =
                                await studentService.UpdateStudentAsync(updatedStudent);

                            if (isUpdated)
                            {
                                Console.WriteLine("Student updated successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Student could not be updated.");
                            }

                            break;
                        }

                    case "8":
                        {
                            Console.Write("Enter the student ID to delete: ");

                            if (!int.TryParse(Console.ReadLine(), out int deleteStudentId))
                            {
                                Console.WriteLine("Please enter a valid ID.");
                                break;
                            }

                            bool isDeleted =
                                await studentService.DeleteStudentAsync(deleteStudentId);

                            if (isDeleted)
                            {
                                Console.WriteLine("Student deleted successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Student not found.");
                            }

                            break;
                        }

                    case "0":
                        running = false;
                        Console.WriteLine("Exiting Student System.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;

                    case "9":
                        {
                            Console.Write("Enter the Course ID to delete: ");

                            if (!int.TryParse(Console.ReadLine(), out int deleteCourseId))
                            {
                                Console.WriteLine("Please enter a valid Course ID.");
                                break;
                            }

                            Course? courseToDelete =
                                await courseService.GetCourseByIdAsync(deleteCourseId);

                            if (courseToDelete == null)
                            {
                                Console.WriteLine("Course not found.");
                                break;
                            }

                            Console.Write(
                                $"Are you sure you want to delete {courseToDelete.CourseName}? (yes/no): ");

                            string confirmation = Console.ReadLine() ?? "";

                            if (confirmation.Equals("yes",
                                StringComparison.OrdinalIgnoreCase))
                            {
                                bool deleted =
                                    await courseService.DeleteCourseAsync(deleteCourseId);

                                if (deleted)
                                {
                                    Console.WriteLine("Course deleted successfully!");
                                }
                                else
                                {
                                    Console.WriteLine("Course could not be deleted.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Deletion cancelled.");
                            }

                            break;
                        }
                    case "10":
                        {
                            Console.Write("Enter course name to search: ");
                            string searchName = Console.ReadLine() ?? "";

                            List<Course> matchingCourses =
                                await courseService.SearchCoursesByNameAsync(searchName);

                            if (matchingCourses.Count == 0)
                            {
                                Console.WriteLine("No matching courses found.");
                            }
                            else
                            {
                                foreach (Course c in matchingCourses)
                                {
                                    Console.WriteLine(
                                        $"ID: {c.CourseId}, Name: {c.CourseName}, " +
                                        $"Duration: {c.DurationMonths} months, Fee: {c.Fee:F2}");
                                }
                            }

                            break;
                        }
                
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
