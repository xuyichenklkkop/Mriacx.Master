using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mriacx.Service;
using Mriacx.Service.Interface;

namespace Mriacx.Master.WebApi.Controllers
{
    [Route("[controller]")]
    public class OrderController :  ControllerBase
    {
        private readonly IOrderService service;

        public OrderController(IOrderService _service) {
            service = _service;
        }

        [HttpGet]
        public string Index()
        {   
            var result = service.GetTest();
            return result;
        }
    }
}
