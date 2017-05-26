using HenriqueV5.Models.Registration;
using Persistence.DAL.Registration;
using System.Linq;

namespace Service.Registration
{
    public class ProductService
    {
        private ProductDAL productDAL = new ProductDAL();
        public IQueryable GetProductsClassifiedByName()
        {
            return productDAL.GetProductsClassifiedByName();
        }
        public Product GetProductById(long id)
        {
            return productDAL.GetProductById(id);
        }
        public void RecordProduct(Product product)
        {
            productDAL.RecordProduct(product);
        }
        public Product RemoveProductById(long id)
        {
            return productDAL.RemoveProductById(id);
        }
    }
}

    
