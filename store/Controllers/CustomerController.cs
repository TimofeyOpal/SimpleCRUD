using DB.AccessData;
using DB.AccessData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using store.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.AccessData.Models;

namespace store.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private IStandartCrud<Customer> _contextCustomer { get; set; }
        public CustomerController(IStandartCrud<Customer> contextCustomer)
        {
            _contextCustomer = contextCustomer;
        }


        [HttpPost]
        public async Task Send(Customer customer)
        {
          await _contextCustomer.Add(customer);
        }
        [HttpGet]
        public IEnumerable<Customer> GetAll()
        {
            return _contextCustomer.All;
        }

    }
}
