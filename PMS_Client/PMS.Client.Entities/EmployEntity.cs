using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.Entities
{
    public class EmployEntity
    {
        public int EId { get; set; }

        public string UserName { get; set; }

        public string RealName { get; set; }

        public string Password { get; set; }

        public int Status { get; set; }

        public int Age { get; set; }

        public int Gender { get; set; }

        public string EIcon { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string QQ { get; set; }

        public string WeChat { get; set; }

        public string LastLoginTime { get; set; }

        public string CreateTime { get; set; }

        public int CreateId { get; set; }

        public string LastModifyTime { get; set; }

        public int LastModifyId { get; set; }
    }
}
