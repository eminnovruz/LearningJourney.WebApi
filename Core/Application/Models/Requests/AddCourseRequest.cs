namespace Application.Models.Requests;

public class AddCourseRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string FullAddress { get; set; }
    public int Price { get; set; }
    public List<string> Tags { get; set; }
}
