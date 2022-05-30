using System;
using System.Windows;
using CourseWork.Model1;
namespace CourseWork.View
{
    /// <summary>
    /// Логика взаимодействия для AddDocument.xaml
    /// </summary>
    public partial class AddDocument : Window
    {
        private int Id;
        private bool Flag;
        public AddDocument()
        {
            InitializeComponent();

        }

        public AddDocument(int id)
        {
            InitializeComponent();
            Id = id;
            Flag = true;
        }
        private bool CheckLoad()
        {
            if (!"".Equals(TitleBox.Text) && !"".Equals(CodeCategoryBox.Text) && !"".Equals(DescriptionBox.Text) && !"".Equals(YearCreationBox.Text) && !"".Equals(AuthorBox.Text))
            {
                try
                {
                    Convert.ToInt32(CodeCategoryBox.Text);
                    Convert.ToInt32(YearCreationBox.Text);
                }
                catch (FormatException)
                {
                    return false;
                }
                return true;
            }
            else return false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Flag)
                if (CheckLoad() && DocumentModel.CreateDocument(TitleBox.Text, Convert.ToInt32(CodeCategoryBox.Text), DescriptionBox.Text, Convert.ToInt32(YearCreationBox.Text), AuthorBox.Text))
                {
                    Close();
                }
            if (Flag)
            {
                if (CheckLoad() && DocumentModel.UpdateDocument(Id, Convert.ToInt32(CodeCategoryBox.Text), TitleBox.Text, DescriptionBox.Text, Convert.ToInt32(YearCreationBox.Text), AuthorBox.Text))
                {
                    Close();
                }
            }
        }
    }
}
