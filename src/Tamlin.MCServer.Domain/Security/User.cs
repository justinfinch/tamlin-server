using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamlin.MCServer.Domain.Security
{
    public class User
    {
        public int pk_mcuser { get; set; }
        public string cuserid { get; set; }
        public string cpassword { get; set; }
        public string cusername { get; set; }
        public string cdept { get; set; }
        public string cgroup { get; set; }
        public string cwarehouse { get; set; }
        public string cstation { get; set; }
    }
}
