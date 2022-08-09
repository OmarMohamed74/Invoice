using Invoice.Models;

namespace Invoice.ViewModels
{
    public class InvoiceHeader_DetailsViewModel
    {


        public string CustomerName { get; set; }
        public int productId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }


    }
}
