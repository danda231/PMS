using PMS.Server.Entities;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Server.IService
{
    public interface IContractService
    {
        ContractEntity[] GetDatas(string key, DateTime start, DateTime end, int index, int size, ref int totalCount);

        int UpdateInfo(ContractEntity entity);

        int DeleteInfo(int id);

        int ChangeState(int id, int state);

        int Execute(ContractEntity contract);

        int Archived(ContractEntity contract);

    }
}
