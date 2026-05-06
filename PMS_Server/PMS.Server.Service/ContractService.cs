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
    public class ContractService : IContractService
    {
        private ISqlSugarClient _client;

        public ContractService(ISqlSugarClient client)
        {
            _client = client;
        }

        public int Archived(ContractEntity contract)
        {
            return _client.Updateable<ContractEntity>()
                .SetColumns(fe => new ContractEntity 
                { 
                    State = 3,
                    ArchivedTime = contract.ArchivedTime,
                    ArchivedUserId = contract.ArchivedUserId,
                    ArchivedUserName = contract.ArchivedUserName,
                })
                .Where(oi => oi.ContractId == contract.ContractId).ExecuteCommand();
        }

        public int ChangeState(int id, int state)
        {
            return _client.Updateable<ContractEntity>()
                .SetColumns(fe => new ContractEntity { State = state })
                .Where(oi => oi.ContractId == id).ExecuteCommand();
        }

        public int DeleteInfo(int id)
        {
            return _client.Deleteable<ContractEntity>().In(id).ExecuteCommand();
        }

        public int Execute(ContractEntity contract)
        {
            return _client.Updateable<ContractEntity>()
                .SetColumns(fe => new ContractEntity
                {
                    State = contract.State,
                    ExcuteAmount = contract.ExcuteAmount,
                })
                .Where(bi => bi.ContractId == contract.ContractId).ExecuteCommand();
        }

        public ContractEntity[] GetDatas(string key, DateTime start, DateTime end, int index, int size, ref int totalCount)
        {
            return _client.Queryable<ContractEntity>()
                .Where(ce => ce.SignTime >= start && ce.SignTime <= end &&
                (string.IsNullOrEmpty(key) || ce.ContractName.Contains(key) || 
                ce.ContractNumber.Contains(key) || ce.Opposite.Contains(key))).ToPageList(index,size,ref totalCount).ToArray();
        }

        public int UpdateInfo(ContractEntity entity)
        {
            if (entity.ContractId == 0)
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
