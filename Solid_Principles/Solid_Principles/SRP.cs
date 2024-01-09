using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Principles
{
    internal class SRP
    {
    }

    // represents the data of an invoice
    // this class only has one reason to change (the data of an invoice)
    public class Invoice
    {
        public int InvoiceNo { get; set; }
        public DateOnly IssuedDate { get; set; }
        public string? Customer { get; set; }
        public decimal Amount { get; set; }
        public string? Status { get; set; }
    }

    //  responsible for printing an invoice
    //  this class only has one reason to change (the logic of printing an invoice)
    public class InvoicePrinter
    {
        public void Print(Invoice invoice)
        {
           
            Console.WriteLine($"Invoice No: {invoice.InvoiceNo}");
            Console.WriteLine($"Issued Date: {invoice.IssuedDate}");
            Console.WriteLine($"Customer: {invoice.Customer}");
            Console.WriteLine($"Amount: {invoice.Amount}");
            Console.WriteLine($"Status: {invoice.Status}");
        }
    }

    // responsible for storing and retrieving invoices
    // reason to change (the logic of data access)
    public class InvoiceRepository
    {
        // A list to store invoices in memory
         List<Invoice> invoices = new List<Invoice>();

      
        public void Save(Invoice invoice)
        {
          
            invoices.Add(invoice);
        }

      
        public Invoice GetByInvoiceNo(int invoiceNo)
        {
          
            return invoices.Find(i => i.InvoiceNo == invoiceNo);
        }
    }

 
    public class Program
    {
        public static void Main(string[] args)
        {
            // invoice object
            Invoice invoice = new Invoice
            {
                InvoiceNo = 1,
                IssuedDate = DateOnly.FromDateTime(DateTime.Now),
                Customer = "John Doe",
                Amount = 100,
                Status = "Paid"
            };
           


            InvoiceRepository repository = new InvoiceRepository();
            repository.Save(invoice);

            Invoice invoiceFromDb = repository.GetByInvoiceNo(1);

        
            InvoicePrinter printer = new InvoicePrinter();
            printer.Print(invoiceFromDb);
        }
    }

}
