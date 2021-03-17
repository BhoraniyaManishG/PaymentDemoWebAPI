using PaymentDemoModels.Models;
using PaymentDemoRepository.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentDemoRepository.IRepositories
{
    public interface IPaymentInfoRepo : IGenericRepository<PaymentInfo>
    {
    }
}
