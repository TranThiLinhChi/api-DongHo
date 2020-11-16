using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{

    public partial interface IProductRespository
    {
        bool Create(ProductsModel model);

        bool Delete(string id);
        bool Edit(string id, ProductsModel model);
        ProductsModel GetDatabyID(string id);
        List<ProductsModel> GetDataAll();
        List<ProductsModel> Search(int pageIndex, int pageSize, out long total, string id_type);
        List<ProductsModel> GetProductRelated(int id, string category_id);
        List<ProductsModel> SearchName(string searchName);

        List<ProductsModel> GetDataNew();
    }
}
