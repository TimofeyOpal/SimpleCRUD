using DB.AccessData;
using DB.AccessData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using store.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace store.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        readonly ICrud<Customer> _contextCustomer;
        public CustomerController(ICrud<Customer> contextCustomer)
        {
            _contextCustomer = contextCustomer;
        }

        [HttpPost("AddCustomer")]
        public async Task Send(Customer customer)
        {
            await _contextCustomer.Add(customer);
        }

        [HttpGet("GetAllCustomer")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAll()
        {
            var listCustomers = await _contextCustomer.All();
            return listCustomers == null ? BadRequest() : listCustomers.Count() == 0 ? NotFound() : Ok(listCustomers);
        }

        [HttpDelete("DeleteCustomerById")]
        public async Task Delete(string id)
        {
            await _contextCustomer.Delete(id);  
        }
        [HttpPut("UpdateCustomer")]
        public async Task UpdateCustomer(Customer customer)
        {
            await _contextCustomer.Update(customer);
        }

        [HttpPost("GetCustomerById/{routeName}")]// [FromRoute] string routeName, [FromForm] Customer customer, [FromBody] Customer customer_, [FromHeader] string headerName
        public async Task<ActionResult<Customer>> GetByCustomerID([FromQuery] string queryName)//https://{site}/Customer/GetCustomerById/FromQuery?queryName=100 
        {
            var customer = await _contextCustomer.GetById(queryName);
            return customer == null ? BadRequest() : Ok(customer);      
        }
    }
}
