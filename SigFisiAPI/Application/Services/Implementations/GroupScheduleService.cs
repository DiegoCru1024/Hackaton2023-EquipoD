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

    public async Task<IEnumerable<GetGroupSchedule>> GetAllSchedules()
    {
        var schedules = await _unitOfWork.GroupSchedules.GetAllAsync();
        return _mapper.Map<List<GetGroupSchedule>>(schedules);
    }

    public async Task<IEnumerable<GetGroupSchedule>> GetUnavailableSchedules(int groupNumber, int semester)
    {
        var unavailableSchedules = await _unitOfWork.GroupSchedules.GetUnavailableSchedulesAsync(groupNumber, semester);

        return _mapper.Map<List<GetGroupSchedule>>(unavailableSchedules);
    }

    public async Task<IEnumerable<GetGroupSchedule>> GetSchedulesWithoutClassroom()
    {
        var schedules = (await _unitOfWork.GroupSchedules.GetSchedulesWithoutClassroom())
            .OrderBy(x => x.GroupId)
            .ThenBy(x => x.Group.Course)
            .ThenBy(x => x.Group.Number);
        return _mapper.Map<List<GetGroupSchedule>>(schedules);
    }
}