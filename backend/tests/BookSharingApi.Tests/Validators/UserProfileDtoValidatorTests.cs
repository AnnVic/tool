using BookSharingApi.Constants;
using BookSharingApi.DTO;
using BookSharingApi.Validators;
using FluentValidation.TestHelper;

namespace BookSharingApi.Tests.Validators;

public class UserProfileDtoValidatorTests
{
    private readonly UserProfileDtoValidator _validator;

    public UserProfileDtoValidatorTests()
    {
        _validator = new UserProfileDtoValidator();
    }

    [Fact]
    public void FirstName_WithLengthOutOfBounds_ReturnsError()
    {
        // Arrange
        var request = new UserProfileDto { FirstName = new string('a', 31) };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.FirstName)
            .WithErrorMessage(AuthentificationValidationErrorMessages.FirstNameInvalidLength);
    }

    [Fact]
    public void FirstName_WithValidCharacters_ReturnsNoError()
    {
        // Arrange
        var request = new UserProfileDto { FirstName = "John" };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.FirstName);
    }

    [Fact]
    public void FirstName_WithInvalidCharacters_ReturnsError()
    {
        // Arrange
        var request = new UserProfileDto { FirstName = "John123" };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.FirstName)
            .WithErrorMessage(AuthentificationValidationErrorMessages.FirstNameInvalidCharacters);
    }

    [Fact]
    public void FirstName_WithEmptyString_ReturnsError()
    {
        // Arrange
        var request = new UserProfileDto { FirstName = "" };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.FirstName);
    }

    // Tests for LastName boundary cases, valid and invalid characters, and empty values

    [Fact]
    public void LastName_WithLengthOutOfBounds_ReturnsError()
    {
        // Arrange
        var request = new UserProfileDto { LastName = new string('a', 31) };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.LastName)
            .WithErrorMessage(AuthentificationValidationErrorMessages.LastNameInvalidLength);
    }

    [Fact]
    public void LastName_WithValidCharacters_ReturnsNoError()
    {
        // Arrange
        var request = new UserProfileDto { LastName = "Smith" };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.LastName);
    }

    [Fact]
    public void LastName_WithInvalidCharacters_ReturnsError()
    {
        // Arrange
        var request = new UserProfileDto { LastName = "Smith123" };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.LastName)
            .WithErrorMessage(AuthentificationValidationErrorMessages.LastNameInvalidCharacters);
    }

    [Fact]
    public void LastName_WithEmptyString_ReturnsError()
    {
        // Arrange
        var request = new UserProfileDto { LastName = "" };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.LastName);
    }

    // Tests for UserName boundary cases, valid and invalid characters, and null/empty values

    [Fact]
    public void UserName_WithValidData_ReturnsNoError()
    {
        // Arrange
        var request = new UserProfileDto { UserName = "User123" };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.UserName);
    }

    [Fact]
    public void UserName_WithLengthOutOfBounds_ReturnsError()
    {
        // Arrange
        var request = new UserProfileDto { UserName = new string('a', 31) };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.UserName)
            .WithErrorMessage(AuthentificationValidationErrorMessages.UserNameInvalidLength);
    }

    [Fact]
    public void UserName_WithInvalidCharacters_ReturnsError()
    {
        // Arrange
        var request = new UserProfileDto { UserName = "User@" };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.UserName)
            .WithErrorMessage(AuthentificationValidationErrorMessages.UserNameInvalidCharacters);
    }

    [Fact]
    public void UserName_WithEmptyString_ReturnsError()
    {
        // Arrange
        var request = new UserProfileDto { UserName = "" };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.UserName)
            .WithErrorMessage(AuthentificationValidationErrorMessages.UserNameRequired);
    }

    [Fact]
    public void UserName_WithNullValue_ReturnsError()
    {
        // Arrange
        var request = new UserProfileDto { UserName = null };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.UserName)
            .WithErrorMessage(AuthentificationValidationErrorMessages.UserNameRequired);
    }

    [Fact]
    public void Register_WithValidData_ReturnsOk()
    {
        // Arrange
        var request = new UserProfileDto()
        {
            FirstName = "Seraphina-Alexandri' Valentina",
            LastName = "Evergreen O'Malley-Smithington",
            UserName = "Evergreen O'Malley-Smithington",
            Email = "SEvergreen@yahoo.com",
        };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    // Tests for Email format validation

    [Fact]
    public void Email_WithValidFormat_ReturnsNoError()
    {
        // Arrange
        var request = new UserProfileDto { Email = "test@example.com" };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Email);
    }

    [Fact]
    public void Email_WithInvalidFormat_ReturnsError()
    {
        // Arrange
        var request = new UserProfileDto { Email = "invalidemail" };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Email)
            .WithErrorMessage(AuthentificationValidationErrorMessages.EmailInvalidFormat);
    }

    [Fact]
    public void Email_WithEmptyString_ReturnsError()
    {
        // Arrange
        var request = new UserProfileDto { Email = "" };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Email)
            .WithErrorMessage(AuthentificationValidationErrorMessages.EmailRequired);
    }

    [Fact]
    public void Email_WithNullValue_ReturnsError()
    {
        // Arrange
        var request = new UserProfileDto { Email = null };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Email)
            .WithErrorMessage(AuthentificationValidationErrorMessages.EmailRequired);
    }
}