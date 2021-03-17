using Microsoft.EntityFrameworkCore;
using PaymentDemoModels.Models;
using PaymentDemoRepository.Abstraction;
using PaymentDemoRepository.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentDemoRepository.Repositories
{
    public class PaymentStatusInfoRepo : GenericRepository<PaymentStatusInfo>, IPaymentStatusInfoRepo
    {
        public PaymentStatusInfoRepo(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
