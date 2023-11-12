using Application.Repositories;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Persistence.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationContext _context;
    public IClassroomRepository Classrooms { get; set; }
    public IDayRepository Days { get; set; }
    public IGroupRepository Groups { get; set; }
    public IGroupScheduleRepository GroupSchedules { get; set; }
    public ISemesterRepository Semesters { get; set; }

    public UnitOfWork(ApplicationContext context)
    {
        _context = context;
        Classrooms = new ClassroomRepository(context);
        Days = new DayRepository(context);
        Groups = new GroupRepository(context);
        GroupSchedules = new GroupScheduleRepository(context);
        Semesters = new SemesterRepository(context);
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
    private bool _disposed;
    private void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        _disposed = true;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}