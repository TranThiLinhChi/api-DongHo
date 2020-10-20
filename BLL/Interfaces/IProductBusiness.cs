using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IProductBusiness
    {
        bool Create(ProductsModel model);
        bool Edit(string id, ProductsModel model);
        bool Delete(string id);
        ProductsModel GetDatabyID(string id);
        List<ProductsModel> GetDataAll();
        List<ProductsModel> Search(int pageIndex, int pageSize, out long total, string id_type);
    }
}
