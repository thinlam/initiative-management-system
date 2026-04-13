// Models/Product.cs
public class Product
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Ma { get; set; } = string.Empty;      // Code: "PRD001"
    public string Ten { get; set; } = string.Empty;     // Name
    public string? MoTa { get; set; }                   // Description
    public decimal Gia { get; set; }                    // Price
    public int SoLuong { get; set; }                    // Quantity
    public int CategoryId { get; set; }                 // FK
    
    // Navigation property
    public Category? Category { get; set; }
}