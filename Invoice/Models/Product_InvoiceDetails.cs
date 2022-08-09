using System.ComponentModel.DataAnnotations.Schema;

namespace Invoice.Models
{
    public class Product_InvoiceDetails
    {

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }


        [ForeignKey("invoiceDetails")]
        public int InvoiceDetailsId { get; set; }
        public virtual InvoiceDetails InvoiceDetails { get; set; }
    }
}
