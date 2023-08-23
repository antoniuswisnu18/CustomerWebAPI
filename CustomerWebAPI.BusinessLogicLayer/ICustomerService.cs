using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerWebAPI.Models;

namespace CustomerWebAPI.BusinessLogicLayer
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomerAsync();
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(int id, Customer customer);
        Task DeleteCustomerAsync(int id);
        Task<Customer> GetCustomerByIdAsync(int id);
    }
}
