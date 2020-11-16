using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserBusiness _userBusiness;

        public UsersController(IUserBusiness userService)
        {
            _userBusiness = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            var user = _userBusiness.Authenticate(model.username, model.password);

            if (user == null)
                return BadRequest(new { message = "Tài khoản hoặc mật khẩu không hợp lệ!" });

            return Ok(user);
        }

        //[Authorize(Roles = Role.User)]
        [AllowAnonymous]
        [HttpGet]
        [Route("get-all")]
        public IActionResult GetAll()
        {
            var users = _userBusiness.GetAll();
            return Ok(users);
        }

        //[Authorize(Roles = Role.User)]
        
        [HttpGet("get-by-id/{id}")]
        public IActionResult GetById(string id)
        {
            // only allow admins to access other user records
            var currentUserId = int.Parse(User.Identity.Name);
            //  if (id != currentUserId && !User.IsInRole(Role.Admin))
            //      return Forbid();

            var user = _userBusiness.GetById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [Route("delete-user")]
        [HttpPost]
        public IActionResult DeleteUser([FromBody] Dictionary<string, object> formdata)
        {
            string user_id = "";
            if (formdata.Keys.Contains("user_id") && !string.IsNullOrEmpty(Convert.ToString(formdata["user_id"]))) { user_id = Convert.ToString(formdata["user_id"]); }
            _userBusiness.Delete(user_id);
            return Ok();
        }
        [Route("create_user")]
        [HttpPost]

        public UserModel CreateUser([FromBody] UserModel model)
        {
            model.user_id = Guid.NewGuid().ToString();
            _userBusiness.Create(model);
            return model;
        }
        [Route("update-user")]
        [HttpPost]
        public UserModel UpdateUser([FromBody] UserModel model)
        {
            _userBusiness.Update(model);
            return model;
        }

        [Route("search")]
        [HttpPost]
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string name = "";
                if (formData.Keys.Contains("name") && !string.IsNullOrEmpty(Convert.ToString(formData["name"]))) { name = Convert.ToString(formData["name"]); }
                string username = "";
                if (formData.Keys.Contains("username") && !string.IsNullOrEmpty(Convert.ToString(formData["username"]))) { username = Convert.ToString(formData["username"]); }
                long total = 0;
                var data = _userBusiness.Search(page, pageSize, out total, name, username);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
    }
}