using Application.Repositories;
using Domain;
using Infrastructure.Persistence.Data;

namespace Infrastructure.Persistence.Repositories;

public class CourseRepository : GenericRepository<Course>, ICourseRepository
{
    public CourseRepository(ApplicationContext context) : base(context)
    {
    }
}