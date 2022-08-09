using System.ComponentModel.DataAnnotations;

namespace Invoice.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "ProductName")]
        public string Name { get; set; }



        //Relation With InvoiceDetails

        public virtual List<Product_InvoiceDetails> Product_InvoiceDetails { get; set; }

    }
}
