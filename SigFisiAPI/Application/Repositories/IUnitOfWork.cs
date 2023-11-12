namespace Application.Repositories;

public interface IUnitOfWork : IDisposable
{
    IClassroomRepository Classrooms { get; set; }
    IDayRepository Days { get; set; }
    IGroupRepository Groups { get; set; }
    IGroupScheduleRepository GroupSchedules { get; set; }
    ISemesterRepository Semesters { get; set; }
    Task CommitAsync();
}