namespace BookSharing.Domain.Enums;

///<summary>
///When a book is added with a non-existent author,
///it should be displayed as well on My Books tab and have a status below "pending approval"
///</summary>
public enum UploadBookStatus
{
    Draft,
    Approved
}