using BookSharing.Contracts.Interfaces.Repositories;
using BookSharing.Contracts.Interfaces.Services;
using BookSharing.Domain.Enums;
using MediatR;

namespace BookSharing.Application.Commands.Assignment;

public class AddAssignmentCommandHandler : IRequestHandler<AddAssignmentCommand, Unit>
{
    private readonly IBaseRepository<Domain.Entities.Assignment> _repo;
    private readonly IBaseRepository<Domain.Entities.Book> _bookRepository;
    private readonly IUserInfo _userInfoService;

    public AddAssignmentCommandHandler(
        IBaseRepository<Domain.Entities.Assignment> repo,
        IUserInfo userInfoService,
        IBaseRepository<Domain.Entities.Book> bookRepository)
    {
        _repo = repo;
        _userInfoService = userInfoService;
        _bookRepository = bookRepository;
    }

    public async Task<Unit> Handle(AddAssignmentCommand request, CancellationToken cancellationToken)
    {
        var userIdString = _userInfoService.GetUserId();
        Guid.TryParse(userIdString, out var userIdGuid);

        var assignment = new Domain.Entities.Assignment
        {
            UserId = userIdGuid,
            BookId = request.BookId,
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow.AddDays(14),
            Status = AssignmentStatus.Pending
        };

        await _repo.CreateAsync(assignment);
        await _repo.SaveAsync();

        var assignedBook = _bookRepository
            .FindByCondition(book => book.Id == request.BookId)
            .FirstOrDefault();

        if (assignedBook != null)
        {
            assignedBook.AvailabilityStatus = BookAvailabilityStatus.Busy;
            _bookRepository.UpdateAsync(assignedBook);
            await _bookRepository.SaveAsync();
        }

        return Unit.Value;
    }
}