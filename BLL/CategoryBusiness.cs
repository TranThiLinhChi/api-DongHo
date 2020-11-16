using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class CategoryBusiness : ICategoryBusiness
    {
        private ICategoryResponsitory _res;
        public CategoryBusiness(ICategoryResponsitory ItemGroupRes)
        {
            _res = ItemGroupRes;
        }

        public bool Create(CategoryModel model)
        {
            return _res.Create(model);
        }

        public bool Edit(string id, CategoryModel model)
        {
            return _res.Edit(id, model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public List<CategoryModel> GetData()
        {
            var allItemGroups = _res.GetData();
            var lstParent = allItemGroups.Where(ds => ds.parent_id == null).OrderBy(s => s.seq_num).ToList();
            foreach (var item in lstParent)
            {
                item.children = GetHiearchyList(allItemGroups, item);
            }
            return lstParent;
        }
        public List<CategoryModel> GetHiearchyList(List<CategoryModel> lstAll, CategoryModel node)
        {
            var lstChilds = lstAll.Where(ds => ds.parent_id == node.id).ToList();
            if (lstChilds.Count == 0)
                return null;
            for (int i = 0; i < lstChilds.Count; i++)
            {
                var childs = GetHiearchyList(lstAll, lstChilds[i]);
                lstChilds[i].type = (childs == null || childs.Count == 0) ? "leaf" : "";
                lstChilds[i].children = childs;
            }
            return lstChilds.OrderBy(s => s.seq_num).ToList();
        }

    }
}
