namespace BookSharing.Domain.Enums;

///<summary>
/// Pending - represents the fact that approval is awaited from the admin for extending the deadline
///</summary>
public enum DeadlineExtensionStatus
{
    Pending,
    Approved
}