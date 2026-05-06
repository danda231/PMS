using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.IDAL
{
    public interface IOwnerAccess
    {
        string GetOwners(string paramsJson, int index, int size);

        string GetQuareters();

        string GetBuildings();

        string UpdateOwners(string owner_Json);

        string DeleteOwners(int id);
    }
}
