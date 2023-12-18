using BookSharingApi.Constants;
using BookSharingApi.DTO;
using BookSharingApi.Validators;
using FluentValidation.TestHelper;

namespace BookSharingApi.Tests.Validators;

public class UserLoginDtoValidatorTests
{
    private readonly UserLoginDtoValidator _validator;

    public UserLoginDtoValidatorTests()
    {
        _validator = new UserLoginDtoValidator();
    }

    // Tests for UserName boundary cases, valid and invalid characters, and null/empty values

    [Fact]
    public void UserName_WithValidData_ReturnsNoError()
    {
        // Arrange
        var request = new UserLoginDto { UserName = "User123" };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.UserName);
    }

    [Fact]
    public void UserName_WithLengthOutOfBounds_ReturnsError()
    {
        // Arrange
        var request = new UserLoginDto { UserName = new string('a', 31) };

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
        var request = new UserLoginDto { UserName = "User@" };

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
        var request = new UserLoginDto { UserName = "" };

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
        var request = new UserLoginDto { UserName = null };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.UserName)
            .WithErrorMessage(AuthentificationValidationErrorMessages.UserNameRequired);
    }

    [Fact]
    public void Password_WithValidComplexity_ReturnsNoError()
    {
        // Arrange
        var request = new UserLoginDto { Password = "ValidPass1!" };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Password);
    }

    [Fact]
    public void Password_WithLengthOutOfBounds_ReturnsError()
    {
        // Arrange
        var request = new UserLoginDto
            { Password = "Shrt11111111111111111111111111111111111111111111111111111111!" };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Password)
            .WithErrorMessage(AuthentificationValidationErrorMessages.PasswordInvalidLength);
    }

    [Fact]
    public void Password_WithoutUppercaseLetter_ReturnsError()
    {
        // Arrange
        var request = new UserLoginDto { Password = "lowercase1!" };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Password)
            .WithErrorMessage(AuthentificationValidationErrorMessages.PasswordRequiresUppercase);
    }

    [Fact]
    public void Password_WithoutLowercaseLetter_ReturnsError()
    {
        // Arrange
        var request = new UserLoginDto { Password = "UPPERCASE1!" };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Password)
            .WithErrorMessage(AuthentificationValidationErrorMessages.PasswordRequiresLowercase);
    }

    [Fact]
    public void Password_WithoutDigit_ReturnsError()
    {
        // Arrange
        var request = new UserLoginDto { Password = "NoDigit!" };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Password)
            .WithErrorMessage(AuthentificationValidationErrorMessages.PasswordRequiresDigit);
    }

    [Fact]
    public void Password_WithoutSpecialCharacter_ReturnsError()
    {
        // Arrange
        var request = new UserLoginDto { Password = "NoSpecial1" };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Password)
            .WithErrorMessage(AuthentificationValidationErrorMessages.PasswordRequiresSpecialCharacter);
    }

    [Fact]
    public void Login_WithValidInput_ReturnsNoError()
    {
        // Arrange
        var request = new UserLoginDto() { UserName = "Evergreen O'Malley-Smithington", Password = "A$a1" };

        // Act 
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}