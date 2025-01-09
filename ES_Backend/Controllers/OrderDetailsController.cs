using ES_Backend.Data;
using ES_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ES_Backend.Controllers
{
    [Route("ES/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly OrderDetailsData _orderDetailsData;
        #region configuration
        public OrderDetailsController(IConfiguration configuration)
        {
            _orderDetailsData = new OrderDetailsData(configuration);
        }
        #endregion

        #region GetAllOrderDetails
        [HttpGet]
        public IActionResult GetAllOrderDetails()
        {
            var data = _orderDetailsData.SelectAll();
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

        #region PostOrderDetails
        [HttpPost]
        [Route("PostOrderDetails")]
        public IActionResult PostOrder([FromBody] OrderDetailsModel model)
        {
            var data = _orderDetailsData.Insert(model);
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

        #region DeleteOrderDetails
        [HttpDelete("DeleteOrderDetails/{id}")]
        public IActionResult DeleteOrderDetails(int id)
        {
            var data = _orderDetailsData.Delete(id);
            if (data == false)
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
