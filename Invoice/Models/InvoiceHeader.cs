using System.ComponentModel.DataAnnotations;

namespace Invoice.Models
{
    public class InvoiceHeader
    {

        public InvoiceHeader()
        {
            InvoiceDetails = new List<InvoiceDetails>();
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Serial")]
        public Guid InvoiceSerial { get; set; }

        public DateTime Date { get; set; }



        //Relation With InvoiceDetails

        public virtual List<InvoiceDetails> InvoiceDetails { get; set; }

    }
}
