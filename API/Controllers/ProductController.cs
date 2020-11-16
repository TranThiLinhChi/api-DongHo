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
        private string _pathh;

        public ProductController(IProductBusiness productBusiness, IConfiguration configuration)
        {
            _ProductBusiness = productBusiness;
            _path = configuration["AppSettings:PATH"];
            _pathh = configuration["AppSettings:PATHH"];
        }
        //admin image
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
        //home image
        public string SaveFileFromBase64(string RelativePathFile, string dataFromBase64)
        {
            if (dataFromBase64.Contains("base64,"))
            {
                dataFromBase64 = dataFromBase64.Substring(dataFromBase64.IndexOf("base64,", 0) + 7);
            }
            return WriteFileHome(RelativePathFile, dataFromBase64);
        }
        public string WriteFileHome(string RelativePathFile, string base64Data)
        {
            try
            {
                string result = "";
                string serverRootPathFolderHome = _pathh;
                string fullPathFileHome = $@"{serverRootPathFolderHome}\{RelativePathFile}";
                string fullPathFolderHome = System.IO.Path.GetDirectoryName(fullPathFileHome);
                if (!Directory.Exists(fullPathFolderHome))
                    Directory.CreateDirectory(fullPathFolderHome);
                System.IO.File.WriteAllBytes(fullPathFileHome, Convert.FromBase64String(base64Data));
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
                    var savePath = $@"{arrData[0]}";
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
                    var savePath = $@"{arrData[0]}";
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
        [Route("get-product-related/{id}/{category_id}")]
        [HttpGet]
        public IEnumerable<ProductsModel> GetProductRelated(int id, string category_id)
        {
            return _ProductBusiness.GetProductRelated(id, category_id);
        }
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<ProductsModel> GetDatabAll()
        {
            return _ProductBusiness.GetDataAll();
        }
        [Route("search-name/{searchName}")]
        [HttpGet]
        public IEnumerable<ProductsModel> SearchName(string searchName)
        {
            return _ProductBusiness.SearchName(searchName);
        }
        [Route("get-new")]
        [HttpGet]
        public IEnumerable<ProductsModel> GetDataNew()
        {
            return _ProductBusiness.GetDataNew();
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
