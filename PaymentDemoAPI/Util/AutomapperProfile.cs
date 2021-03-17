using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentDemoAPI.Util
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<PaymentDemoViewModels.PaymentRequestVM,PaymentDemoModels.Models.PaymentInfo>().ReverseMap();
            CreateMap<PaymentDemoViewModels.PaymentStatusVM,PaymentDemoModels.Models.PaymentStatusInfo>().ReverseMap();
        }
    }
}
