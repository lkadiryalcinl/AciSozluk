using EksiSozluk.Application.Mediator.Commands.EntryCommands;
using FluentValidation;

namespace EksiSozluk.WebAPI.Validators.EntryValidators
{
    public class CreateEntryValidator : AbstractValidator<CreateEntryCommand>
    {
        public CreateEntryValidator()
        {
            RuleFor(x => x.EntryContent)
                .NotEmpty().NotNull().WithMessage("içerik kısmı boş olamaz.");
        }
    }
}
