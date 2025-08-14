using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Enums
{
    static class PageTypeExtensions
    {
        // 扩展方法：获取枚举成员的描述（或你想要的文本）
        public static string GetDescription(this PageType pageType)
        {
            switch (pageType)
            {
                case PageType.PAGE1:
                    return "页面1";
                case PageType.PAGE2:
                    return "页面2";
                case PageType.PAGE3:
                    return "页面3";
                default:
                    return pageType.ToString(); // 默认返回枚举成员名
            }
        }


        // 新增：获取按钮文本，负责拼接字符串
        public static string GetButtonText(this PageType pageType)
        {
            // 通过调用 GetNext() 获得下一个页面类型，然后获取其描述
            return $"当前{pageType.GetDescription()}，切换下一页";
        }

    }
}
