using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryBusiness _itemGroupBusiness;
        public CategoryController(ICategoryBusiness itemGroupBusiness)
        {
            _itemGroupBusiness = itemGroupBusiness;
        }
        [Route("get-menu")]
        [HttpGet]
        public IEnumerable<CategoryModel> GetMenu()
        {
            return _itemGroupBusiness.GetData();
        }
        [Route("create-category")]
        [HttpPost]
        public CategoryModel CreateCategory([FromBody] CategoryModel model)
        {
            _itemGroupBusiness.Create(model);
            return model;
        }
        [Route("edit-category")]
        [HttpPost]
        public CategoryModel Edit(string id, [FromBody] CategoryModel model)
        {
            _itemGroupBusiness.Edit(id, model);
            return model;
        }
        [Route("delete-category")]

        public bool Delete(string id)
        {
            return _itemGroupBusiness.Delete(id);

        }
    }
}