using Mriacx.Common.AttributeCollection;
using Mriacx.Service.Interface;
using System;

namespace Mriacx.Service
{
    [AutoWired(typeof(IOrderService), "OrderService")]
    public class OrderService: IOrderService
    {
        public string GetTest()
        {
            return "OrderService.GetTest";
        }
    }
}
