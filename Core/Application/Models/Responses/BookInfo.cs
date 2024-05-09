namespace Application.Models.Responses;

public class BookInfo
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string AuthorFullName { get; set; }
    public int Price { get; set; }
    public int OwnerCount { get; set; }
}
