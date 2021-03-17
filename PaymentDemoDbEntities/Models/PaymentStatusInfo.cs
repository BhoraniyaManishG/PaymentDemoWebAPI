using PaymentDemoModels.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PaymentDemoModels.Models
{
    public class PaymentStatusInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string PaymentStatus { get; set; }
        public int PaymentInfoId { get; set; }
        public DateTime PaymentStatusDatetime { get; set; }



        [ForeignKey(nameof(PaymentInfoId))]
        public PaymentInfo PaymentInfo { get; set; }
        
    }
}
