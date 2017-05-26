using System.Web.Mvc;
using System.Net;
using HenriqueV5.Models.Registration;
using Service.Registration;
using Service.Tables;

namespace HenriqueV5.Controllers
{
    public class ProductsController : Controller
    {
        //private EFContext context = new EFContext();
        // GET: Products
        private ProductService productService =
            new ProductService();
        private CategoryService categoryService =
            new CategoryService();
        private SupplierService supplierService =
            new SupplierService();

        public ActionResult Index()
        {
            return View
                (productService.
                GetProductsClassifiedByName());
        }



        private ActionResult GetViewProductById
            (long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }
            Product product = productService.
                GetProductById((long)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }


        //DETAILS
        public ActionResult Details(long? id)
        {
            return GetViewProductById(id);
        }
        //DELETE
        public ActionResult Delete(long? id)
        {
            return GetViewProductById(id);
        }

        private void PopularViewBag
            (Product product = null)
        {
            if (product == null)
            {
                ViewBag.CategoryId =
                    new SelectList(categoryService.
                    GetCategoriesClassifiedByName(),
                    "CategoryId", "Name");
                ViewBag.SupplierId =
                    new SelectList(supplierService.
                    GetSuppliersClassifiedByName(),
                    "SupplierId", "Name");
            }
            else
            {
                ViewBag.CategoryId =
                    new SelectList(categoryService.
                    GetCategoriesClassifiedByName(),
                    "CategoryId", "Name", product.CategoryId);
                ViewBag.SupplierId =
                    new SelectList(supplierService.
                    GetSuppliersClassifiedByName(),
                    "SupplierId", "Name", product.SupplierId);
            }
        }


        //EDIT
        public ActionResult Edit(long? id)
        {
            PopularViewBag(productService.
                GetProductById((long)id));
            return GetViewProductById(id);
        }
        //CREATE
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }






        private ActionResult RecordProduct
            (Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productService.
                        RecordProduct(product);
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch
            {
                return View(product);
            }
        }



        [HttpPost]
        public ActionResult Create
            (Product product)
        {
            return RecordProduct(product);
        }
        [HttpPost]
        public ActionResult Edit
            (Product product)
        {
            return RecordProduct(product);
        }



        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                Product product =
                    productService.
                    RemoveProductById(id);
                TempData["Message"] =
                    "Product	" + product.Name.ToUpper()
                    + "	was removed";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }




        /*

        // GET: Products/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }
            Product product = context.Products.Where(p => p.ProductId ==
            id).Include(c => c.Category).Include(s => s.Supplier)
            .First();
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(context.Categories
                .OrderBy(b => b.Name), "CategoryId", "Name");
            ViewBag.SupplierId = new SelectList(context.Suppliers
                .OrderBy(b => b.Name), "SupplierId", "Name");
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                // TODO: Add insert logic here
                context.Products.Add(product);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(product);
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(long? id)

        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }
            Product product = context.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(context.Categories
                .OrderBy(b => b.Name), "CategoryId", "Name", product
                .CategoryId);
            ViewBag.SupplierId = new SelectList(context.Suppliers
                .OrderBy(b => b.Name), "SupplierId", "Name", product
                .SupplierId);

            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)

        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(product).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch
            {
                return View(product);
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(long? id)

        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }
            Product product = context.Products.Where(p => p.ProductId ==
            id).Include(c => c.Category).Include(s => s.Supplier)
            .First();
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)

        {
            try
            {
                Product product = context.Products.Find(id);
                context.Products.Remove(product);
                context.SaveChanges();
                TempData["Message"] = "Product " + product.Name.ToUpper()
                    + "was removed";

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
    */
    }
}
