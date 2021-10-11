using DB.AccessData;
using DB.AccessData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store.Services
{
    public class CustomersStandartCrud : ICrud<Customer>
    {
        WebApiCoreContext _context;

        public CustomersStandartCrud(WebApiCoreContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Customer>> All() => await _context.Customers.ToListAsync();

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
        public async Task Delete(string id)
        {
            var entity = await _context.Customers.FirstOrDefaultAsync(i => i.Id == id);
            _context.Customers.Remove(entity);
            await _context.SaveChangesAsync();
        }


        public async Task<Customer> GetById(string id)
        {       
            return await _context.Customers.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Customer> GetById(int Id)
        {
          return await  _context.Customers.FirstOrDefaultAsync(u => u.Id == Id.ToString());
        }

        public async Task Update(Customer entity)
        {
          _context.Customers.Update(entity);
          await _context.SaveChangesAsync();
           
        }
    }
}
