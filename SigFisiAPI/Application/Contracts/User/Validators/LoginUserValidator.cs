using Application.Contracts.User.DTOs;
using FluentValidation;

namespace Application.Contracts.User.Validators;

public class LoginUserValidator : AbstractValidator<LoginUser>
{
    public LoginUserValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("El email es requerido");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("La contraseña es requerida");
    }
}