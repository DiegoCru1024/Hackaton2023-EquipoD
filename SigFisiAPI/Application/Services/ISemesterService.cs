using Application.Contracts.Semester;

namespace Application.Services;

public interface ISemesterService
{
    Task<GetSemester> CreateSemesterAsync(CreateSemester createSemester);
    Task<GetSemester> GetSemesterAsync(int id);
    Task<IEnumerable<GetSemester>> GetAllSemestersAsync();
}