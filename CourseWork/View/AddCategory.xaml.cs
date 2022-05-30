using System.Windows;
using CourseWork.Model1;

namespace CourseWork.View
{
    /// <summary>
    /// Логика взаимодействия для AddCategory.xaml
    /// </summary>
    public partial class AddCategory : Window
    {
        private int Id;
        private bool Flag;
        public AddCategory(int id)
        {
            InitializeComponent();
            Id = id;
            Flag = true;
        }
        public AddCategory()
        {
            InitializeComponent();
        }

        private bool CheckLoad()
        {
            if (!"".Equals(NameBox.Text) && !"".Equals(ShortNameBox.Text))
                return true;
            else return false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Flag)
                if (CategoryModel.CreateСategory(NameBox.Text, ShortNameBox.Text) && CheckLoad())
                {
                    Close();
                }
            if(Flag)
            {
                if (CategoryModel.UpdateСategory(Id, NameBox.Text, ShortNameBox.Text) && CheckLoad())
                {
                    Close();
                }
            }
        }
    }
}
