using FluentValidation;
using Pizza.Api.Models.SaveModel;

namespace Pizza.Api.Validations
{
    public class SaveClientModelValidator : AbstractValidator<SaveClientModel>
    {
        public SaveClientModelValidator()
        {
            RuleFor(c => c.Nom_Cli)
                .NotEmpty()
                .MaximumLength(25);

            RuleFor(c => c.Adresse)
                .NotEmpty()
                .WithMessage("Une adresse est obligatoire pour la livraison");

            RuleFor(c => c.Num_Quartier)
                .NotEmpty()
                .WithMessage("Un quartier doit être sélectionné pour la livraison");
        }
    }
}
