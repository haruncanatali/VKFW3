using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VKFW3.Application.Books.Queries.Dtos;
using VKFW3.Application.Common.Interfaces;

namespace VKFW3.Application.Books.Queries.GetBook;

public class GetBookQueryHandler : IRequestHandler<GetBookQuery,BookDto>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetBookQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BookDto> Handle(GetBookQuery request, CancellationToken cancellationToken)
    {
        return await _context.Books
            .Where(c => c.Id == request.Id)
            .ProjectTo<BookDto>(_mapper.ConfigurationProvider)
            .FirstAsync(cancellationToken);
    }
}