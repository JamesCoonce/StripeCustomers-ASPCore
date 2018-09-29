using System.Collections.Generic;

namespace StripeCustomers.Models
{
    public class Customer
    {
        public string Email { get; set; }
        public string Description { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
    }
}