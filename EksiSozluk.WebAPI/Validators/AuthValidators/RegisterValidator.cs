using EksiSozluk.Application.Dtos.AuthDtos;
using FluentValidation;

namespace EksiSozluk.WebAPI.Validators.AuthValidators
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("email kısmı boş olamaz.")
                .NotNull().WithMessage("email kısmı boş olamaz.")
                .MinimumLength(11).WithMessage("en az 11 karakter olmalı")
                .MaximumLength(40).WithMessage("en fazla 40 karakter olmalı")
                .Matches(@"^[\w\.\-çÇğĞıİöÖşŞüÜ]+@[\w\.\-çÇğĞıİöÖşŞüÜ]+\.[\w\.\-çÇğĞıİöÖşŞüÜ]+$").WithMessage("email formatı yanlış (Türkçe karakterlere izin verildi)");

            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("cinsiyet kısmı boş olamaz.")
                .NotNull().WithMessage("cinsiyet kısmı boş olamaz.");

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("doğum tarihi kısmı boş olamaz.")
                .NotNull().WithMessage("doğum tarihi kısmı boş olamaz.");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("nick kısmı boş olamaz.")
                .NotNull().WithMessage("nick kısmı boş olamaz.")
                .MinimumLength(5).WithMessage("en az 5 karakter olmalı")
                .MaximumLength(40).WithMessage("en fazla 40 karakter olmalı");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("şifre kısmı boş olamaz.")
                .NotNull().WithMessage("şifre kısmı boş olamaz.")
                .Matches(@"^(?=.*[a-zA-ZçÇğĞıİöÖşŞüÜ])(?=.*[A-ZçÇğĞıİöÖşŞüÜ])(?=.*\d)[A-Za-zçÇğĞıİöÖşŞüÜ\d]{8,}$")
                .WithMessage("şifre en az 8 karakter\nen az bir büyük harf\nbir küçük harf\nrakam içermelidir.");

            RuleFor(x => x.PasswordAgain)
                .NotEmpty().WithMessage("şifre tekrar kısmı boş olamaz.")
                .NotNull().WithMessage("şifre tekrar kısmı boş olamaz.")
                .Equal(x => x.Password).WithMessage("şifreler eşleşmiyor");

            RuleFor(x => x.isAggrCheck)
                .NotEmpty().WithMessage("anlaşma kabul edilmeli")
                .NotNull().WithMessage("anlaşma kabul edilmeli");
        }
    }
}
