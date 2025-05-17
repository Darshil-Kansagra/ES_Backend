using ES_Backend.Data;
using ES_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ES_Backend.Controllers
{
    [Route("ES/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderData _orderData;

        #region configuration
        public OrderController(IConfiguration configuration)
        {
            _orderData = new OrderData(configuration);
        }
        #endregion

        #region GetAllOrder
        [HttpGet()]
        [Route("GetAllOrder")]
        public IActionResult GetAllOrder()
        {
            var data = _orderData.SelectAll();
            if (!data.Any())
            {
                return NotFound(new { message = "Not Found" });
            }
            else
            {
                return Ok(data);
            }
        }
        #endregion

        #region GetOrderByUserId
        [HttpGet("GetByUserId/{id}")]
        public IActionResult GetOrderByUserId(int id)
        {
            var data = _orderData.SelectByUserId(id);
            if (!data.Any())
            {
                return NotFound(new { message = "Not Found" });
            }
            else
            {
                return Ok(data);
            }
        }
        #endregion

        #region PostOrder
        [HttpPost]
        [Route("PostOrder")]
        public IActionResult PostOrder([FromBody] OrderModel model)
        {
            var data = _orderData.Insert(model);
            if(data == false)
            {
                return NotFound(new { message = "Not Found" });
            }
            else
            {
                return Ok(new { message = "Data Inserted Successfully" });
            }
        }
        #endregion

        #region DeleteOrder
        [HttpDelete("DeleteOrder/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var data = _orderData.Delete(id);
            if(data == false)
            {
                return NotFound(new { message = "Not Found" });
            }
            else
            {
                return Ok(new { message = "Data Deleted Successfully" });
            }
        }
        #endregion
    }
}
