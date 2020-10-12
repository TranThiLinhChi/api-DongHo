using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private IBillBusiness _hoaDonBusiness;
        public BillController(IBillBusiness hoaDonBusiness)
        {
            _hoaDonBusiness = hoaDonBusiness;
        }

        [Route("create-bill")]
        [HttpPost]
        public BillModel CreateItem([FromBody] BillModel model)
        {
            model.id = Guid.NewGuid().ToString();
            if (model.listjson_chitiet != null)
            {
                foreach (var item in model.listjson_chitiet)
                    item.id = Guid.NewGuid().ToString();
            }
            _hoaDonBusiness.Create(model);
            return model;
        }
    }
}
