using EksiSozluk.Application.Dtos.AuthDtos;
using FluentValidation;

namespace EksiSozluk.WebAPI.Validators.AuthValidators
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().NotNull().WithMessage("email kısmı boş olamaz.")
                .EmailAddress().WithMessage("email formatı yanlış")
                .MinimumLength(11).WithMessage("en az 11 karakter olmalı")
                .MaximumLength(40).WithMessage("en fazla 40 karakter olmalı");
            RuleFor(x => x.Gender)
                .NotEmpty().NotNull().WithMessage("cinsiyet kısmı boş olamaz.");
            RuleFor(x => x.BirthDate)
                .NotEmpty().NotNull().WithMessage("doğum tarihi kısmı boş olamaz.");
            RuleFor(x=>x.UserName)
                .NotEmpty().NotNull().WithMessage("nick kısmı boş olamaz.")
                .MinimumLength(11).WithMessage("en az 5 karakter olmalı")
                .MaximumLength(40).WithMessage("en fazla 40 karakter olmalı");
            RuleFor(x => x.Password)
                .NotEmpty().NotNull().WithMessage("şifre kısmı boş olamaz.")
                .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[A-Za-z\\d]{8,}$")
                .WithMessage("şifre en az 8 karakter\r\nen az bir büyük harf\r\nbir küçük harf\r\nrakam içermelidir.");
            RuleFor(x => x.PasswordAgain)
                .NotEmpty().NotNull().WithMessage("şifre tekrar kısmı boş olamaz.")
                .Equal(x => x.Password);
            RuleFor(x => x.isAggrCheck)
                .NotEmpty().NotNull().WithMessage("anlaşma kabul edilmeli");
        }
    }
}
