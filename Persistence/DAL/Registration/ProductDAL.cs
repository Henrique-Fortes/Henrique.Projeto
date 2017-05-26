using HenriqueV5.Models.Registration;
using HenriqueV5.Models.Registration.Contexts;
using System.Linq;
using System.Data.Entity;

namespace Persistence.DAL.Registration
{

    public class ProductDAL
    {
        private EFContext context = new EFContext();

        public IQueryable GetProductsClassifiedByName()

        {
            return context.Products.Include(c => c.Category).
                Include(s => s.Supplier).OrderBy(n => n.Name);
        }
        public Product GetProductById(long id)
        {
            return context.Products.Where(p => p.ProductId == id)
                .Include(c => c.Category).Include(s => s.Supplier)
                .First();
        }
        public void RecordProduct(Product product)
        {
            if (product.ProductId == null)
            {
                context.Products.Add(product);
            } else {
                context.Entry(product)
                    .State = EntityState.Modified;
            } context.SaveChanges();
        }
        public Product RemoveProductById(long id)
        {
            Product product = GetProductById(id);
            context.Products.Remove(product);
            context.SaveChanges();
            return product;
        }
    }
}








  
