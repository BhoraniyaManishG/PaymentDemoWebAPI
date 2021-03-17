using PaymentDemoService.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentDemoService.IPaymentGateways
{
    public abstract class GatewayFactoryBase
    {
        public abstract IPaymentGateway GetPaymentGateway(decimal amount);
    }
}
