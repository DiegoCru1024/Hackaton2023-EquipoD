using Application.Contracts.User.DTOs;
using FluentValidation;

namespace Application.Contracts.User.Validators;

public class RegisterUserValidation: AbstractValidator<RegisterUser>
{
    public RegisterUserValidation()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("El email es requerido")
            .EmailAddress()
            .WithMessage("Email no válido");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("El nombre es requerido");

        RuleFor(x => x.Surname)
            .NotEmpty()
            .WithMessage("El apellido es requerido");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("La contraseña es requerida")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*])[a-zA-Z\d!@#$%^&*]{8,}$")
            .WithMessage("La contraseña debe tener al menos 8 caracteres, una mayúscula, una minúscula, un número y un caracter especial")
            ;

        RuleFor(x => x.Role)
            .NotEmpty()
            .WithMessage("El rol es requerido");
    }
}