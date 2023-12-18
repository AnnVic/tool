namespace BookSharingApi.Constants;

public static class UploadBookValidationErrorMessages
{
    // Title error messages
    public const string TitleRequired = "Title is required.";
    public const string TitleInvalidLength = "Title must be between 1 and 70 characters.";

    public const string TitleInvalidCharacters =
        "Only alphanumeric characters and punctuation marks are allowed in the title.";

    // NewAuthor error messages
    //public const string NewAuthorInvalidLength = "NewAuthor must be between 7 and 61 characters.";
    //public const string NewAuthorInvalidCharacters = "Only alphabetic characters are allowed in NewAuthor.";

    // Language error messages
    public const string LanguageRequired = "Language is required.";
    public const string LanguageInvalid = "Invalid language. Choose from the specified options.";

    // PublicationDate error messages
    public const string PublicationDateRequired = "PublicationDate is required.";
    public const string PublicationDateInFuture = "PublicationDate cannot be in the future.";
}