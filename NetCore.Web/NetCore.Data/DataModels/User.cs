using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Data.DataModels
{
    /// <summary>
    /// C# Class   => Database Table
    /// Member변수 => Table Column
    /// </summary>
    public class User
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public DateTime JoinUtcDate { get; set; }
    }
}
