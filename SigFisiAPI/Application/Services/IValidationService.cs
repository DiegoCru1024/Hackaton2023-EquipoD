namespace Application.Services;

public interface IValidationService
{
    void EnsureValid<T>(T obj);
}