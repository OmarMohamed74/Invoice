using Invoice.Data;
using Microsoft.AspNetCore.Mvc;
using Invoice.Models;
using Invoice.ViewModels;

namespace Invoice.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly AppDbContext _context;

        public InvoiceController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult InvoiceProcessing() {
            
            List<Product> products = _context.Products.ToList();
            

            return View(products); 
        }


        [HttpPost]
        public IActionResult InvoiceProcessing(InvoiceHeader_DetailsViewModel model)
        {
            

            if (ModelState.IsValid)
            {
                //List<Product> products = _context.Products.ToList();
                //ViewBag.Products = products;

                // saving data to invoiceheader

                InvoiceHeader invoiceHeader = new InvoiceHeader();
                invoiceHeader.CustomerName = model.CustomerName;
                invoiceHeader.InvoiceSerial = Guid.NewGuid();
                invoiceHeader.Date = DateTime.Now;

                _context.InvoiceHeader.Add(invoiceHeader);
                _context.SaveChanges();

                // Getting the last added id of invoiceheader to be a FK in invoiceDetails

                int lastAddedId = invoiceHeader.Id;


                // Saving Data of header to invoiceDetails

                InvoiceDetails invoiceDetails = new InvoiceDetails();

                invoiceDetails.Price = model.Price;
                invoiceDetails.Quantity = model.Quantity;
                invoiceDetails.InvoiceHeaderId = lastAddedId;

                _context.InvoiceDetails.Add(invoiceDetails);
                _context.SaveChanges();

                // Saving products of customer 
                Product_InvoiceDetails productDetails = new Product_InvoiceDetails();

                productDetails.ProductId = model.productId;
                productDetails.InvoiceDetailsId = lastAddedId;
                _context.Product_InvoiceDetails.Add(productDetails);
                _context.SaveChanges();
                

                InvoiceSucceededVM invoiceSucceededVM = new InvoiceSucceededVM();
                
                invoiceSucceededVM.invoicedetails = invoiceDetails;
                invoiceSucceededVM.invoiceheader = invoiceHeader;
               

                return View("PaymentSuccessfully", invoiceSucceededVM);
            }
            else
            {
                return View("Error", ModelState);
            }

            
            
        }

        
    }
}
