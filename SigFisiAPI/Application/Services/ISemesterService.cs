using Application.Contracts.Semester;

namespace Application.Services;

public interface ISemesterService
{
    Task<GetSemester> CreateSemesterAsync(CreateSemester createSemester);
    Task<GetSemester> GetSemesterAsync(int id);
    Task<IEnumerable<GetSemester>> GetAllSemestersAsync();
    Task<GetSemester> UpdateSemesterAsync(int id, UpdateSemester updateSemester);
    Task DeleteSemesterAsync(int id);
    Task DeactivateSemesterAsync(int id);
    Task ActivateSemesterAsync(int id);
}