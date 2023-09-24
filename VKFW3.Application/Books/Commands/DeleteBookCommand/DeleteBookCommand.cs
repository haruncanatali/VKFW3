using MediatR;
using Microsoft.EntityFrameworkCore;
using VKFW3.Application.Common.Interfaces;
using VKFW3.Domain.Entities;

namespace VKFW3.Application.Books.Commands.DeleteBookCommand;

public class DeleteBookCommand : IRequest<Unit>
{
    public long Id { get; set; }
    
    public class Handler : IRequestHandler<DeleteBookCommand,Unit>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            Book? book = await _context.Books
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync(cancellationToken);
            }
            
            return Unit.Value;
        }
    }
}