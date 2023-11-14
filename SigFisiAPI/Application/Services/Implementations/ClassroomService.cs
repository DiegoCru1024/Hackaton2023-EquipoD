using Application.Repositories;

namespace Application.Services.Implementations;

public class ClassroomService : IClassroomService
{
    private readonly IUnitOfWork _unitOfWork;

    public ClassroomService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}