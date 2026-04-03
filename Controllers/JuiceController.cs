namespace juicebora.Controllers;
using juicebora.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class JuiceController(JuiceBoraDbContext _juiceDbContext) : ControllerBase
{
   private readonly JuiceBoraDbContext juiceDbContext = _juiceDbContext;

   [HttpGet]
   public async Task<ActionResult<IEnumerable<Juice>>> GetJuices()
   {
       return await juiceDbContext.Juices.ToListAsync();
   }

   [HttpGet("{id}")]
   public async Task<ActionResult<Juice>> GetJuice(int id)
   {
       var juice = await juiceDbContext.Juices.FindAsync(id);
       return juice is null ? NotFound() : juice;
   }

   [HttpPost]
   public async Task<ActionResult<Juice>> CreateJuice([FromBody] Juice juice)
   {
       if (juice is null)
           return BadRequest("Juice payload is required.");

       if (string.IsNullOrWhiteSpace(juice.Name))
           return BadRequest("Juice name is required.");

       if (juice.Price < 0)
           return BadRequest("Juice price must be non-negative.");

       juiceDbContext.Juices.Add(juice);
       await juiceDbContext.SaveChangesAsync();

       return CreatedAtAction(nameof(GetJuice), new { id = juice.Id }, juice);
   }
}
