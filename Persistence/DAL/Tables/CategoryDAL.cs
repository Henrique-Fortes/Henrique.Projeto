using HenriqueV5.Models.Registration.Contexts;
using HenriqueV5.Models.Tables;
using System.Data.Entity;
using System.Linq;

namespace Persistence.DAL.Tables

{
    public class CategoryDAL
    {
        private EFContext context = new EFContext();

        public IQueryable GetCategoriesClassifiedByName()

        {
            return context.Categories.OrderBy(n => n.Name);
        }
        public Category GetCategoryById(long id)
        {
            return context.Categories
                .Include("Products.Category").Where(c => c.CategoryId == id)
                
                .First();
        }
        public void RecordCategory(Category category)
        {
            if (category.CategoryId == null)
            {
                context.Categories.Add(category);
            }
            else
            {
                context.Entry(category)
                    .State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Category RemoveCategoryById(long id)
        {
            Category category = GetCategoryById(id);
            context.Categories.Remove(category);
            context.SaveChanges();
            return category;
        }

    }

}









    /*
    public class CategoryDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Category> GetCategoriesClassifiedByName()
        {
            return context.Categories.OrderBy(b => b.Name);
        }

    }
    */


