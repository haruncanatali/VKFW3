using MediatR;
using Microsoft.EntityFrameworkCore;
using VKFW3.Application.Common.Interfaces;
using VKFW3.Domain.Entities;

namespace VKFW3.Application.Books.Commands.UpdateBookCommand;

public class UpdateBookCommand : IRequest<Unit>
{
    public long Id { get; set; }
    public string ISBN { get; set; }
    public string Name { get; set; }
    public int PageCount { get; set; }
    public DateTime PublishedDate { get; set; }
    
    public class Handler : IRequestHandler<UpdateBookCommand,Unit>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            Book? book = await _context.Books
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (book != null)
            {
                book.Name = request.Name;
                book.PageCount = request.PageCount;
                book.PublishedDate = request.PublishedDate;
                book.ISBN = request.ISBN;

                _context.Books.Update(book);
                
                await _context.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}