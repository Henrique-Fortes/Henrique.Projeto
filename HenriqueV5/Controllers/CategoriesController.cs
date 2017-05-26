using HenriqueV5.Models.Tables;
using Service.Registration;
using Service.Tables;
using System.Net;
using System.Web.Mvc;

namespace HenriqueV5.Controllers
{
    public class CategoriesController : Controller
    {

        //private EFContext context = new EFContext();


        // GET: Categories
        private ProductService productService =
            new ProductService();
        private CategoryService categoryService =
            new CategoryService();
        private SupplierService supplierService =
            new SupplierService();


        public ActionResult Index()
        {
            return View
                (categoryService.
                GetCategoriesClassifiedByName());
        }



        private ActionResult GetViewCategoryById
            (long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }
            Category category = categoryService.
                GetCategoryById((long)id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }


        //DETAILS
        public ActionResult Details(long? id)
        {
            return GetViewCategoryById(id);
        }
        //DELETE
        public ActionResult Delete(long? id)
        {
            return GetViewCategoryById(id);
        }

        //EDIT
        public ActionResult Edit(long? id)
        {
            return GetViewCategoryById(id);
        }
        //CREATE
        public ActionResult Create()
        {
            return View();
        }






        private ActionResult RecordCategory
            (Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoryService.
                        RecordCategory(category);
                    return RedirectToAction("Index");
                }
                return View(category);
            }
            catch
            {
                return View(category);
            }
        }



        [HttpPost]
        public ActionResult Create
            (Category category)
        {
            return RecordCategory(category);
        }
        [HttpPost]
        public ActionResult Edit
            (Category category)
        {
            return RecordCategory(category);
        }



        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                Category category =
                    categoryService.
                    RemoveCategoryById(id);
                TempData["Message"] =
                    "Category	" + category.Name.ToUpper()
                    + "	was removed";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


















        /*
        public ActionResult Index()
        {
            return View(context.Categories.OrderBy(
                c => c.Name));
        }


        //GET: Create
        public ActionResult Create()
        {
            return View();
        }


        //GET: Edit
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new
                    HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }
            Category category = context.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }


        //GET: Details
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }
            Category category = context.Categories
                .Where(c => c.CategoryId == id)
                .Include("Products.Supplier")
                .First();
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }


        //GET: Delete
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }
            Category category = context.Categories
                .Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }



        //POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        //POST: Edit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                context.Entry(category).State =
                    EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }


        //POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Category category = context.Categories
                .Find(id);
            context.Categories.Remove(category);
            context.SaveChanges();
            TempData["Message"] = "Supplier " +
                category.Name.ToUpper() + "was removed";
            return RedirectToAction("Index");
        }

    */

    }
}