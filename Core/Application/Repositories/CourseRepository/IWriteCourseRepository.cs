using Application.Repositories.Repository;
using Domain.Models;

namespace Application.Repositories.CourseRepository;

public interface IWriteCourseRepository : IWriteRepository<Course>
{
}
