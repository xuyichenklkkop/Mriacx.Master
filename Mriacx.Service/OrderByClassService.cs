using Mriacx.Common.AttributeCollection;
using Mriacx.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mriacx.Service
{
    [AutoWired(typeof(IOrderService), "OrderByClassService")]
    public class OrderByClassService : IOrderService
    {
        public string GetTest()
        {
            return "OrderByClassService.GetTest";
        }
    }
}
