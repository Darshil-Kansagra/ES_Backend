using ES_Backend.Data;
using ES_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ES_Backend.Controllers
{
    [Route("ES/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly BillData _billData;

        #region configuration
        public BillController(IConfiguration configuration)
        {
            _billData = new BillData(configuration);
        }
        #endregion

        #region GetAllBill
        [HttpGet]
        [Route("GetAllBill")]
        public IActionResult GetAllBill()
        {
            var data = _billData.SelectAll();
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

        #region PostBill
        [HttpPost]
        [Route("PostBill")]
        public IActionResult PostBill([FromBody] BillModel model)
        {
            var data = _billData.Insert(model);
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

        #region DeleteBill
        [HttpDelete("DeleteBill/{id}")]
        public IActionResult DeleteBill(int id)
        {
            var data = _billData.Delete(id);
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
