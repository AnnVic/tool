using MediatR;

namespace BookSharing.Application.Commands.Author;

public class AddAuthorCommand : IRequest<Unit>
{
    public string Name { get; set; }  
}
