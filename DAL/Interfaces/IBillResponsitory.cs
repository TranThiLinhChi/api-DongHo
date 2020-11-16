using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
   public partial interface IBillResponsitory
    {
        bool Create(BillModel model);
        bool Delete(string id);
        Thang ThongKeDoanhThuTheoThang();
        List<BillModel> GetAllBill();
        List<BillsDetailModel> GetBillByID(string id);
        List<BillsDetailModel> GetAllBillDetails();
    }
}
