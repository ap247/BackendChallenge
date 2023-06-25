using BackendChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendChallenge.Data.Repositories;

/// <summary>
/// Repository class for managing the data access operations for courses
/// </summary>
public class CourseRepository {
    
    private readonly AppDbContext _db;

    public CourseRepository(AppDbContext db) 
    {
        _db = db;
    }
    
    /// <summary>
    /// Retrieves a course given a course id
    /// </summary>
    /// <param name="id">Course id</param>
    /// <returns>The course or null if not found</returns>
    public Course GetCourse(int? id) {
        return _db.Courses.FirstOrDefault(course => course.CourseId.Equals(id));
    }

}