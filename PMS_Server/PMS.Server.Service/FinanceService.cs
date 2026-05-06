using PMS.Server.Entities;
using PMS.Server.IService;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Server.Service
{
    public class FinanceService : IFinanceService
    {
        ISqlSugarClient _client;

        public FinanceService(ISqlSugarClient client)
        {
            _client = client;
        }

        public int ChangeState(int id, int state)
        {
            return _client.Updateable<IEEntity>()
                .SetColumns(fe => new IEEntity { State = state })
                .Where(oi => oi.IEID == id).ExecuteCommand();
        }

        public int DeleteInfo(int id)
        {
            return _client.Deleteable<IEEntity>().In(id).ExecuteCommand();
        }

        public IEEntity[] GetDatas(string key, DateTime start, DateTime end, int index, int size, ref int totalCount)
        {
            return _client.Queryable<IEEntity>()
                    .Where(ie => ie.HappendTime >= start && ie.HappendTime <= end && 
                    (string.IsNullOrEmpty(key) || 
                    ie.AmountDesc.Contains(key) || ie.ProjectName.Contains(key)))
                    .ToPageList(index, size, ref totalCount)
                    .ToArray();
        }

        public int UpdateInfo(IEEntity entity)
        {
            if(entity.IEID == 0)
            {
                return _client.Insertable(entity).ExecuteCommand();
            }
            else
            {
                return _client.Updateable(entity).ExecuteCommand();
            }
        }
    }
}
