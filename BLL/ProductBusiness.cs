using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{

    public partial class ProductBusiness : IProductBusiness
    {
        private IProductRespository _res;
        public ProductBusiness (IProductRespository ProductGroupRes)
        {
            _res = ProductGroupRes;
        }
        public bool Create(ProductsModel model)
        {
            return _res.Create(model);
        }
        public bool Edit(string id, ProductsModel model)
        {
            return _res.Edit(id, model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public ProductsModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<ProductsModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public List<ProductsModel> Search(int pageIndex, int pageSize, out long total, string id_type)
        {
            return _res.Search(pageIndex, pageSize, out total, id_type);
        }
    }
}
