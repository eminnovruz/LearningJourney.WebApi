using Domain.Models.Common;

namespace Domain.Models;

public class Book : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string AuthorFullName { get; set; }
    public int Price { get; set; }
    public int OwnerCount { get; set; }
    public List<string> Tags { get; set; }
}
