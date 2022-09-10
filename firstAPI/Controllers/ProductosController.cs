using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace firstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Productos>>> Get()
        {

            return Ok(await _context.Productos.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Productos>> Get(int id)
        {
            var product = await _context.Productos.FindAsync(id);   
            if(product == null)
                return BadRequest("Product not found");
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult<List<Productos>>> AddProduct(Productos product)
        {
            _context.Productos.Add(product);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Productos.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Productos>>> UpdateProduct(Productos request)
        {
            var dbProduct = await _context.Productos.FindAsync(request.Id);
            if (dbProduct == null)
                return BadRequest("Product not found");
            dbProduct.Nombre = request.Nombre;
            dbProduct.Stock = request.Stock;
            dbProduct.Precio = request.Precio;

            await _context.SaveChangesAsync();

            return Ok(await _context.Productos.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Productos>>> DeleteProduct(int id)
        {
            var dbProduct = await _context.Productos.FindAsync(id);
            if (dbProduct == null)
                return BadRequest("Product not found");
            _context.Productos.Remove(dbProduct);
            await _context.SaveChangesAsync();

            return Ok(await _context.Productos.ToListAsync());
        }
    }
}
