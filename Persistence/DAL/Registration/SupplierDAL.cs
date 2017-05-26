using HenriqueV5.Models.Registration;
using HenriqueV5.Models.Registration.Contexts;
using System.Data.Entity;
using System.Linq;

namespace Persistence.DAL.Registration


{

    public class SupplierDAL
    {
        private EFContext context = new EFContext();

        public IQueryable GetSuppliersClassifiedByName()

        {
            return context.Suppliers.OrderBy(n => n.Name);
        }
        public Supplier GetSupplierById(long id)
        {
            return context.Suppliers
                .Include("Products.Category").Where(s => s.SupplierId == id)
                .First();
        }
        public void RecordSupplier(Supplier supplier)
        {
            if (supplier.SupplierId == null)
            {
                context.Suppliers.Add(supplier);
            }
            else
            {
                context.Entry(supplier)
                    .State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Supplier RemoveSupplierById(long id)
        {
            Supplier supplier = GetSupplierById(id);
            context.Suppliers.Remove(supplier);
            context.SaveChanges();
            return supplier;
        }








        /*
        public class SupplierDAL
        {
            private EFContext context = new EFContext();
            public IQueryable<Supplier> GetSuppliersClassifiedByName()
            {
                return context.Suppliers.OrderBy(b => b.Name);
            }
        }
        */
    }
}
