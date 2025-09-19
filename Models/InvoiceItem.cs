namespace InvoiceApp.Models
{
    public class InvoiceItem
    {
        public int ItemId { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public int InvoiceId { get; set; }   // Foreign Key
    }
}
