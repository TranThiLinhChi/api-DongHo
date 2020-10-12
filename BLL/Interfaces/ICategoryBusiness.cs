using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
   public partial interface ICategoryBusiness
    {
        public List<CategoryModel> GetData();
    }
}
