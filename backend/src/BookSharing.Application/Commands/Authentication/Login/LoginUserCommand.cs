using MediatR;

namespace BookSharing.Application.Commands;

public record LoginUserCommand: IRequest<string>
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
