using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerWebAPI.Models;
using FluentValidation;

namespace CustomerWebAPI.BusinessLogicLayer
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.customerName).NotEmpty();
            RuleFor(customer => customer.customerCode).NotEmpty();
        }
    }
}
