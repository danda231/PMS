using PMS.Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.IBll
{
    public interface IOwnerService
    {
        PageEntity<OwnerEntity[]> GetOwners(ConditionEntity[] paramsJson, int index, int size);

        QuarterEntity[] GetQuareters();

        BuildingEntity[] GetBuildings();

        int UpdateOwners(OwnerEntity owner);

        int DeleteOwners(int id);
    }
}
