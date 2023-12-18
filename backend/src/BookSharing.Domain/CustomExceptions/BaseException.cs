using System.Runtime.Serialization;

namespace BookSharing.Domain.CustomExceptions;

[Serializable]
public class BaseException : Exception
{
    public ErrorCode ErrorCode { get; }

    public BaseException(ErrorCode errorCode)
    {
        ErrorCode = errorCode;
    }

    public BaseException(string? message, ErrorCode errorCode) : base(message)
    {
        ErrorCode = errorCode;
    }

    public BaseException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected BaseException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public BaseException()
    {
    }
}