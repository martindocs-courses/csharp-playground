
namespace OOP_SOLID_Principles.OCP_Invoice_Tax_Calculator
{
    public class Invoice{
        public decimal Total { get; set; } 
    }

    public interface ITaxCalculator{
        public decimal CalculatorTax(Invoice invoice);
    }

    public class VatTaxCalculator : ITaxCalculator
    {
        public decimal CalculatorTax(Invoice invoice) => invoice.Total * 0.15m;
    }
    public class GstTaxCalculator : ITaxCalculator
    {
        public decimal CalculatorTax(Invoice invoice) => invoice.Total * 0.25m;
    }
    public class SalesTaxCalculator : ITaxCalculator
    {
        public decimal CalculatorTax(Invoice invoice) => invoice.Total * 0.5m;
    }

    public class TaxService {        
        private ITaxCalculator _taxCalculator;
        public TaxService(ITaxCalculator taxCalculator)
        {            
            _taxCalculator = taxCalculator;
        }

        public decimal GetTax(Invoice invoice) {
            return _taxCalculator.CalculatorTax(invoice);
        }
               
    }

    public class  InvoicePrinter
    {
        public void PrintInvoice(Invoice invoice) { 
        
        }

    }
}
