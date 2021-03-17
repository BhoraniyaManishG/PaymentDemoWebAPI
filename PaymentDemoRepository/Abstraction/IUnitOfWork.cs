using PaymentDemoRepository.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentDemoRepository.Abstraction
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();

        IPaymentInfoRepo PaymentInfoRepo { get; }
        IPaymentStatusInfoRepo PaymentStatusInfoRepo { get; }
    }
}
