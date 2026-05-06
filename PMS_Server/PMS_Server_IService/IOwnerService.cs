using PMS.Server.Entities;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Server.IService
{
    public interface IOwnerService
    {
        
        OwnerEntity[] GetOwners(ConditionEntity[] conditions, int pageIndex, int pageSize, ref int totalCount);

        QuarterEntity[] GetQuarters();

        BuildingEntity[] GetBuildingEntities();

        int UpdateOwner(OwnerEntity owner);

        int DeleteOwner(int id);

        //int UpdateOwners();
    }
}
