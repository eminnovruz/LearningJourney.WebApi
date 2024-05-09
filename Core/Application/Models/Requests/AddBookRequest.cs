namespace Application.Models.Requests;

public class AddBookRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string AuthorFullName { get; set; }
    public List<string> Tags { get; set; }
    public int Price { get; set; }
}
