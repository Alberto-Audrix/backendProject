using backendProject.Data;
using backendProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backendProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WearHouseController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WearHouseController(AppDbContext context)
        {
            _context = context;
        }

        // GET data from Admins

        // GET: api/<WearHouseController>
        [HttpGet]
        public IEnumerable<Admins> Get()
        {
            var adminList = _context.Admin.Select(x => new Admins
            {
                UserID = x.UserID,
                Nama = x.Nama,
                Email = x.Email,
                Pass = x.Pass

            }).ToList();
            return adminList;
        }


        // GET data from Product

        //[HttpGet]
        //public IEnumerable<Product> Get()
        //{
        //    var productList = _context.Products.Select(x => new Product
        //    {
        //        Category = x.Category

        //    }).ToList();
        //    return productList;
        //}



        //// GET api/<WearHouseController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST for admin

        // POST api/<WearHouseController>
        //[HttpPost]
        //public ActionResult Post([FromBody] NewAdminRequest newAdmins)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    // ngecek sama apa gak IDnya terus return true kalo bener

        //    var admin = new Admins
        //    {
        //        Nama = newAdmins.Nama,
        //        Email = newAdmins.Email,
        //        Pass = newAdmins.Pass
        //    };

        //    _context.Admin.Add(admin);
        //    _context.SaveChanges();
        //    return Ok();
        //}

        // Post for Product
        [HttpPost]
        public ActionResult Post([FromBody] NewProductRequest newProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // ngecek sama apa gak IDnya terus return true kalo bener

            var product = new Product
            {
                Category = newProduct.Category,
            };

            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok();
        }


        // PUT for admin

        // PUT api/<WearHouseController>/5
        [HttpPut("{nama}")]
        public async Task<ActionResult> PutAsync(string nama, [FromBody] UpdateAdminRequest value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_context.Admin.Any(x => x.Nama == nama))
            {
                return NotFound("Admin not found");
            }

            var admin = await _context.Admin.FirstOrDefaultAsync(x => x.Nama == nama);
            admin.Nama = value.Nama;
            admin.Email = value.Email;
            admin.Pass = value.Pass;
            await _context.SaveChangesAsync();

            return Ok();
        }



        // PUT for product

        //[HttpPut("{nama}")]
        //public async Task<ActionResult> PutAsync(string nama, [FromBody] UpdateProductRequest value)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    if (!_context.Products.Any(x => x.Category == nama))
        //    {
        //        return NotFound("Category not found");
        //    }

        //    var category = await _context.Products.FirstOrDefaultAsync(x => x.Category == nama);
        //    category.Category = value.Category;
        //    await _context.SaveChangesAsync();

        //    return Ok();
        //}

        // DELETE for Admin

        // DELETE api/<WearHouseController>/5
        [HttpDelete("{nama}")]
        public async Task<ActionResult> Delete(string nama)
        {
            var admin = await _context.Admin.FirstOrDefaultAsync(x => x.Nama == nama);
            if (admin == null)
            {
                return NotFound("Admin Not Found");
            }

            _context.Admin.Remove(admin);
            await _context.SaveChangesAsync();

            return Ok();
        }


        // DELETE for product

        //[HttpDelete("{nama}")]
        //public async Task<ActionResult> Delete(string nama)
        //{
        //    var product = await _context.Products.FirstOrDefaultAsync(x => x.Category == nama);
        //    if (product == null)
        //    {
        //        return NotFound("Category Not Found");
        //    }

        //    _context.Products.Remove(product);
        //    await _context.SaveChangesAsync();

        //    return Ok();
        //}
    }
}
