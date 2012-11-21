using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoeJoyHelper.Model
{
    /// <summary>
    /// 新用户注册模型类
    /// </summary>
    public class NewRegisterCustomerModel
    {
        public string CustomerID { get; set; }
        public string PassWordInput1 { get; set; }
        public string PassWordInput2 { get; set; }
        public string CustomerEmail { get; set; }
    }
}
