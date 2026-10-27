
using StudentSystem.Models;
using StudentSystem.Repository;

namespace StudentSystem.Services;

public class CourseService(CourseRepository courseRepository)
{
    public async Task AddCourseAsync(Course course)
    {
        if (string.IsNullOrWhiteSpace(course.CourseName))
        {
            throw new ArgumentException("Course name is required.");
        }

        if (course.DurationMonths <= 0)
        {
            throw new ArgumentException("Course duration must be greater than zero.");
        }

        if (course.Fee < 0)
        {
            throw new ArgumentException("Course fee cannot be negative.");
        }

        await courseRepository.AddCourseAsync(course);
    }

    public async Task<List<Course>> GetAllCoursesAsync()
    {
        return await courseRepository.GetAllCoursesAsync();
    }

    public async Task<Course?> GetCourseByIdAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Course ID must be greater than zero.");
        }

        return await courseRepository.GetCourseByIdAsync(id);
    }
    public async Task<bool> DeleteCourseAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException(
                "Course ID must be greater than zero.");
        }

        return await courseRepository.DeleteCourseAsync(id);
    }
    public async Task<List<Course>> SearchCoursesByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Course name is required.");
        }

        return await courseRepository.SearchCoursesByNameAsync(name);
    }
}
