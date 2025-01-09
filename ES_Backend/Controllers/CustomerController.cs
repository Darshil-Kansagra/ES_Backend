using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ES_Backend.Data;
using ES_Backend.Models;
namespace ES_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerData _customerData;

        #region configuration
        public CustomerController(IConfiguration configuration)
        {
            _customerData = new CustomerData(configuration);
        }
        #endregion

        #region GetAllCustomer
        [HttpGet]
        public IActionResult GetAllCustomer()
        {
            return Ok();
        }
        #endregion

        #region GetById
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var data = _customerData.SelectById(id);
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

        #region PostCustomer
        [HttpPost]
        [Route("PostCustomer")]
        public IActionResult PostCustomer([FromBody] CustomerModel model)
        {
            var data = _customerData.Insert(model);
            if (data == false)
            {
                return NotFound();
            }
            else
            {
                return Ok(new { message = "Data Inserted Successfully" });
            }
        }
        #endregion

        #region PutCustomer
        [HttpPut("PutCustomer/{id}")]
        public IActionResult PutCustomer([FromBody] CustomerModel model, int id)
        {
            var data = _customerData.Update(model, id);
            if (data == false)
            {
                return NotFound();
            }
            else
            {
                return Ok(new { message = "Data Updated Successfully" });
            }
        }
        #endregion

        #region DeleteCustomer
        [HttpDelete("DeleteCustomer/{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var data = _customerData.Delete(id);
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
    }
}
