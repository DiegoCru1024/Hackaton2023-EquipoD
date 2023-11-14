namespace Application.Exceptions;

public class ValidationException : Exception
{
    public IDictionary<string, string[]> Errors { get; private set; }

    public ValidationException() : base("Uno o más errores ocurrieron")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public ValidationException(IDictionary<string, string[]> errors )
        : base("Uno o más errores ocurrieron")
    {
        this.Errors = errors;
    }

}