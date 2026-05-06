using PMS.Client.Entities;
using PMS.Client.IBll;
using PMS.Client.IDAL;
using PMS.Client.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.Bll
{
    public class OwnerService : ServiceBase, IOwnerService
    {
        private IOwnerAccess _ownerAccess;

        public OwnerService(IOwnerAccess ownerAccess)
        {
            _ownerAccess = ownerAccess;
        }

        public int DeleteOwners(int id)
        {
            string json = _ownerAccess.DeleteOwners(id);
            return this.GetResult<int>(json);
        }

        public BuildingEntity[] GetBuildings()
        {
            string json = _ownerAccess.GetBuildings();
            return this.GetResult<BuildingEntity[]>(json);
        }

        public PageEntity<OwnerEntity[]> GetOwners(ConditionEntity[] paramsJson, int index, int size)
        {
            string json = JsonUtil.Serializer(paramsJson);
            json = _ownerAccess.GetOwners(json, index, size);
            return this.GetResult<PageEntity<OwnerEntity[]>>(json);
        }

        public QuarterEntity[] GetQuareters()
        {
            string json = _ownerAccess.GetQuareters();
            return this.GetResult<QuarterEntity[]>(json);
        }

        public int UpdateOwners(OwnerEntity owner)
        {
            string json = JsonUtil.Serializer(owner);
            json = _ownerAccess.UpdateOwners(json);
            return this.GetResult<int>(json);
        }
    }
}
