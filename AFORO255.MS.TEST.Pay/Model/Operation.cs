using System;
using System.ComponentModel.DataAnnotations;

namespace AFORO255.MS.TEST.Pay.Model
{
    public class Operation
    {
        [Key]
        public int id_operation { get; set; }
        public int id_invoice { get; set; }
        public decimal amount { get; set; }
        public DateTime date { get; set; }
    }
}
