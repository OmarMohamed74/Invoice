using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoice.Models
{
    public class InvoiceDetails
    {
        [Key]
        public int Id { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }



        // Relation With InvoiceHeader 

        [ForeignKey("InvoiceHeaderId")]
        public int InvoiceHeaderId { get; set; }
        public virtual InvoiceHeader InvoiceHeader { get; set; }


        //Relation With Product

        public virtual List<Product_InvoiceDetails> Product_InvoiceDetails { get; set; }


    }
}
