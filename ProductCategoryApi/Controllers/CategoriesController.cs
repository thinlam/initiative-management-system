using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController] // [Route("api/categories")]
[Route("api/[controller]")]// api/categories
public class CategoriesController : ControllerBase
{
    private readonly AppDbContext _db;
    public CategoriesController(AppDbContext db) => _db = db; // Dependency Injection
    // GET /api/categories
    [HttpGet]
    public async Task<ActionResult<List<Category>>> GetAll()
    {
        return await _db.Categories.ToListAsync();
    }
    // GET /api/categories/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetById(int id)
    {
        var category = await _db.Categories.FindAsync(id);
        if( category == null) return NotFound();
        return category;
    }
    // POST /api/categories
    [HttpPost]
    public async Task<ActionResult<Category>> Create(Category category)
    {
        _db.Categories.Add(category);
        await _db.SaveChangesAsync();
        return CreatedAtAction (nameof(GetById), new {id = category.Id},category);
    }

    // PUT /api/categories/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id , Category category)
    {
        if( id != category.Id) return BadRequest();
        _db.Entry(category).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var category = await _db.Categories.FindAsync(id);
        if(category == null) return NotFound();

        _db.Categories.Remove(category);
        await _db.SaveChangesAsync();
        return NoContent();
    }

}