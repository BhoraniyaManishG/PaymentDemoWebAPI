using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using PaymentDemoModels;
using PaymentDemoModels.Util;

namespace PaymentDemoViewModels
{
    public class PaymentRequestVM
    {
        [Required]
        [CreditCard]
        public string CreditCardNumber { get; set; }

        [Required]
        public string CardHolder { get; set; }

        [Required]
        [PastDateValidation]
        public DateTime ExpirationDate { get; set; }

        [MaxLength(3)]
        [SecurityCode]
        public string SecurityCode { get; set; }

        [Range(0.1, 999999999999999)]
        //[RegularExpression(@"^\d+\.\d{0,2}*$")]
        public decimal Amount { get; set; }

        

    }
}
