using BookSharing.Domain.Enums;
using BookSharingApi.Constants;
using BookSharingApi.DTO;
using BookSharingApi.Validators;
using FluentValidation.TestHelper;

namespace BookSharingApi.Tests.Validators;

public class UploadBookDtoValidatorTests
{
    private readonly UploadBookDtoValidator _validator;

    public UploadBookDtoValidatorTests()
    {
        _validator = new UploadBookDtoValidator();
    }

    //Title Tests

    [Fact]
    public void Title_WithValidData_ReturnsNoError()
    {
        // Arrange
        var request = new UploadBookDto { Title = "Valid Title 1" };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Title);
    }

    [Fact]
    public void Title_WithEmptyString_ReturnsError()
    {
        // Arrange
        var request = new UploadBookDto { Title = "" };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Title)
            .WithErrorMessage(UploadBookValidationErrorMessages.TitleRequired);
    }

    [Fact]
    public void Title_WithLengthOutOfBounds_ReturnsError()
    {
        // Arrange
        var request = new UploadBookDto { Title = new string('a', 71) };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Title)
            .WithErrorMessage(UploadBookValidationErrorMessages.TitleInvalidLength);
    }

    [Fact]
    public void Title_WithInvalidCharacters_ReturnsError()
    {
        // Arrange
        var request = new UploadBookDto { Title = "Invalid@Title" };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Title)
            .WithErrorMessage(UploadBookValidationErrorMessages.TitleInvalidCharacters);
    }

    // Language Tests

    [Fact]
    public void Language_WithValidEnumValue_ReturnsNoError()
    {
        // Arrange
        var request = new UploadBookDto { Language = LanguageEnum.English };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Language);
    }

    [Fact]
    public void Language_WithInvalidEnumValue_ReturnsError()
    {
        // Arrange
        var request = new UploadBookDto { Language = (LanguageEnum)999 }; // Invalid enum value

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Language)
            .WithErrorMessage(UploadBookValidationErrorMessages.LanguageInvalid);
    }

    // PublicationDate Tests

    [Fact]
    public void PublicationDate_WithValidDate_ReturnsNoError()
    {
        // Arrange
        var request = new UploadBookDto { PublicationDate = DateTime.Today.AddDays(-1) };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.PublicationDate);
    }

    [Fact]
    public void PublicationDate_InTheFuture_ReturnsError()
    {
        // Arrange
        var futureDate = DateTime.Today.AddDays(2); // A date that will always be in the future
        var request = new UploadBookDto { PublicationDate = futureDate };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.PublicationDate)
            .WithErrorMessage(UploadBookValidationErrorMessages.PublicationDateInFuture);
    }
}