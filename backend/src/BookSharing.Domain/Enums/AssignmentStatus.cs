namespace BookSharing.Domain.Enums;

///<summary>
///Assignment:
///By default a book is assigned for 14 days
/// 
/// Assignment can have the following statuses: ACTIVE, PENDING, COMPLETED, QUEUED, REJECTED
/// User can have only 2 ACTIVE Assignments in the same range of time
/// Only 1 PENDING Assignment is allowed (waiting for approval from Admin)
///</summary>
public enum AssignmentStatus
{
    Pending,
    Active,
    Completed,
    Queued,
    Rejected
}