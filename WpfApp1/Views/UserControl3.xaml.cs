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
using WpfApp1.Service;
using WpfApp1.Views.Dialog;

namespace WpfApp1.Views
{
    /// <summary>
    /// UserControl3.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl3 : UserControl
    {
        private readonly MyRecordService _recordService;
        
        public UserControl3()
        {
            InitializeComponent();

            // 从DI容器中获取服务实例
            _recordService = App.ServiceProvider.GetRequiredService<MyRecordService>();

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var records = _recordService.GetAllRecords();
                RecordsDataGrid.ItemsSource = records;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载数据失败: {ex.Message}", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string searchText = SearchTextBox.Text?.Trim();
                var records = _recordService.SearchRecords(searchText);
                RecordsDataGrid.ItemsSource = records;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"查询失败: {ex.Message}", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Text = string.Empty;
            LoadData();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var editWindow = new EditWindow();
                editWindow.Owner = Window.GetWindow(this);
                
                if (editWindow.ShowDialog() == true && editWindow.IsConfirmed)
                {
                    _recordService.CreateRecord(editWindow.Record);
                    LoadData();
                    MessageBox.Show("新增成功!", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "输入错误", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"新增失败: {ex.Message}", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is Button button && button.Tag is MyRecord record)
                {
                    var editWindow = new EditWindow(record);
                    editWindow.Owner = Window.GetWindow(this);
                    
                    if (editWindow.ShowDialog() == true && editWindow.IsConfirmed)
                    {
                        _recordService.UpdateRecord(record.Id, editWindow.Record);
                        LoadData();
                        MessageBox.Show("修改成功!", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "输入错误", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"修改失败: {ex.Message}", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is Button button && button.Tag is MyRecord record)
                {
                    var result = MessageBox.Show($"确定要删除记录 '{record.Name}' 吗？", "确认删除", 
                        MessageBoxButton.YesNo, MessageBoxImage.Question);
                    
                    if (result == MessageBoxResult.Yes)
                    {
                        _recordService.DeleteRecord(record.Id);
                        LoadData();
                        MessageBox.Show("删除成功!", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "输入错误", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"删除失败: {ex.Message}", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
