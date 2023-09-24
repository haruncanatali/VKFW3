using Microsoft.EntityFrameworkCore;
using VKFW3.Domain.Entities;

namespace VKFW3.Application.Common.Interfaces;

public interface IApplicationContext
{
    public DbSet<Book> Books { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}