﻿using androidForumAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace androidForumAPI.Data.Repositories
{ 
    public class CustomerRepository : ICustomerRepository
    {
        private readonly PostContext _context;
        private readonly DbSet<Customer> _customers;

        public CustomerRepository(PostContext dbContext)
        {
            _context = dbContext;
            _customers = dbContext.Customers;
        }
        public void Add(Customer customer)
        {
            _customers.Add(customer);
        }

        public Customer GetBy(string name)
        {
            return _customers.SingleOrDefault(c => c.UserName == name);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
