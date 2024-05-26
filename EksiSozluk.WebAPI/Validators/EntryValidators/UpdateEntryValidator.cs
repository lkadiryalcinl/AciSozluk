using EksiSozluk.Application.Mediator.Commands.ProfileEntryCommands;
using FluentValidation;

namespace EksiSozluk.WebAPI.Validators.EntryValidators
{
    public class UpdateEntryValidator : AbstractValidator<UpdateProfileEntryCommand>
    {
        public UpdateEntryValidator()
        {
            RuleFor(x => x.EntryContent)
                .NotEmpty().NotNull().WithMessage("içerik kısmı boş olamaz.");
        }
    }
}
