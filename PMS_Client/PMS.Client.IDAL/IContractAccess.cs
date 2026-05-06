using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.IDAL
{
    public interface IContractAccess
    {
        string GetDatas(string key, string start, string end, int index, int size);
        string UpdateInfo(string json);
        string DeleteInfo(int id);
        string ChangeState(int id, int state);

        string Execute(string json);
        string Archived(string json);
    }
}
