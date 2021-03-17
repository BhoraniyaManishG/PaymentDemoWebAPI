using PaymentDemoService.Util;
using PaymentDemoViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentDemoService.IServices
{
    public interface IPaymentProcess
    {
        PaymentStatusVM ProcessPaymentRequest(PaymentRequestVM paymentRequest);
    }
}
