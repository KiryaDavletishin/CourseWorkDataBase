using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseWork.Model1.DataBase;
using System.Data;

namespace CourseWork.Model1
{
    public static class ArchiveModel
    {
        public static bool CreateArchive(int Code, string name)
        {
            using (var context = new DocumentClassificationModuleEntities())
            {
                    var subject = new Archive()
                    {
                        Id = context.Archive.ToList()[context.Archive.ToList().Count - 1].Id + 1,
                        CodeId = Code, 
                        DateUpdate = DateTime.Now,
                        NameEmployee = name
                    };

                    context.Archive.Add(subject);
                    context.SaveChanges();
                    return true;
            }

        }

        public static void DeleteArchive(Archive subject)
        {
            using (var context = new DocumentClassificationModuleEntities())
            {
                context.Entry(subject).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public static bool UpdateArchive(int id, int codeId, string name)
        {
            using (var context = new DocumentClassificationModuleEntities())
            {
                bool check;
                check = context.Archive.Any(el => el.Id == id);
                if (check)
                {
                    Archive chanedСategory = context.Archive.FirstOrDefault(el => el.Id == id);
                    chanedСategory.CodeId = codeId;
                    chanedСategory.NameEmployee = name;
                    chanedСategory.DateUpdate = DateTime.Now;
                    context.SaveChanges();
                    return true;
                }
                else return false;
            }
        }

        public static List<Archive> GetArchives()
        {
            using (var context = new DocumentClassificationModuleEntities())
            {
                var result = context.Archive.ToList();
                return result;
            }

        }

        public static Archive GetArchive(int codeId)
        {
            using (var context = new DocumentClassificationModuleEntities())
            {
                var result = context.Archive.Where(el => el.CodeId.Equals(codeId)).FirstOrDefault();
                return result;
            }
        }
        public static List<Archive> GetArchiveCode(int code)
        {
            using (var context = new DocumentClassificationModuleEntities())
            {
                var result = (from category in context.Archive
                              where category.CodeId == code
                              select category).ToList();
                return result;
            }
        }
        public static List<Archive> GetArchiveName(string name)
        {
            using (var context = new DocumentClassificationModuleEntities())
            {
                var result = (from category in context.Archive
                              where category.NameEmployee == name
                              select category).ToList();
                return result;
            }
        }


    }
}
