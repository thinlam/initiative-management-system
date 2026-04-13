// Models/Category.cs
public class Category
{
    public int Id { get; set; }
    public string Ma { get; set; } = string.Empty;      // Code: "CAT001"
    public string Ten { get; set; } = string.Empty;     // Name
    public string? MoTa { get; set; }                   // Description
    
    // Products relationship
    public ICollection<Product> Products { get; set; } = new List<Product>();
}