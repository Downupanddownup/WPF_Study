using System;
using System.Collections.Generic;
using WpfApp1.Bean;
using WpfApp1.Dao.Repository;

namespace WpfApp1.Service
{
    public class MyRecordService
    {
        private readonly MyRecordRepository _recordRepository;

        public MyRecordService(MyRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }

        /// <summary>
        /// 获取所有记录
        /// </summary>
        public List<MyRecord> GetAllRecords()
        {
            return _recordRepository.GetAll();
        }

        /// <summary>
        /// 搜索记录
        /// </summary>
        /// <param name="searchText">搜索关键词</param>
        public List<MyRecord> SearchRecords(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return GetAllRecords();
            }
            return _recordRepository.Search(searchText.Trim());
        }

        /// <summary>
        /// 创建新记录
        /// </summary>
        /// <param name="record">要创建的记录</param>
        public void CreateRecord(MyRecord record)
        {
            // 数据验证
            ValidateRecord(record);
            
            // 数据处理
            record.Name = record.Name.Trim();
            
            // 调用数据层
            _recordRepository.Insert(record);
        }

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="id">记录ID</param>
        /// <param name="record">更新的记录数据</param>
        public void UpdateRecord(int id, MyRecord record)
        {
            // 数据验证
            ValidateRecord(record);
            
            // 数据处理
            record.Name = record.Name.Trim();
            
            // 调用数据层
            _recordRepository.Update(id, record);
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="id">记录ID</param>
        public void DeleteRecord(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("无效的记录ID");
            }
            
            _recordRepository.Delete(id);
        }

        /// <summary>
        /// 验证记录数据
        /// </summary>
        /// <param name="record">要验证的记录</param>
        private void ValidateRecord(MyRecord record)
        {
            if (record == null)
            {
                throw new ArgumentNullException(nameof(record), "记录不能为空");
            }

            if (string.IsNullOrWhiteSpace(record.Name))
            {
                throw new ArgumentException("名称不能为空");
            }

            if (record.Name.Trim().Length > 100)
            {
                throw new ArgumentException("名称长度不能超过100个字符");
            }
        }
    }
}