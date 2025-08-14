using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Bean;
using WpfApp1.Dao;
using WpfApp1.Dao.Repository;

namespace WpfApp1.SubPage
{
    /// <summary>
    /// UserControl3.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl3 : UserControl
    {
        private readonly MyRecordRepository _recordRepository;
        public UserControl3()
        {
            InitializeComponent();

            // 从DI容器中获取服务实例
            _recordRepository = App.ServiceProvider.GetRequiredService<MyRecordRepository>();

            ThisListBox.ItemsSource = LoadDataFromDatabase();

        }


        private List<MyRecord> LoadDataFromDatabase()
        {

            // 3. 将数据绑定到UI控件（例如 DataGrid）
            // 假设你的窗口中有一个名为 "myDataGrid" 的 DataGrid 控件
            return _recordRepository.GetAll();

            // 或者，如果你使用的是 MVVM 模式，将数据赋值给 ViewModel 的属性
            // ViewModel.Records = records;
        }


    }
}
