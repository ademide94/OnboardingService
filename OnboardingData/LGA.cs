using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnboardingData
{
    public class LGA
    {
        [Key]
        public int Id { get; set; }
        public int StateId { get; set; }
       // public State State { get; set; }
        public string Name { get; set; }
    }
}
