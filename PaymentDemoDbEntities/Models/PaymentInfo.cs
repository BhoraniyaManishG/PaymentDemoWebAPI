using PaymentDemoModels.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentDemoModels.Models
{
    public class PaymentInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [CreditCard]
        [DataType(DataType.CreditCard)]
        public string CreditCardNumber { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string CardHolder { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }

        [MaxLength(3)]
        [SecurityCode]
        public string SecurityCode { get; set; }

        [Range(0.1, 9999999999999999.99)]
        //[RegularExpression(@"^\d+\.\d{0,2}$")]
        [Column(nameof(Amount), TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public virtual ICollection<PaymentStatusInfo> PaymentStatusInfo { get; set; }


    }

}
