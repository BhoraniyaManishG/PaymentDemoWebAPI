using PaymentDemoRepository.IRepositories;
using PaymentDemoRepository.Abstraction;
using PaymentDemoModels.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PaymentDemoRepository.Repositories
{
    public class PaymentInfoRepo : GenericRepository<PaymentInfo>, IPaymentInfoRepo
    {
        public PaymentInfoRepo(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
