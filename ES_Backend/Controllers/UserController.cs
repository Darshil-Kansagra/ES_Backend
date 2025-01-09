using ES_Backend.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ES_Backend.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;

namespace ES_Backend.Controllers
{
    [Route("ES/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserData _userData;

        #region configuration
        public UserController(IConfiguration configuration)
        {
            _userData = new UserData(configuration);
        }
        #endregion

        #region GetAllUser

        [HttpGet]
        [Route("GetAllUser")]
        public IActionResult GetAllUser()
        {
            var data = _userData.SelectAll();
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }
        #endregion

        #region PostUser

        [HttpPost]
        [Route("PostUser")]
        public IActionResult PostUser([FromBody] UserModel user)
        {
            var data = _userData.Insert(user);
            if(data == false)
            {
                return NotFound();
            }
            else
            {
                return Ok(new { message = "Data Inserted Successfully" });
            }
        }
        #endregion

        #region PutUser

        [HttpPut("UpdateUser/{id}")]
        public IActionResult PutUser([FromBody]UserModel user,int id)
        {
            var data = _userData.Update(user,id);
            if(data == false)
            {
                return NotFound();
            }
            else
            {
                return Ok(new { message = "Data Updated Successfully" });
            }
        }
        #endregion

        #region SoftDelete

        [HttpPatch("SoftDelete/{id}")]
        public IActionResult SoftDelete(int id)
        {
            var data = _userData.SoftDelete(id);
            if(data == false)
            {
                return NotFound();
            }
            else
            {
                return Ok(new { message = "Data Deleted Successfully" });
            }
        }
        #endregion

        #region Login
        [HttpPost]
        [Route("Login")]
        public IActionResult login([FromBody] UserModel user)
        {
            var data = _userData.login(user);
            if (data.UserId == null)
            {
                return Ok(new { message = "UserName or Password is incorrect" });
            }
            else
            {
                return Ok(data);
            }
        }
        #endregion
    }
}
