using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.Entities
{
    // 客户端接收服务端数据做反序列化结构
    public class Result<T>
    {
        public int state { get; set; }

        public string exceptionMessage { get; set; }

        public T data { get; set; }
    }
}
