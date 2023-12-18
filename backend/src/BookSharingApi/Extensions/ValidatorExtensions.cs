using BookSharingApi.DTO;
using BookSharingApi.Validators;
using FluentValidation;

namespace BookSharingApi.Extensions;

public static class ValidatorExtensions
{
    public static void AddValidationServices(this IServiceCollection services)
    {
        services.AddScoped<IValidator<UserRegistrationDto>, UserRegistrationDtoValidator>();
        services.AddScoped<IValidator<UserLoginDto>, UserLoginDtoValidator>();
        services.AddScoped<IValidator<UserProfileDto>, UserProfileDtoValidator>();
        services.AddScoped<IValidatorFactory, ValidatorFactory>();
    }
}