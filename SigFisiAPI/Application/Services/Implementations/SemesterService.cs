using Application.Contracts.Group;
using Application.Contracts.Semester;
using Application.Exceptions;
using Application.Repositories;
using AutoMapper;
using Domain;

namespace Application.Services.Implementations;

public class SemesterService : ISemesterService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SemesterService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetSemester> CreateSemesterAsync(CreateSemester model)
    {
        var semester = _mapper.Map<Semester>(model);

        var newSemester = await _unitOfWork.Semesters.AddAsync(semester);

        await _unitOfWork.CommitAsync();

        return _mapper.Map<GetSemester>(newSemester);
    }

    public async Task<GetSemester> GetSemesterAsync(int id)
    {
        var semester = await _unitOfWork.Semesters.GetByIdAsync(id);

        if (semester == null)
        {
            throw new NotFoundException(nameof(Semester), id);
        }

        return _mapper.Map<GetSemester>(semester);
    }

    public async Task<GetSemester> GetActiveSemesterAsync()
    {
        var semester = await _unitOfWork.Semesters.GetActiveSemester();

        if (semester == null)
        {
            throw new AppException("No hay un semestre activo");
        }

        return _mapper.Map<GetSemester>(semester);
    }

    public async Task<IEnumerable<GetSemester>> GetAllSemestersAsync()
    {
        var semesters = await _unitOfWork.Semesters.GetAllAsync();
        return _mapper.Map<List<GetSemester>>(semesters);
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

        return _mapper.Map<GetSemester>(updatedSemester);
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

        if (semester.IsActive)
        {
            throw new AppException("No se puede eliminar el semestre activo");
        }

        await _unitOfWork.Semesters.DeleteAsync(semester);

        await _unitOfWork.CommitAsync();
    }
    public async Task ActivateSemesterAsync(int id)
    {
        await _unitOfWork.Semesters.SetActiveSemester(id);

        await _unitOfWork.CommitAsync();
    }
}