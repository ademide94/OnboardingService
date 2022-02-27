using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnboardingData
{
    public class State
    { 
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<LGA> LGAs { get; set; }
    }
}
