using System.Net.Http.Headers;

public class Category
{
    public int Id { get; set; }
    public string Ma {get; set;} = string.Empty; // string.Empty để tránh lỗi null khi tạo đối tượng mới
    public string Ten { get; set; } = string.Empty; // string.Empty để tránh lỗi null khi tạo đối tượng mới
    public string? MoTa { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>(); // Khởi tạo để tránh lỗi null


}