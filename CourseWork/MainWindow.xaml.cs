using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CourseWork.View;
using CourseWork.Model1.DataBase;
using CourseWork.Model1;
using System.Windows.Forms;
using System.Data.Entity;

namespace CourseWork
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ListView AllCategoriesView;
        public static ListView AllDocumentView;
        public static ListView AllArchiveView;

        public MainWindow()
        {

            InitializeComponent();
            AllCategoriesView = new ListView();
            ShowCategory(CategoryModel.GetСategories());
            ShowArchive(ArchiveModel.GetArchives());
            ShowDocument(DocumentModel.GetDocuments());
        }
        private void SetCentralPosition(Window window)
        { 
            window.Owner = System.Windows.Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddCategory category = new AddCategory();
            SetCentralPosition(category);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddDocument category = new AddDocument();
            SetCentralPosition(category);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddArchive category = new AddArchive();
            SetCentralPosition(category);
        }
        
        private void ShowCategory(List<Category> categories)
        {
            /*AllCategoriesView.Items.Clear();
            foreach (var category in categories)
            {
                var item = new ListViewItem();
                item.SubItems.Add(category.Id.ToString());
                item.SubItems.Add(category.Title);
                item.SubItems.Add(category.ShortTitle);
                AllCategoriesView.Items.Add(item);
            }*/
            using (var context = new DocumentClassificationModuleEntities())
            {
                AllCategoriesView = context.Category.Local.ToBindingList();
            }

        }

        private void ShowDocument(List<Document> documents)
        {
            ViewAllDocuments.Items.Clear();
            foreach (var category in documents)
            {
                var item = new ListViewItem();
                item.SubItems.Add(category.DocumentId.ToString());
                item.SubItems.Add(category.Title);
                item.SubItems.Add(category.Description);
                item.SubItems.Add(category.CodeCategory.ToString());
                item.SubItems.Add(category.YearCreation.ToString());
                item.SubItems.Add(category.Author);
                ViewAllDocuments.Items.Add(item);
            }
        }

        private void ShowArchive(List<Archive> archives)
        {
            ViewAllArchives.Items.Clear();
            foreach (var category in archives)
            {
                var item = new ListViewItem();
                item.SubItems.Add(category.Id.ToString());
                item.SubItems.Add(category.CodeId.ToString());
                item.SubItems.Add(category.DateUpdate.ToString());
                item.SubItems.Add(category.NameEmployee);
                ViewAllArchives.Items.Add(item);
            }
        }

       private void Category_Update_Click(object sender, RoutedEventArgs e)
        {
            AddCategory category = new AddCategory(0);
            SetCentralPosition(category);
            ShowCategory(CategoryModel.GetСategories());
        }

        private void Category_Delete_Click(object sender, RoutedEventArgs e)
        {
            CategoryModel.DeleteСategory(CategoryModel.GetCategory(CategoryModel.GetСategories().Count));
            ShowCategory(CategoryModel.GetСategories());
        }

        private void Category_Search_Title_Click(object sender, RoutedEventArgs e)
        {
     
            ShowCategory(CategoryModel.GetCategoryTitle("Kirill"));
        }

        private void Category_AllData_Click(object sender, RoutedEventArgs e)
        {
            ShowCategory(CategoryModel.GetСategories());
        }
        
        private void Document_Update_Click(object sender, RoutedEventArgs e)
        {
            AddDocument document = new AddDocument(0);
            SetCentralPosition(document);
            ShowDocument(DocumentModel.GetDocuments());
        }
        
        private void Document_Delete_Click(object sender, RoutedEventArgs e)
        {

            DocumentModel.DeleteDocument(DocumentModel.GetDocument(DocumentModel.GetDocuments().Count - 1));
            ShowDocument(DocumentModel.GetDocuments());
        }
        
        private void Document_Title_Click(object sender, RoutedEventArgs e)
        {
            ShowDocument(DocumentModel.GetDocumentTitle("title1"));
        }
        private void Document_Code_Categoty_Click(object sender, RoutedEventArgs e)
        {
            ShowDocument(DocumentModel.GetDocumentCode(1));
        }
        private void Document_Year_Creation_Click(object sender, RoutedEventArgs e)
        {
            ShowDocument(DocumentModel.GetDocumentYear(2022));
        }
        private void Document_Author_Click(object sender, RoutedEventArgs e)
        {
            ShowDocument(DocumentModel.GetDocumentAuthor("me"));
        }
        private void Document_Show_All_Click(object sender, RoutedEventArgs e)
        {
            ShowDocument(DocumentModel.GetDocuments());
        }
        private void Archive_Update_Click(object sender, RoutedEventArgs e)
        {
            AddArchive document = new AddArchive(0);
            SetCentralPosition(document);
            ShowArchive(ArchiveModel.GetArchives());
        }

        private void Archive_Delete_Click(object sender, RoutedEventArgs e)
        {

            ArchiveModel.DeleteArchive(ArchiveModel.GetArchive(ArchiveModel.GetArchives().Count - 1));
            ShowArchive(ArchiveModel.GetArchives());
        }
        private void Archive_Code_Document_Click(object sender, RoutedEventArgs e)
        {
            ShowArchive(ArchiveModel.GetArchiveCode(1));
        }

        private void Archive_Name_Employee_Click(object sender, RoutedEventArgs e)
        {
            ShowArchive(ArchiveModel.GetArchiveName("asdfghj"));
        }
        private void Archive_Show_All_Click(object sender, RoutedEventArgs e)
        {
            ShowArchive(ArchiveModel.GetArchives());
        }
    }
}
