using MediatR;
using VKFW3.Application.Books.Queries.Dtos;

namespace VKFW3.Application.Books.Queries.GetBooks;

public class GetBooksQuery : IRequest<List<BookDto>>
{
    public string? ISBN { get; set; }
    public string? Name { get; set; }
    public int? PageCount { get; set; }
    public DateTime? PublishedDate { get; set; }
}