namespace BookSharing.Domain.Enums;

///<summary>
///The filtering box 'Status' contain: 
///Status checkboxes - when the checkbox is checked the book list is filtered by the current status.
///When user is on the Book Sharing page Then user sees checkbox inputs for:
///Status: Free - book is ready to be assigned. Busy - book is assigned to another user.
///</summary>
public enum BookAvailabilityStatus
{
    Free,
    Busy
}