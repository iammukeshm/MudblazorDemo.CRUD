using MudblazorDemo.CRUD.Data;
using MudblazorDemo.CRUD.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MudblazorDemo.CRUD.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerService(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public void DeleteCustomer(int id)
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.Id == id);
            if(customer!=null)
            {
                _dbContext.Customers.Remove(customer);
                _dbContext.SaveChanges();
            }
        }

        public Customer GetCustomerById(int id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(x => x.Id == id);
            return customer;
        }

        public List<Customer> GetCustomers()
        {
            return _dbContext.Customers.ToList();
        }

        public void SaveCustomer(Customer customer)
        {
            if (customer.Id == 0) _dbContext.Customers.Add(customer);
            else _dbContext.Customers.Update(customer);
            _dbContext.SaveChanges();
        }
    }
}
