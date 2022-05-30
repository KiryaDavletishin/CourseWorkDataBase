using System;
using System.Windows;
using CourseWork.Model1;

namespace CourseWork.View
{
    /// <summary>
    /// Логика взаимодействия для AddArchive.xaml
    /// </summary>
    public partial class AddArchive : Window
    {
        private int Id;
        private bool Flag;
        public AddArchive()
        {
            InitializeComponent();
        }

        public AddArchive(int id)
        {
            InitializeComponent();
            Id = id;
            Flag = true;
        }
        private bool CheckLoad()
        {
            if (!"".Equals(CodeDocumentBox.Text) && !"".Equals(CodeDocumentBox.Text))
            {
                try
                 {
                     Convert.ToInt32(CodeDocumentBox.Text);
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
                if (CheckLoad() && ArchiveModel.CreateArchive(Convert.ToInt32(CodeDocumentBox.Text), NameEmployeeBox.Text))
                {
                    Close();
                }
            if (Flag)
            {
                if (CheckLoad() && ArchiveModel.UpdateArchive(Id, Convert.ToInt32(CodeDocumentBox.Text), NameEmployeeBox.Text))
                {
                    Close();
                }
            }
        }


    }
}
