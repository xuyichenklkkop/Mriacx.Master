using System;
using System.Collections.Generic;
using System.Text;

namespace Mriacx.Common.AttributeCollection
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class AutoWiredAttribute: Attribute
    {
        public Type RegisteredType { get; set; }

        public string AliasName { get; set; }


        public AutoWiredAttribute(Type registeredType, string name = null)
        {
            RegisteredType = registeredType;
            AliasName = name;
        }
    }
}
