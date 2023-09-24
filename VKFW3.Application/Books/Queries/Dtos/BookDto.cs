using AutoMapper;
using VKFW3.Application.Common.Mappings;
using VKFW3.Domain.Entities;

namespace VKFW3.Application.Books.Queries.Dtos;

public class BookDto : IMapFrom<Book>
{
    public long Id { get; set; }
    public string ISBN { get; set; }
    public string Name { get; set; }
    public int PageCount { get; set; }
    public DateTime PublishedDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Book, BookDto>();
    }
}