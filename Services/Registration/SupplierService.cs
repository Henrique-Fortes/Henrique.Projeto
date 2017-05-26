using HenriqueV5.Models.Registration;
using Persistence.DAL.Registration;
using System.Linq;

namespace Service.Registration
{
    public class SupplierService
    {
        private SupplierDAL supplierDAL = new SupplierDAL();
        public IQueryable GetSuppliersClassifiedByName()
        {
            return supplierDAL.GetSuppliersClassifiedByName();
        }
        public Supplier GetSupplierById(long id)
        {
            return supplierDAL.GetSupplierById(id);
        }
        public void RecordSupplier(Supplier supplier)
        {
            supplierDAL.RecordSupplier(supplier);
        }
        public Supplier RemoveSupplierById(long id)
        {
            return supplierDAL.RemoveSupplierById(id);
        }



    }
}









    /*
    public class SupplierService
    {
        private SupplierDAL supplierDAL = new SupplierDAL();
        public IQueryable<Supplier>
            GetSuppliersClassifiedByName()
        {


            return
            supplierDAL.
            GetSuppliersClassifiedByName();
        }
    }
    */


