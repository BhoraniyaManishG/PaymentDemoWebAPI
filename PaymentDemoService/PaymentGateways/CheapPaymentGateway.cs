using PaymentDemoModels.Models;
using PaymentDemoRepository.Abstraction;
using PaymentDemoService.IPaymentGateways;
using PaymentDemoService.IServices;
using PaymentDemoService.Util;
using PaymentDemoViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentDemoService.PaymentGateways
{
    public class CheapPaymentGateway : ICheapPaymentGateway
    {
        IUnitOfWork unitOfWork;

        public CheapPaymentGateway(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public PaymentStatusVM ProcessPayment(PaymentInfo paymentRequest)
        {
            PaymentStatusVM paymentStatusVM = new PaymentStatusVM()
            {
                PaymentStatus = Enums.PaymentProcessStatus.failed.ToString(),
                PaymentStatusDatetime = DateTime.Now
            };

            if (paymentRequest != null)
            {
                //insert in payment and payment status

                PaymentStatusInfo oPaymentStatusInfo = new PaymentStatusInfo()
                {
                    PaymentInfoId = paymentRequest.Id,
                    PaymentStatus = Enums.PaymentProcessStatus.pending.ToString(),
                    PaymentStatusDatetime = DateTime.Now,
                    PaymentInfo = paymentRequest
                };

                unitOfWork.PaymentInfoRepo.Create(paymentRequest);
                unitOfWork.PaymentStatusInfoRepo.Create(oPaymentStatusInfo);
                unitOfWork.Commit();

                if (paymentRequest.Amount % 2 == 0)//if (new Random().Next(1, 11) % 2 == 0)
                {
                    paymentStatusVM.PaymentStatus = Enums.PaymentProcessStatus.processed.ToString();
                }
                else
                {
                    paymentStatusVM.PaymentStatus = Enums.PaymentProcessStatus.failed.ToString();
                }

                PaymentStatusInfo oPaymentStatusInfoOK = new PaymentStatusInfo()
                {
                    PaymentInfoId = paymentRequest.Id,
                    PaymentStatus = paymentStatusVM.PaymentStatus,
                    PaymentStatusDatetime = DateTime.Now,
                    PaymentInfo = paymentRequest
                };

                unitOfWork.PaymentStatusInfoRepo.Create(oPaymentStatusInfoOK);
                unitOfWork.Commit();

            }

            return paymentStatusVM;
        }
    }
}
