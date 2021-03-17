using PaymentDemoRepository.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentDemoRepository.IRepositories
{
    public interface IPaymentStatusInfoRepo : IGenericRepository<PaymentDemoModels.Models.PaymentStatusInfo>
    {
    }
}
