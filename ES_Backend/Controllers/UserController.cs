using ES_Backend.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ES_Backend.Models;

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

        #region GetAll
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
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

        #region Insert
        [HttpPost]
        public IActionResult Insert([FromBody] UserModel user)
        {
            var data = _userData.Insert(user);
            if(data == false)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }
        #endregion
    }
}
