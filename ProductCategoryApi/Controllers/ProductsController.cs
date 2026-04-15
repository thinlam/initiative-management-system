// Controllers/ProductsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _db;
    
    public ProductsController(AppDbContext db) => _db = db;

    // GET: api/products
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAll()
    {
        return await _db.Products.Include(p => p.Category).ToListAsync();
    }

    // GET: api/products/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(Guid id)
    {
        var product = await _db.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
        if (product == null) return NotFound();
        return product;
    }

    // GET: api/products/category/1
    [HttpGet("category/{categoryId}")]
    public async Task<ActionResult<List<Product>>> ByCategory(int categoryId)
    {
        return await _db.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
    }

    // POST: api/products
    // <summary>
    // Create a new product. The request body should contain the product details in JSON format.
    // Example request body:
    // {
    //   "ma": "PROD001",
    //   "ten": "Laptop Dell XPS 13",
    //   "moTa": "Laptop cao cấp với
    //   "gia": 15000000,
    //   "soLuong": 10,
    //   "categoryId": 1
    // }    
    // </summary>
    [HttpPost]
    public async Task<ActionResult<Product>> Create(Product product)
    {
        // Check category exists
        var category = await _db.Categories.FindAsync(product.CategoryId);
        if (category == null) return BadRequest("Category not found");
        
        _db.Products.Add(product);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    // PUT: api/products/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, Product product)
    {
        if (id != product.Id) return BadRequest();
        
        _db.Entry(product).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/products/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var product = await _db.Products.FindAsync(id);
        if (product == null) return NotFound();
        
        _db.Products.Remove(product);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}