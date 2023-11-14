using Application.Contracts.Semester;

namespace Application.Services;

public interface ISemesterService
{
    Task<GetSemester> CreateSemesterAsync(CreateSemester model);
    Task<GetSemester> GetSemesterAsync(int id);
    Task<IEnumerable<GetSemester>> GetAllSemestersAsync();
    Task<GetSemester> UpdateSemesterAsync(int id, UpdateSemester model);
    Task DeleteSemesterAsync(int id);
    Task ActivateSemesterAsync(int id);
}