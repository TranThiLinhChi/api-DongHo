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
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public List<BillModel> GetAllBill()
        {
            return _res.GetAllBill();
        }
        public List<BillsDetailModel> GetBillByID(string id)
        {
            return _res.GetBillByID(id);
        }
        public List<BillsDetailModel> GetAllBillDetails()
        {
            return _res.GetAllBillDetails();
        }
        public Thang ThongKeDoanhThuTheoThang()
        {
            return _res.ThongKeDoanhThuTheoThang();
        }
    }
}
