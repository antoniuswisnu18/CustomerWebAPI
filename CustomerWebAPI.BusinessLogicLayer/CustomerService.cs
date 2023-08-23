using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerWebAPI.DataAccessLayer;
using CustomerWebAPI.Models;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace CustomerWebAPI.BusinessLogicLayer
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _context;
        private readonly IValidator<Customer> _customervalidator;

        public CustomerService(AppDbContext context, IValidator<Customer> validator)
        {
            _context = context;
            _customervalidator = validator;
        }

        public async Task<List<Customer>> GetCustomerAsync()
        {
            return await _context.customers.ToListAsync();
        }


        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            ValidationResult valresult = _customervalidator.Validate(customer);

            if (!valresult.IsValid)
            {
                throw new ValidationException(valresult.Errors);
            }

            _context.customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }


        public async Task UpdateCustomerAsync(int id, Customer customer)
        {
            ValidationResult valresult = _customervalidator.Validate(customer);

            if (!valresult.IsValid)
            {
                throw new ValidationException(valresult.Errors);
            }

            if (id != customer.customerId)
            {
                return;
            }

            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _context.customers.FindAsync(id);
            if (customer == null)
            {
                return;
            }
            _context.customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            var customer = await _context.customers.FindAsync(id);
            return customer;
        }
    }
}
