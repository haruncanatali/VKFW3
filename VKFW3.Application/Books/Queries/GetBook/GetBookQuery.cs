using MediatR;
using VKFW3.Application.Books.Queries.Dtos;

namespace VKFW3.Application.Books.Queries.GetBook;

public class GetBookQuery : IRequest<BookDto>
{
    public long Id { get; set; }
}