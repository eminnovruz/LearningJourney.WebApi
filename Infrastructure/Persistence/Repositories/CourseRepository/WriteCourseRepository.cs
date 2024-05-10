using Application.Repositories.CourseRepository;
using Application.Repositories.Repository;
using Domain.Models;
using Persistence.Context;
using Persistence.Repositories.Repository;

namespace Persistence.Repositories.CourseRepository;

public class WriteCourseRepository : WriteRepository<Course>, IWriteCourseRepository
{
    public WriteCourseRepository(AppDbContext context) : base(context)
    {
    }
}
