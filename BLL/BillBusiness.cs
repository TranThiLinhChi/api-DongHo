using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial class BillBusiness : IBillBusiness
    {
        private IBillResponsitory _res;
        public BillBusiness(IBillResponsitory res)
        {
            _res = res;
        }
        public bool Create(BillModel model)
        {
            return _res.Create(model);
        }
    }
}
