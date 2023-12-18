using BookSharing.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSharing.Application.Commands.BookManagement;

public record DeleteBookCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
