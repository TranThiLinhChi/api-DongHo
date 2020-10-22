using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface IUserResponsitory
    {
        UserModel GetUser(string usename, string password);
        IEnumerable<UserModel> GetAll();
        UserModel GetById(string id);
        bool Create(UserModel model);
        bool Update(UserModel model);
        bool Delete(string id);
        List<UserModel> Search(int pageIndex, int pageSize, out long total, string name, string username);

    }
}
