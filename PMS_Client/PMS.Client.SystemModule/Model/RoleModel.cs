using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.SystemModule.Model
{
    public class RoleModel
    {
        public bool IsSelected { get; set; }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDesc { get; set; }

        public List<string> MenuIds { get; set; }
        public List<int> UserIds { get; set; }
    }
}
