
using PMS.Client.Entities;
using PMS.Client.IBll;
using PMS.Client.IDAL;
using PMS.Client.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PMS.Client.Bll
{
    public class BaseInfoService : ServiceBase, IBaseInfoService
    {
        IBaseInfoAccess _baseInfoAccess;
        public BaseInfoService( IBaseInfoAccess baseInfoAccess)
        {
            _baseInfoAccess = baseInfoAccess;
        }

        public int CancelState(int id)
        {
            string json = _baseInfoAccess.CancelState(id);
            return this.GetResult<int>(json);
        }

        public int DeleteInfo(int id)
        {
            string json = _baseInfoAccess.DeleteInfo(id);
            return this.GetResult<int>(json);
        }

        public PageEntity<BaseInfo[]> GetInfoPage(string key, int index, int size)
        {
            string json = _baseInfoAccess.GetInfoPage(key, index, size);
            return this.GetResult<PageEntity<BaseInfo[]>>(json);
        }

        public int PublishState(int id)
        {
            string json = _baseInfoAccess.PublishState(id);
            return this.GetResult<int>(json);
        }

        public int RevokeState(int id)
        {
            string json = _baseInfoAccess.RevokeState(id);
            return this.GetResult<int>(json);
        }

        public int UpdateInfo(BaseInfo info)
        {
            string json = JsonUtil.Serializer(info);
            json = _baseInfoAccess.UpdateInfo(json);
            return this.GetResult<int>(json);
        }
    }
}
