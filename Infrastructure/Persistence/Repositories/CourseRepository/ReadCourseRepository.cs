using Application.Repositories.BookRepository;
using Application.Repositories.CourseRepository;
using Domain.Models;
using Persistence.Context;
using Persistence.Repositories.Repository;

namespace Persistence.Repositories.CourseRepository;

public class ReadCourseRepository : ReadRepository<Course>, IReadCourseRepository
{
    public ReadCourseRepository(AppDbContext context) : base(context)
    {
    }
}