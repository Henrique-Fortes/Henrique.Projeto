
using HenriqueV5.Models.Tables;

namespace HenriqueV5.Models.Registration
{
    public class Product
    {
        public long? ProductId { get; set; }
        public string Name { get; set; }
        public long? CategoryId { get; set; }
        public long? SupplierId { get; set; }
        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
    }
}