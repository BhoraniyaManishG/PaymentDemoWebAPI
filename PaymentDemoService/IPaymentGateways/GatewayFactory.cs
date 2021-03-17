using PaymentDemoRepository.Abstraction;
using PaymentDemoService.PaymentGateways;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentDemoService.IPaymentGateways
{
    public class GatewayFactory : GatewayFactoryBase
    {
        IUnitOfWork unitOfWork;

        public GatewayFactory(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public override IPaymentGateway GetPaymentGateway(decimal amount)
        {
            if (amount > 0 && amount <= 20)
            {
                return new CheapPaymentGateway(unitOfWork);
            }
            else if (amount >= 21 && amount <= 500)
            {
                return new ExpensivePaymentGateway(unitOfWork); 
            }
            else if (amount > 500)
            {
                return new PremiumPaymentService(unitOfWork);
            }
            else
            {
                throw new ApplicationException(string.Format("Payment Gateway not applicable for amount '{0}'", amount));
            }
        }
    }
}
