using FluentValidation;
using ManageUser.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageUser.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia")
                
                .NotNull()
                .WithMessage("A entidade não pode ser nula");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("O nome não pode ser nulo")
                
                .NotEmpty()
                .WithMessage("O nome não pode ser vazio")
                
                .MinimumLength(3)
                .WithMessage("O nome deve possuir mais de 03 caracteres")
                
                .MaximumLength(100)
                .WithMessage("O nome deve ter no máximo 100 caracteres");

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("O email não pode ser nulo")
                
                .NotEmpty()
                .WithMessage("O email não pode ser vazio")
                
                .MinimumLength(3)
                .WithMessage("O nome deve possuir mais de 03 caracteres")
                
                .MaximumLength(180)
                .WithMessage("O nome deve ter no máximo 180 caracteres")
                
                .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")
                .WithMessage("Email inválido");

            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage("A senha não pode ser nulo")

                .NotEmpty()
                .WithMessage("A senha não pode ser vazio")

                .MinimumLength(8)
                .WithMessage("A senha deve ter no mínimo 08 caracteres");
        }
    }
}
