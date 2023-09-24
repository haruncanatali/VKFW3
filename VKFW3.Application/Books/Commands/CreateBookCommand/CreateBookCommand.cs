using MediatR;
using VKFW3.Application.Common.Interfaces;
using VKFW3.Domain.Entities;

namespace VKFW3.Application.Books.Commands.CreateBookCommand;

public class CreateBookCommand : IRequest<Unit>
{
    public string ISBN { get; set; }
    public string Name { get; set; }
    public int PageCount { get; set; }
    public DateTime PublishedDate { get; set; }
    
    public class Handler : IRequestHandler<CreateBookCommand,Unit>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            await _context.Books.AddAsync(new Book
            {
                ISBN = request.ISBN,
                Name = request.Name,
                PageCount = request.PageCount,
                PublishedDate = request.PublishedDate
            }, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}