using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetBasicApplication;
using AspNetBasicApplication.Model;
using System.Configuration;

namespace AspNetBasicApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public CustomersController(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET api/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }
            var settingMessage = _configuration.GetValue<string>("Logging:LogLevel:Default");
            return await _context.Customers.ToListAsync();
        }

        // GET api/customers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCustomer(int id)
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        // POST api/customers
        [HttpPost]
        public async Task<ActionResult> PostCustomer(Customer customer)
        {
            if (_context.Customers == null)
            {
                return Problem("Entity set 'DataContext.Customers'  is null.");
            }

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = customer.ID }, customer);
        }

        // PUT api/customers/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.ID)
            {
                return BadRequest();
            }

            var existingCustomer = _context.Customers.Find(id);
            if (existingCustomer == null)
                return NotFound();

            existingCustomer.Name = customer.Name;
            existingCustomer.EmailId = customer.EmailId;
            existingCustomer.Address = customer.Address;
            existingCustomer.Currency = customer.Currency;

            _context.SaveChanges();

            return NoContent();
        }

        // DELETE api/customers/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
                return NotFound();

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return NoContent();
        }
    }

}
