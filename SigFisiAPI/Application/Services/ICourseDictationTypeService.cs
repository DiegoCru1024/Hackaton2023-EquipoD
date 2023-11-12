using Application.Contracts.CourseDictationType;

namespace Application.Services;

public interface ICourseDictationTypeService
{
    Task<IEnumerable<GetCourseDictationType>> SearchCourseDictationTypes(SearchCourseDictationType model);
}