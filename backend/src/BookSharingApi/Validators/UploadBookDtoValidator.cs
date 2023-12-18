using BookSharingApi.Constants;
using BookSharingApi.DTO;
using FluentValidation;

namespace BookSharingApi.Validators;

public class UploadBookDtoValidator : AbstractValidator<UploadBookDto>
{
    public UploadBookDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage(UploadBookValidationErrorMessages.TitleRequired)
            .Length(1, 70).WithMessage(UploadBookValidationErrorMessages.TitleInvalidLength)
            .Matches("^[a-zA-Z0-9\\s.,?!:;\\-(){}\\[\\]'\"]+$")
            .WithMessage(UploadBookValidationErrorMessages.TitleInvalidCharacters);

        RuleFor(x => x.Language)
            .NotEmpty().WithMessage(UploadBookValidationErrorMessages.LanguageRequired)
            .IsInEnum().WithMessage(UploadBookValidationErrorMessages.LanguageInvalid);

        RuleFor(x => x.PublicationDate)
            .NotEmpty().WithMessage(UploadBookValidationErrorMessages.PublicationDateRequired)
            .LessThanOrEqualTo(DateTime.Today).WithMessage(UploadBookValidationErrorMessages.PublicationDateInFuture);
    }
}