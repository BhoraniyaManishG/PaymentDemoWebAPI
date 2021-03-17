using AutoMapper;
using PaymentDemoModels.Models;
using PaymentDemoRepository.Abstraction;
using PaymentDemoService.IPaymentGateways;
using PaymentDemoService.IServices;
using PaymentDemoViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentDemoService.Services
{
    public class PaymentProcess : IPaymentProcess
    {
        IUnitOfWork unitOfWork;
        IMapper mapper;

        public PaymentProcess(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public PaymentStatusVM ProcessPaymentRequest(PaymentRequestVM paymentRequest)
        {
            GatewayFactory gatewayFactory = new GatewayFactory(unitOfWork);

            IPaymentGateway paymentGateway = gatewayFactory.GetPaymentGateway(paymentRequest.Amount);

            PaymentInfo pi = mapper.Map<PaymentRequestVM, PaymentInfo>(paymentRequest);

            return paymentGateway.ProcessPayment(pi);
        }
    }
}
