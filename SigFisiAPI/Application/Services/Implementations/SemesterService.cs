using Application.Contracts.Group;
using Application.Contracts.Semester;
using Application.Exceptions;
using Application.Repositories;
using Domain;

namespace Application.Services.Implementations;

public class SemesterService : ISemesterService
{
    private readonly IUnitOfWork _unitOfWork;

    public SemesterService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetSemester> CreateSemesterAsync(CreateSemester createSemester)
    {
        var semester = new Semester
        {
            Code = createSemester.Code,
            StartDate = createSemester.StartDate,
            EndDate = createSemester.EndDate,
            IsActive = true
        };

        var newSemester = await _unitOfWork.Semesters.AddAsync(semester);

        await _unitOfWork.CommitAsync();

        return new GetSemester()
        {
            Id = newSemester.Id,
            Code = newSemester.Code,
            StartDate = newSemester.StartDate,
            EndDate = newSemester.EndDate,
            IsActive = newSemester.IsActive
        };
    }

    public async Task<GetSemester> GetSemesterAsync(int id)
    {
        var semester = await _unitOfWork.Semesters.GetByIdAsync(id);

        if (semester == null)
        {
            throw new AppException("No se encontro la el grupo");
        }

        return new GetSemester()
        {
            Id = semester.Id,
            Code = semester.Code,
            StartDate = semester.StartDate,
            EndDate = semester.EndDate,
            IsActive = semester.IsActive
        };
    }

    public async Task<IEnumerable<GetSemester>> GetAllSemestersAsync()
    {
        var semesters = await _unitOfWork.Semesters.GetAllAsync();
        return semesters.Select(x => new GetSemester()
        {
            Id = x.Id,
            Code = x.Code,
            StartDate = x.StartDate,
            EndDate = x.EndDate,
            IsActive = x.IsActive
        });
    }
}