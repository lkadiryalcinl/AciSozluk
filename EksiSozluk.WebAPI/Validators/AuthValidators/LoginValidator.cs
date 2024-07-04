using EksiSozluk.Application.Dtos.AuthDtos;
using FluentValidation;

namespace EksiSozluk.WebAPI.Validators.AuthValidators
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("email kısmı boş olamaz.")
                .NotNull().WithMessage("email kısmı boş olamaz.")
                .MinimumLength(11).WithMessage("en az 11 karakter olmalı")
                .MaximumLength(40).WithMessage("en fazla 40 karakter olmalı")
                .Matches(@"^[\w\.\-çÇğĞıİöÖşŞüÜ]+@[\w\.\-çÇğĞıİöÖşŞüÜ]+\.[\w\.\-çÇğĞıİöÖşŞüÜ]+$").WithMessage("email formatı yanlış (Türkçe karakterlere izin verildi)");


            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("şifre kısmı boş olamaz.")
                .MinimumLength(8).WithMessage("en az 8 karakter olmalı")
                .MaximumLength(40).WithMessage("en fazla 40 karakter olmalı");
        }
    }
}
