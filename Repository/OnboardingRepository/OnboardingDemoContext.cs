using System;
using Microsoft.EntityFrameworkCore;
using OnboardingData;

namespace OnboardingRepository
{
    public class OnboardingDemoContext : DbContext
    {
        public OnboardingDemoContext(DbContextOptions<OnboardingDemoContext> options)
        : base(options)
        {

        }

        public DbSet<Customer>  Customers { get; set; }
        public DbSet<OtpLog> OtpLogs  { get; set; }
        public DbSet<LGA>  LGAs { get; set; }
        public DbSet<State> States { get; set; }
    }
}
