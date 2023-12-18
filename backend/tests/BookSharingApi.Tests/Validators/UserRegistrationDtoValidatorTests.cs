using BookSharingApi.Constants;
using BookSharingApi.DTO;
using BookSharingApi.Validators;
using FluentValidation.TestHelper;

namespace BookSharingApi.Tests.Validators;

public class UserRegistrationDtoValidatorTests
{
    private readonly UserRegistrationDtoValidator _validator;

    public UserRegistrationDtoValidatorTests()
    {
        _validator = new UserRegistrationDtoValidator();
    }

    // Tests for FirstName boundary cases, valid and invalid characters, and empty values

    [Fact]
    public void FirstName_WithLengthOutOfBounds_ReturnsError()
    {
        // Arrange
        var request = new UserRegistrationDto { FirstName = new string('a', 31) };

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
        var request = new UserRegistrationDto { FirstName = "John" };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.FirstName);
    }

    [Fact]
    public void FirstName_WithInvalidCharacters_ReturnsError()
    {
        // Arrange
        var request = new UserRegistrationDto { FirstName = "John123" };

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
        var request = new UserRegistrationDto { FirstName = "" };

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
        var request = new UserRegistrationDto { LastName = new string('a', 31) };

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
        var request = new UserRegistrationDto { LastName = "Smith" };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.LastName);
    }

    [Fact]
    public void LastName_WithInvalidCharacters_ReturnsError()
    {
        // Arrange
        var request = new UserRegistrationDto { LastName = "Smith123" };

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
        var request = new UserRegistrationDto { LastName = "" };

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
        var request = new UserRegistrationDto { UserName = "User123" };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.UserName);
    }

    [Fact]
    public void UserName_WithLengthOutOfBounds_ReturnsError()
    {
        // Arrange
        var request = new UserRegistrationDto { UserName = new string('a', 31) };

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
        var request = new UserRegistrationDto { UserName = "User@" };

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
        var request = new UserRegistrationDto { UserName = "" };

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
        var request = new UserRegistrationDto { UserName = null };

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
        var request = new UserRegistrationDto()
        {
            FirstName = "Seraphina-Alexandri' Valentina",
            LastName = "Evergreen O'Malley-Smithington",
            UserName = "Evergreen O'Malley-Smithington",
            Email = "SEvergreen@yahoo.com",
            Password = "A$a1",
            PasswordConfirmation = "A$a1"
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
        var request = new UserRegistrationDto { Email = "test@example.com" };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Email);
    }

    [Fact]
    public void Email_WithInvalidFormat_ReturnsError()
    {
        // Arrange
        var request = new UserRegistrationDto { Email = "invalidemail" };

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
        var request = new UserRegistrationDto { Email = "" };

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
        var request = new UserRegistrationDto { Email = null };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Email)
            .WithErrorMessage(AuthentificationValidationErrorMessages.EmailRequired);
    }

    [Fact]
    public void Password_WithValidComplexity_ReturnsNoError()
    {
        // Arrange
        var request = new UserRegistrationDto { Password = "ValidPass1!" };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Password);
    }

    [Fact]
    public void Password_WithLengthOutOfBounds_ReturnsError()
    {
        // Arrange
        var request = new UserRegistrationDto
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
        var request = new UserRegistrationDto { Password = "lowercase1!" };

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
        var request = new UserRegistrationDto { Password = "UPPERCASE1!" };

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
        var request = new UserRegistrationDto { Password = "NoDigit!" };

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
        var request = new UserRegistrationDto { Password = "NoSpecial1" };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Password)
            .WithErrorMessage(AuthentificationValidationErrorMessages.PasswordRequiresSpecialCharacter);
    }

    [Fact]
    public void PasswordConfirmation_MatchingPassword_ReturnsNoError()
    {
        // Arrange
        var request = new UserRegistrationDto { Password = "Valid1!", PasswordConfirmation = "Valid1!" };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.PasswordConfirmation);
    }

    [Fact]
    public void PasswordConfirmation_NotMatchingPassword_ReturnsError()
    {
        // Arrange
        var request = new UserRegistrationDto { Password = "Valid1!", PasswordConfirmation = "Different1!" };

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.PasswordConfirmation)
            .WithErrorMessage(AuthentificationValidationErrorMessages.PasswordConfirmationMustMatch);
    }
}