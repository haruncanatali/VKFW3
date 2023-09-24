using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VKFW3.Domain.Entities;

namespace VKFW3.Persistence.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
        builder.Property(c => c.PageCount).IsRequired();
        builder.Property(c => c.PublishedDate).IsRequired();
        builder.Property(c => c.ISBN).IsRequired();
    }
}