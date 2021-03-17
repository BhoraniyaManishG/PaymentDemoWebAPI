using PaymentDemoModels.Models;
using PaymentDemoViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentDemoService.IPaymentGateways
{
    public interface IPaymentGateway
    {
        PaymentStatusVM ProcessPayment(PaymentInfo paymentInfo);
    }
}
