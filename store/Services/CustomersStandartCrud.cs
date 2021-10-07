using DB.AccessData;
using DB.AccessData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store.Services
{
    public class CustomersStandartCrud : IStandartCrud<Customer>
    {
        WebApiCoreContext _context;

        public CustomersStandartCrud(WebApiCoreContext context)
        {
            _context = context;
        }
        public IEnumerable<Customer> All => _context.Customers.ToList();

        public async Task Add(Customer entity)
        {
            _context.Customers.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Customer entity)
        {
            _context.Customers.Remove(entity);
           await _context.SaveChangesAsync();
        }

        public Customer GetById(string Id)
        {
          return _context.Customers.FirstOrDefault(u => u.Id == Id); 
        }

        public Customer GetById(int Id)
        {
          return  _context.Customers.FirstOrDefault(u => u.Id == Id.ToString());
        }

        public void Update(Customer entity)
        {
          _context.Customers.Update(entity);
          _context.SaveChangesAsync();
           
        }
    }
}
