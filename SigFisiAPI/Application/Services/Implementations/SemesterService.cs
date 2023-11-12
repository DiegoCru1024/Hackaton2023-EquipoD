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

    public async Task<GetSemester> CreateSemesterAsync(CreateSemester model)
    {
        var semester = new Semester
        {
            Code = model.Code,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
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

    public async Task<GetSemester> UpdateSemesterAsync(int id, UpdateSemester model)
    {
        var semester = await _unitOfWork.Semesters.GetByIdAsync(id);

        if (semester == null)
        {
            throw new AppException("No se encontro la el grupo");
        }

        semester.Code = model.Code;
        semester.StartDate = model.StartDate;
        semester.EndDate = model.EndDate;

        var updatedSemester = await _unitOfWork.Semesters.UpdateAsync(semester);

        await _unitOfWork.CommitAsync();

        return new GetSemester()
        {
            Id = updatedSemester.Id,
            Code = updatedSemester.Code,
            StartDate = updatedSemester.StartDate,
            EndDate = updatedSemester.EndDate,
            IsActive = updatedSemester.IsActive
        };
    }

    public async Task DeleteSemesterAsync(int id)
    {
        var semester = await _unitOfWork.Semesters.GetByIdAsync(id);

        if (semester == null)
        {
            throw new AppException("No se encontro el semestre");
        }

        var hasGroups = await _unitOfWork.Semesters.HasGroups(id);

        if (hasGroups)
        {
            throw new AppException("No se puede eliminar el semestre porque tiene grupos asociados");
        }

        await _unitOfWork.Semesters.DeleteAsync(semester);

        await _unitOfWork.CommitAsync();
    }

    public async Task DeactivateSemesterAsync(int id)
    {
        var semester = await _unitOfWork.Semesters.GetByIdAsync(id);

        if (semester == null)
        {
            throw new AppException("No se encontro el semestre");
        }

        semester.IsActive = false;

        await _unitOfWork.CommitAsync();
    }

    public async Task ActivateSemesterAsync(int id)
    {
        var semester = await _unitOfWork.Semesters.GetByIdAsync(id);

        if (semester == null)
        {
            throw new AppException("No se encontro el semestre");
        }

        semester.IsActive = true;

        await _unitOfWork.CommitAsync();
    }
}