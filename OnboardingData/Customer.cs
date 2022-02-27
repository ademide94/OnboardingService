using System;
using System.ComponentModel.DataAnnotations;

namespace OnboardingData
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; } 
        public int  LGAId { get; set; } 
        public int StateId { get; set; }
        


        public Customer()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.Now;
        }

    }
}
