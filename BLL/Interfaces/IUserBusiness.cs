using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IUserBusiness
    {
        UserModel Authenticate(string username, string email);

        IEnumerable<UserModel> GetAll();
        UserModel GetById(string id);
        public bool Delete(string id);
        public bool Update(UserModel model);
        public bool Create(UserModel model);
        public List<UserModel> Search(int pageIndex, int pageSize, out long total, string hoten, string taikhoan);


    }
}
