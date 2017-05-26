using HenriqueV5.Models.Tables;
using Persistence.DAL.Tables;
using System.Linq;

namespace Service.Tables
{
    public class CategoryService
    {


        private CategoryDAL categoryDAL = new CategoryDAL();
        public IQueryable GetCategoriesClassifiedByName()
        {
            return categoryDAL.GetCategoriesClassifiedByName();
        }
        public Category GetCategoryById(long id)
        {
            return categoryDAL.GetCategoryById(id);
        }
        public void RecordCategory(Category category)
        {
            categoryDAL.RecordCategory(category);
        }
        public Category RemoveCategoryById(long id)
        {
            return categoryDAL.RemoveCategoryById(id);
        }















        /*
        private CategoryDAL categoryDAL = new CategoryDAL();
        public IQueryable<Category>
            GetCategoriesClassifiedByName()
        {
            return categoryDAL.GetCategoriesClassifiedByName();
        }
        public Category GetCategoryById(long id)
        {
            return categoryDAL.GetCategoryById(id);
        }
        public void RecordCategory(Category category)
        {
            categoryDAL.RecordCategory(category);
        }
        public Category RemoveCategoryById(long id)
        {
            return categoryDAL.RemoveCategoryById(id);
        }
        */
    }
}
