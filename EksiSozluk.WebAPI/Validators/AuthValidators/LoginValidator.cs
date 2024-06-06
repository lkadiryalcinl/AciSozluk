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
                .EmailAddress().WithMessage("email formatı yanlış") 
                .MinimumLength(11).WithMessage("en az 11 karakter olmalı")
                .MaximumLength(40).WithMessage("en fazla 40 karakter olmalı");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("şifre kısmı boş olamaz.")
                .MinimumLength(8).WithMessage("en az 8 karakter olmalı")
                .MaximumLength(40).WithMessage("en fazla 40 karakter olmalı");
        }
    }
}
