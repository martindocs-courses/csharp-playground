
namespace OOP_SOLID_Principles.SRP_Invoice_Generator
{   
    public class InvoiceData{
        private SellerInvoiceInfo _sellerInvoiceInfo;
        private BuyerInvoiceInfo _buyerInvoiceInfo;

        public InvoiceData(SellerInvoiceInfo sellerInvoiceInfo, BuyerInvoiceInfo buyerInvoiceInfo)
        {
            _sellerInvoiceInfo = sellerInvoiceInfo;
            _buyerInvoiceInfo = buyerInvoiceInfo;
        }

        public SellerInvoiceInfo SellerData => _sellerInvoiceInfo;
        public BuyerInvoiceInfo BuyerData => _buyerInvoiceInfo;        
    }

    public class SellerInvoiceInfo{
        public string SellerName { get; set; } = "Adam";
        public string SellerAddress { get; set; } = "Unknown";
        public int SellerId { get; set; } = 23;
        public List<ProductInfo> ProductInfo { get; set; } = new List<ProductInfo>();
    }

    public class ProductInfo
    {
        public string ProductName { get; set; } 
        public int ProductId { get; set; } 
        public int ProductQty { get; set; } 
        public decimal ProductPrice { get; set; }
    }

    public class BuyerInvoiceInfo{
        public string BuyerName { get; set; } = "Martin";
        public string BuyerAddress { get; set; } = "Secret...";
        public int BuyerId { get; set; } = 999;
    }
    
    public class InvoiceCalculator{
        private decimal _amount;

        public decimal GetTotal => _amount;
        public void CalculateTotals(InvoiceData invoice){
            var productPrice = invoice.SellerData.ProductInfo;

            foreach (var data in productPrice)
            {
                _amount += data.ProductPrice * data.ProductQty;
            }
        }

        public void CalculateTax(InvoiceData invoice)
        {
            Console.WriteLine("Calculate Tax...");
        }
    }

    public class PrintInvoice{
        
        public void Print(InvoiceData invoices){

            var seller = invoices.SellerData;
            var buyer = invoices.BuyerData;
            seller.ProductInfo.Add(new ProductInfo{
                ProductId = 1,
                ProductName = "Brush",
                ProductQty = 2,
                ProductPrice = 1.34m                
            });
            
            var product = invoices.SellerData.ProductInfo;            

            Console.WriteLine("Seller Information:");
            Console.WriteLine(
                $"ID: {seller.SellerId},\n" +
                $"Name: {seller.SellerName},\n" +
                $"Address: {seller.SellerAddress}\n"
            );

            Console.WriteLine("Product Information:");
            foreach (var item in product)
            {
                Console.WriteLine(
                    $"ID: {item.ProductId},\n" +
                    $"Name: {item.ProductName},\n" +
                    $"Price:£{item.ProductPrice}\n");
            }

            Console.WriteLine("Buyer Information:");            
            Console.WriteLine(
                $"ID: {buyer.BuyerId},\n" +
                $"Name: {buyer.BuyerName},\n" +
                $"Address: {buyer.BuyerAddress}"
            );            
        }
    }
}
