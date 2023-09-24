namespace VKFW3.Domain.Entities;

public class Book : BaseEntity
{
    public string ISBN { get; set; }
    public string Name { get; set; }
    public int PageCount { get; set; }
    public DateTime PublishedDate { get; set; }
}