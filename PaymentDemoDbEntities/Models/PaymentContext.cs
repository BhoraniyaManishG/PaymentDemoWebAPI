using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PaymentDemoModels.Models
{
    public class PaymentContext : DbContext
    {
        public PaymentContext()
        {

        }
        public PaymentContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<PaymentStatusInfo> PaymentStatusInfo { get; set; }
        public DbSet<PaymentInfo> PaymentInfo { get; set; }
    }
}
