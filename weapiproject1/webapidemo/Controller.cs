using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webapidemo.Data; using Microsoft.AspNetCore.Mvc;
using webapidemo.Data;   // ← IMPORTANT

namespace webapidemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _db;

        public CustomerController(AppDbContext db)   // ← FIXED
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.Customers.ToList());
        }
    }
}