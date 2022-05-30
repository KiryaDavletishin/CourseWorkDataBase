using System.Collections.Generic;
using System.Linq;
using CourseWork.Model1.DataBase;

namespace CourseWork.Model1
{
    public static class CategoryModel
    {
        public static bool CreateСategory(string title, string shortTitle)
        {
            using (var context = new DocumentClassificationModuleEntities())
            {

                var subject = new Category()
                {
                    Id = context.Category.ToList()[context.Category.ToList().Count - 1].Id + 1,
                    Title = title,
                    ShortTitle = shortTitle
                };


                context.Category.Add(subject);
                context.SaveChanges();
                return true;
            }

        }

        public static void DeleteСategory(Category subject)
        {
            using (var context = new DocumentClassificationModuleEntities())
            {
                context.Entry(subject).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public static bool UpdateСategory(int Id, string title, string shortTitle)
        {
            using (var context = new DocumentClassificationModuleEntities())
            {
                bool check;
                check = context.Category.Any(el => el.Id == Id);
                if (check)
                {
                    Category chanedСategory = context.Category.FirstOrDefault(el => el.Id == Id);
                    chanedСategory.Title = title;
                    chanedСategory.ShortTitle = shortTitle;
                    context.SaveChanges();
                    return true;
                }
                else return false;
            }
        }

        public static List<Category> GetСategories()
        {
            using (var context = new DocumentClassificationModuleEntities())
            {
                var result = context.Category.ToList();
                return result;
            }

        }

        public static Category GetCategory(int id)
        {
            using (var context = new DocumentClassificationModuleEntities())
            {
                var result = context.Category.Where(el => el.Id.Equals(id)).FirstOrDefault();
                return result;
            }
        }
        public static List<Category> GetCategoryTitle(string title)
        {
            using (var context = new DocumentClassificationModuleEntities())
            {

                var result = context.Category
                .Where(b => b.Title == title).ToList();
                return result;
            }
        }

    }
}
