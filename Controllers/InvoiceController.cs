using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BuggyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetInvoices()
        {
            // Create multiple invoices
            var invoices = new List<object>
            {
                new 
                {
                    InvoiceId = 1,
                    CustomerName = "John Doe",
                    Items = new List<Item>
                    {
                        new Item { Name = "Widget A", Price = 19.99 },
                        new Item { Name = "Widget B", Price = 9.50 }
                    },
                    Total = 19.99 + 9.50
                },
                new 
                {
                    InvoiceId = 2,
                    CustomerName = "Jane Smith",
                    Items = new List<Item>
                    {
                        new Item { Name = "Service C", Price = 49.00 },
                        new Item { Name = "Widget D", Price = 29.99 }
                    },
                    Total = 49.00 + 29.99
                },
                new 
                {
                    InvoiceId = 3,
                    CustomerName = "Bob Johnson",
                    Items = new List<Item>
                    {
                        new Item { Name = "Product E", Price = 15.00 },
                        new Item { Name = "Service F", Price = 35.50 }
                    },
                    Total = 15.00 + 35.50
                }
            };

            return Ok(invoices);
        }

        public class Item
        {
            public string Name { get; set; } = string.Empty;
            public double Price { get; set; }
        }
    }
}
