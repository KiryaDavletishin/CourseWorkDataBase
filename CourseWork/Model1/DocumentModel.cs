using System;
using System.Collections.Generic;
using System.Linq;
using CourseWork.Model1.DataBase;

namespace CourseWork.Model1
{
    public static class DocumentModel
    {
        public static bool CreateDocument(string title, int CodeCategory, string description, int year, string author)
        {
            using (var context = new DocumentClassificationModuleEntities())
            {
                bool check = context.Document.Any(el => el.Title == title);
                if (!check)
                {
                    var subject = new Document()
                    {
                        DocumentId = context.Document.ToList()[context.Document.ToList().Count - 1].DocumentId + 1,
                        Title = title,
                        Description = description,
                        CodeCategory = CodeCategory,
                        YearCreation = year,
                        Author = author,
                    };
                    context.Document.Add(subject);
                    context.SaveChanges();
                    return true;
                }
                else return false;
            }

        }

        public static void DeleteDocument(Document teacher)
        {
            using (var context = new DocumentClassificationModuleEntities())
            {
                context.Entry(teacher).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public static bool UpdateDocument(int id, int CodeCategory, string title, string description, int year, string author)
        {
            using (var context = new DocumentClassificationModuleEntities())
            {
                bool check;
                check = context.Document.Any(el => el.DocumentId == id);
                if (check)
                {
                    Document chanedTeacher = context.Document.FirstOrDefault(el => el.DocumentId == id);
                    chanedTeacher.Title = title;
                    chanedTeacher.Description = description;
                    chanedTeacher.CodeCategory = CodeCategory;
                    chanedTeacher.YearCreation = year;
                    chanedTeacher.Author = author;
                    context.SaveChanges();
                    return true;
                }
                else return false;
            }
        }

        public static List<Document> GetDocuments()
        {
            using (var context = new DocumentClassificationModuleEntities())
            {
                var result = context.Document.ToList();
                return result;
            }

        }

        public static Document GetDocument(int id)
        {
            using (var context = new DocumentClassificationModuleEntities())
            {
                var result = context.Document.Where(el => el.DocumentId == id).FirstOrDefault();
                return result;
            }
        }

        public static List<Document> GetDocumentTitle(string title)
        {
            using (var context = new DocumentClassificationModuleEntities())
            {

                var result = context.Document
                .Where(b => b.Title == title).ToList();
                return result;
            }
        }

        public static List<Document> GetDocumentCode(int code)
        {
            using (var context = new DocumentClassificationModuleEntities())
            {
                var result = (from category in context.Document
                              where category.CodeCategory == code
                              select category).ToList();
                return result;
            }
        }

        public static List<Document> GetDocumentYear(int year)
        {
            using (var context = new DocumentClassificationModuleEntities())
            {
                var result = (from category in context.Document
                              where category.YearCreation == year
                              select category).ToList();
                return result;
            }
        }

        public static List<Document> GetDocumentAuthor(string nameAuthor)
        {
            using (var context = new DocumentClassificationModuleEntities())
            {

                var result = context.Document
                .Where(b => b.Author == nameAuthor).ToList();
                return result;
            }
        }
    }
}
