using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VKFW3.Application.Books.Queries.Dtos;
using VKFW3.Application.Common.Interfaces;

namespace VKFW3.Application.Books.Queries.GetBooks;

public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery,List<BookDto>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetBooksQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<BookDto>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        
        // Örneğin ; 
        // (request.Name == null || c.Name.ToLower().Contains(request.Name.ToLower()))
        // requestteki Name propertysi boş ise hepsi, değil ise filtreler.
        
        
        return await _context.Books
            .Where(c =>
                (request.Name == null || c.Name.ToLower().Contains(request.Name.ToLower())) &&
                (request.ISBN == null || c.ISBN.ToLower().Contains(request.ISBN.ToLower())) &&
                (request.PageCount == null || c.PageCount == request.PageCount) &&
                (request.PublishedDate == null || c.PublishedDate.Date == request.PublishedDate.Value.Date))
            .ProjectTo<BookDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}