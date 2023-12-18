using BookSharing.Contracts.Interfaces.Repositories;
using BookSharing.Contracts.Interfaces.Services;
using BookSharing.Domain.Entities;
using BookSharing.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookSharing.Application.Queries.Assignments;

public class GetUserAssignmentsQueryHandler : IRequestHandler<GetUserAssignmentsQuery, IEnumerable<Assignment>>
{
    private readonly IUserInfo _userInfoService;
    private readonly IBaseRepository<Assignment> _assignmentRepository;

    public GetUserAssignmentsQueryHandler(IUserInfo userInfoService, IBaseRepository<Assignment> assignmentRepository)
    {
        _userInfoService = userInfoService;
        _assignmentRepository = assignmentRepository;
    }

    public async Task<IEnumerable<Assignment>> Handle(GetUserAssignmentsQuery request,
        CancellationToken cancellationToken)
    {
        var currentUserId = _userInfoService.GetUserId();

        if (!Guid.TryParse(currentUserId, out Guid guidUserId))
        {
            return Enumerable.Empty<Assignment>();
        }

        var assignments = await _assignmentRepository
            .FindByCondition(a =>
                a.UserId == guidUserId &&
                (a.Status == AssignmentStatus.Active || a.Status == AssignmentStatus.Pending))
            .Include(a => a.Book)
            .ToListAsync(cancellationToken);

        return assignments;
    }
}