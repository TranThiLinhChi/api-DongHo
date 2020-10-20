using System;
using System.Collections.Generic;
using System.IO;
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
    public class ProductController : ControllerBase
    {
        private IProductBusiness _ProductBusiness;

        private string _path;
        public ProductController(IProductBusiness ProductBusiness, IConfiguration configuration)
        {
            _ProductBusiness = ProductBusiness;
            _path = configuration["AppSetting:PATH"];
        }
        public string SaveFileFromBase64String(string RelativePathFileName, string dataFromBase64String)
        {
            if (dataFromBase64String.Contains("base64,"))
            {
                dataFromBase64String = dataFromBase64String.Substring(dataFromBase64String.IndexOf("base64,", 0) + 7);
            }
            return WriteFileToAuthAccessFolder(RelativePathFileName, dataFromBase64String);
        }
        public string WriteFileToAuthAccessFolder(string RelativePathFileName, string base64StringData)
        {
            try
            {
                string result = "";
                string serverRootPathFolder = _path;
                string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
                string fullPathFolder = System.IO.Path.GetDirectoryName(fullPathFile);
                if (!Directory.Exists(fullPathFolder))
                    Directory.CreateDirectory(fullPathFolder);
                System.IO.File.WriteAllBytes(fullPathFile, Convert.FromBase64String(base64StringData));
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [Route("create-product")]
        [HttpPost]
        public ProductsModel CreateProduct([FromBody] ProductsModel model)
        {
            if (model.image_pro != null)
            {
                var arrData = model.image_pro.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/images/product/{arrData[0]}";
                    model.image_pro = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            _ProductBusiness.Create(model);
            return model;
        }
        [Route("update-product/{id}")]
        [HttpPost]
        public ProductsModel Edit(string id, [FromBody] ProductsModel model)
        {
            if (model.image_pro != null)
            {
                var arrData = model.image_pro.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/phukien/images/{arrData[0]}";
                    model.image_pro = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            _ProductBusiness.Edit(id, model);
            return model;
        }
        [Route("delete-product/{id}")]

        public bool Delete(string id)
        {
            return _ProductBusiness.Delete(id);

        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public ProductsModel GetDatabyID(string id)
        {
            return _ProductBusiness.GetDatabyID(id);
        }
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<ProductsModel> GetDatabAll()
        {
            return _ProductBusiness.GetDataAll();
        }

        [Route("search")]
        [HttpPost]
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string id_type = "";
                if (formData.Keys.Contains("id_type") && !string.IsNullOrEmpty(Convert.ToString(formData["id_type"]))) { id_type = Convert.ToString(formData["id_type"]); }
                long total = 0;
                var data = _ProductBusiness.Search(page, pageSize, out total, id_type);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
    }
}
