using Application.Contracts.GroupSchedule;
using Application.Exceptions;
using Application.Repositories;
using AutoMapper;
using Domain;

namespace Application.Services.Implementations;

public class GroupScheduleService : IGroupScheduleService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GroupScheduleService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetGroupSchedule>> GetUnavailableSchedules(int groupNumber, int semester)
    {
        var unavailableSchedules = await _unitOfWork.GroupSchedules.GetUnavailableSchedulesAsync(groupNumber, semester);

        return _mapper.Map<List<GetGroupSchedule>>(unavailableSchedules);
    }
}