using PMS.Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.IDAL
{
    public interface IFinanceAccess
    {
        string GetDatas(string key, string start, string end, int index, int size);

        string UpdateInfo(string json);
        string DeleteInfo(int id);
        string ChangeState(int id, int state);
    }
}
