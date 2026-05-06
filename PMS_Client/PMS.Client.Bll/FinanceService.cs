using PMS.Client.Entities;
using PMS.Client.IBll;
using PMS.Client.IDAL;
using PMS.Client.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.Bll
{
    public class FinanceService : ServiceBase, IFinanceService
    {
        IFinanceAccess _financeAccess;

        public FinanceService(IFinanceAccess financeAccess)
        {
            _financeAccess = financeAccess;
        }

        public int ChangeState(int id, int state)
        {
            string json = _financeAccess.ChangeState(id, state);
            return this.GetResult<int>(json);
        }

        public int DeleteInfo(int id)
        {
            string json = _financeAccess.DeleteInfo(id);
            return this.GetResult<int>(json);
        }

        public PageEntity<IEEntity[]> GetDatas(string key, DateTime start, DateTime end, int index, int size)
        {
            key = string.IsNullOrEmpty(key) ? "none" : key;
            string json = _financeAccess.GetDatas(key, 
                start.ToString("yyyy-MM-dd"), end.ToString("yyyy-MM-dd 23:59:59"), 
                index, size);
            return this.GetResult<PageEntity<IEEntity[]>>(json);
        }

        public int UpdateInfo(IEEntity entity)
        {
            string json = JsonUtil.Serializer(entity);
            json = _financeAccess.UpdateInfo(json);
            return this.GetResult<int>(json);
        }
    }
}
