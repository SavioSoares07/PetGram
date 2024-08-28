using FluentValidation;
using PetGramAPi.Communication.Request;

namespace PetGramAPi.Communication.Excepetion
{
    public class AccountExcpetion : AbstractValidator <RequestAccount>
    {
        public AccountExcpetion()
        {
            RuleFor(x => x.User).NotEmpty().WithMessage("Informe o nome de usuário");
            RuleFor(x => x.PetName).NotEmpty().WithMessage("Informe o nome do pet");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Informe um email válido")
                .EmailAddress().WithMessage("O formato do email é inválido");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Informe a senha")
                .MinimumLength(8).WithMessage("A senha deve ter no mínimo 8 caracteres")
                .Matches("[A-Z]").WithMessage("A senha deve conter pelo menos uma letra maiúscula")
                .Matches("[a-z]").WithMessage("A senha deve conter pelo menos uma letra minúscula")
                .Matches("[0-9]").WithMessage("A senha deve conter pelo menos um número");


        }
    }
}
