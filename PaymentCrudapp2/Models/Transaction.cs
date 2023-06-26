using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PaymentCrudapp2.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public string Description { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}