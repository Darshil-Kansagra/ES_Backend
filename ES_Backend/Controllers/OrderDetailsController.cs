﻿using ES_Backend.Data;
using ES_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
        [HttpGet("GetAllOrderDetails/{id}")]
        public IActionResult GetAllOrderDetails(int id)
        {
            var data = _orderDetailsData.SelectAll(id);
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

        #region PostOrderDetails
        [HttpPost]
        [Route("PostOrderDetails")]
        public IActionResult PostOrder([FromBody] OrderDetailsModel model)
        {
            var data = _orderDetailsData.Insert(model);
            if (data == false)
            {
                return NotFound(new { message = "Not Found" });
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
