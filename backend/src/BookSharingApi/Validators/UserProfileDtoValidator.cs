using BookSharingApi.Constants;
using BookSharingApi.DTO;
using FluentValidation;

namespace BookSharingApi.Validators;

public class UserProfileDtoValidator : AbstractValidator<UserProfileDto>
{
    public UserProfileDtoValidator()
    {
        RuleFor(x => x.FirstName)
            .Length(3, 30).WithMessage(AuthentificationValidationErrorMessages.FirstNameInvalidLength)
            .Matches("^[a-zA-Z\\s\\-\\']+$")
            .WithMessage(AuthentificationValidationErrorMessages.FirstNameInvalidCharacters);

        RuleFor(x => x.LastName)
            .Length(3, 30).WithMessage(AuthentificationValidationErrorMessages.LastNameInvalidLength)
            .Matches("^[a-zA-Z\\s\\-\\']+$")
            .WithMessage(AuthentificationValidationErrorMessages.LastNameInvalidCharacters);

        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage(AuthentificationValidationErrorMessages.UserNameRequired)
            .Length(3, 30).WithMessage(AuthentificationValidationErrorMessages.UserNameInvalidLength)
            .Matches("^[a-zA-Z0-9\\s\\-\\']+$")
            .WithMessage(AuthentificationValidationErrorMessages.UserNameInvalidCharacters);

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(AuthentificationValidationErrorMessages.EmailRequired)
            .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
            .WithMessage(AuthentificationValidationErrorMessages.EmailInvalidFormat);
    }
}