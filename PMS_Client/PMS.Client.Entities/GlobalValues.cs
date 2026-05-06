using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Client.Entities
{
    public class GlobalValues
    {
        public string Token {  get; set; }

        public int UserId { get; set; }
        public string UserName { get; set; }

        public string ServerHost { get; set; }
    }
}
