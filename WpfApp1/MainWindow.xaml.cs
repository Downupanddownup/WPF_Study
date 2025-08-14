using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Enums;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PageType _pageType; // 1 for UserControl1, 2 for UserControl2

        public MainWindow()
        {
            InitializeComponent();
            switch_page(PageType.PAGE1);
        }

        private void switch_page(PageType type)
        {
            switch (type)
            {
                case PageType.PAGE1:
                    ShowContent.Content = new UserControl1();
                    _pageType = PageType.PAGE1;
                    break;
                case PageType.PAGE2:
                    ShowContent.Content = new UserControl2();
                    _pageType = PageType.PAGE2;
                    break;
                case PageType.PAGE3:
                    ShowContent.Content = new SubPage.UserControl3();
                    _pageType = PageType.PAGE3;
                    break;
            }
            Switch2.Content = _pageType.GetButtonText(); // 更新按钮文本
        }

        private void Switch2_Click(object sender, RoutedEventArgs e)
        {
            if (_pageType == PageType.PAGE1)
            {
                this.switch_page(PageType.PAGE2);
            }
            else if (_pageType == PageType.PAGE2)
            {
                this.switch_page(PageType.PAGE3);
            }
            else
            {
                this.switch_page(PageType.PAGE1);
            }
        }
    }
}