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
    public class OwnerService : IOwnerService
    {

        ISqlSugarClient _client;
        public OwnerService(ISqlSugarClient client)
        {
            _client = client;
        }

        public BuildingEntity[] GetBuildingEntities()
        {
            return _client.Queryable<BuildingEntity>().ToArray();
        }

        public OwnerEntity[] GetOwners(ConditionEntity[] conditions, int pageIndex, int pageSize, ref int totalCount)
        {
            var query = _client.Queryable<OwnerEntity>();

            var c = conditions.FirstOrDefault(c => c.Name == "HouseHolder");
            if (c != null)
                query.Where(o => o.HouseHolder.Contains(c.Value));

            c = conditions.FirstOrDefault(c => c.Name == "IdNumber");
            if (c != null)
                query.Where(o => o.IdNumber.Contains(c.Value));

            c = conditions.FirstOrDefault(c => c.Name == "Phone");
            if (c != null)
                query.Where(o => o.Phone.Contains(c.Value));

            c = conditions.FirstOrDefault(c => c.Name == "RoomNum");
            if (c != null)
                query.Where(o => o.RoomNum.Contains(c.Value));


            return query.Clone()                 
                .ToPageList(pageIndex, pageSize,ref totalCount).ToArray();

        }

        public QuarterEntity[] GetQuarters()
        {
            return _client.Queryable<QuarterEntity>().ToArray();
        }

        public int UpdateOwner(OwnerEntity owner)
        {
            if(owner.OwnerId == 0)
            {
                //新增
                return _client.Insertable<OwnerEntity>(owner).ExecuteCommand();
            }
            else
            {
                return _client.Updateable<OwnerEntity>(owner).ExecuteCommand();
            }
        }
        public int DeleteOwner(int id)
        {
            return _client.Deleteable<OwnerEntity>().In(id).ExecuteCommand();
        }
    }
}
