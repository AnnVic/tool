using BookSharing.Domain.Entities;
using BookSharing.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSharing.Application.Models;

public class UpdateBookModel
{
    public string Title { get; set; }
    public LanguageEnum Language { get; set; }
    public DateTime PublicationDate { get; set; }

    public ICollection<string> Authors { get; set; }
    public ICollection<string> Genres { get; set; }
}
