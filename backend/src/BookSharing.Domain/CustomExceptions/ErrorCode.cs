namespace BookSharing.Domain.CustomExceptions;

public enum ErrorCode
{
    InvalidInput = 1001,
    DatabaseError = 1002,
    AuthenticationError = 1003,

    RegistrationUsernameEmailTaken = 2001,
    RegistrationFailed = 2002,

    LoginInvalidCredentials = 3001,
    LoginAccountLocked = 3002,
    LoginFailed = 3003,

    ProfileNotFound = 4001,
    ProfileUpdateFailed = 4002,
    ProfileAccessDenied = 4003
}
