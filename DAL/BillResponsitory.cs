using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{

    public partial class BillRepository : IBillResponsitory
    {
        private IDatabaseHelper _dbHelper;
        public BillRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool Create(BillModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_Bill_create",
                "@id", model.id,
                "@name", model.name,
                "@total", model.total,
                "@address", model.address,
                "@phone", model.phone,
                 "@email",model.email,
                "@listjson_chitiet", model.listjson_chitiet != null ? MessageConvert.SerializeObject(model.listjson_chitiet) : null);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
