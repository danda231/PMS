using PMS.Client.Entities;
using PMS.Client.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.Bll
{
    public class ServiceBase
    {
        public T GetResult<T>(string json)
        {
            var res = JsonUtil.Deserializer<Result<T>>(json);

            if (res == null)
                throw new Exception("数据获取失败");
            if (res.state != 200)
                throw new Exception(res.exceptionMessage);

            return res.data;
        }
    }
}
