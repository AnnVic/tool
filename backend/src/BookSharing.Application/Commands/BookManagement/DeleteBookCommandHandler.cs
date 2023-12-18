using BookSharing.Contracts.Interfaces.Repositories;
using BookSharing.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSharing.Application.Commands.BookManagement;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
{
    private readonly IBaseRepository<Book> _bookRepository;

    public DeleteBookCommandHandler(IBaseRepository<Book> bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book=_bookRepository.FindByCondition(b=>b.Id==request.Id).FirstOrDefault();
        _bookRepository.DeleteAsync(book);
        _bookRepository.SaveAsync();
        return Unit.Value;
    }
}
