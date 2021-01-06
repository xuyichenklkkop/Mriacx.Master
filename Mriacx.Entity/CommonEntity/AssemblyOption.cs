using System;
using System.Collections.Generic;
using System.Text;

namespace Mriacx.Entity.CommonEntity
{
    public class AssemblyOption
    {
        /// <summary>
        /// Business services
        /// </summary>
        public string Services { get; set; }

        /// <summary>
        /// Db Access service user for create dbcontext
        /// </summary>
        public string DataAccess { get; set; }
    }
}
