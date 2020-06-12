using System.ComponentModel.DataAnnotations.Schema;

namespace AFORO255.MS.TEST.Invoice.Model
{
    [Table("invoice")]
    public class Invoice
    {
        [Column("id")]
        public int id { get; set; }
        [Column("amount")]
        public decimal amount { get; set; }
        [Column("state")]
        public int state { get; set; }
    }
}
