using FluentValidation;
using Pizza.Api.Models.SaveModel;

namespace Pizza.Api.Validations
{
    public class SaveCommandModelValidator : AbstractValidator<SaveCommandModel>
    {
        public SaveCommandModelValidator()
        {
            RuleFor(cde => cde.Client.Nom_Cli)
                .NotEmpty()
                .MaximumLength(25)
                .WithMessage("Votre nom est obligatoire pour effectuer une commande");

            RuleFor(cde => cde.Client.Adresse)
                .NotEmpty()
                .When(cde => !cde.Livre_Emporte)
                .WithMessage("Une adresse est obligatoire pour la livraison");

            RuleFor(cde => cde.Ligne_Commandes)
                .NotNull()
                .NotEmpty()
                .WithMessage("Veuillez commander au moins une pizza afin de pouvoir enregisitrer une commande");
        }

    }
}
