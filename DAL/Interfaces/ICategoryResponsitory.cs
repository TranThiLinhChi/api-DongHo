using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
   public partial interface ICategoryResponsitory
    {
        bool Create(CategoryModel model);
        bool Delete(string id);
        bool Edit(string id, CategoryModel model);
        public List<CategoryModel> GetData();
    }
}
