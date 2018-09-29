using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using StripeCustomers.Models;

namespace StripeCustomers.Controllers
{
    [Route("api/customers")]
    public class CustomersController : Controller
    {
        private readonly StripeCustomerService customerService;
        public CustomersController()
        {
            customerService = new StripeCustomerService();
        }
        // GET
        [HttpGet]
        public IEnumerable<StripeCustomer> Index()
        {
            StripeList<StripeCustomer> customerItems = customerService.List(
                new StripeCustomerListOptions() {
                    Limit = 3
                }
            );

            return customerItems;
        }

        [HttpGet("{id}")]
        public StripeCustomer GetCustomer(string id)
        {
            var customer = customerService.Get(id);
            return customer;
        }

        [HttpPost]
        public StripeCustomer CreateCustomer([FromBody] Customer customerOptions)
        {
            var customerData = new StripeCustomerCreateOptions
            {
                Description = customerOptions.Description,
                Email = customerOptions.Email,
                Metadata = customerOptions.Metadata
            };
            var customer = customerService.Create(customerData);
            return customer;
        }

        [HttpPut("{id}")]
        public StripeCustomer UpdateCustomer([FromRoute] string id, [FromBody] Customer customerOptions)
        {
            var customerData = new StripeCustomerUpdateOptions
            {
                Description = customerOptions.Description,
                Email = customerOptions.Email,
                Metadata = customerOptions.Metadata
            };
            var customer = customerService.Update(id, customerData);
            return customer;
        }

        [HttpDelete("{id}")]
        public StripeDeleted DeleteCustomer(string id)
        {
            var result = customerService.Delete(id);
            return result;
        }
    }
}