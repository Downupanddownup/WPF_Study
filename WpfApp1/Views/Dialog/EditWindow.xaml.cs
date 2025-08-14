using System.Windows;
using WpfApp1.Bean;

namespace WpfApp1.Views.Dialog
{
    public partial class EditWindow : Window
    {
        public MyRecord Record { get; private set; }
        public bool IsConfirmed { get; private set; }

        public EditWindow(MyRecord record = null)
        {
            InitializeComponent();
            
            if (record != null)
            {
                Record = record;
                NameTextBox.Text = record.Name;
                Title = "编辑记录";
            }
            else
            {
                Record = new MyRecord();
                Title = "新增记录";
            }
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("请输入名称", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Record.Name = NameTextBox.Text.Trim();
            IsConfirmed = true;
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            IsConfirmed = false;
            DialogResult = false;
            Close();
        }
    }
}