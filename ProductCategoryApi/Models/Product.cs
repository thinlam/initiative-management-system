public class Product
{
    public Guid Id {get; set;} = Guid.NewGuid(); // Tạo Id tự động khi tạo đối tượng mới
    public string Ma {get; set;} = string.Empty; // string.Empty để tránh lỗi null khi tạo đối tượng mới
    public string Ten { get; set; } = string.Empty; // string.Empty để tránh lỗi null khi tạo đối tượng mới
    public string? MoTa { get; set; }
    public decimal Gia { get; set; }
    public int CategoryId { get; set; } // Foreign key
    public Category? Category { get; set; } // Navigation property
}