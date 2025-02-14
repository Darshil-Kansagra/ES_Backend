using ES_Backend.Data;
using ES_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ES_Backend.Controllers
{
    [Route("ES/[controller]")]
    [ApiController]
    public class SpecificationController : ControllerBase
    {
        private SpecificationData _specificationData;

        #region configuration
        public SpecificationController(IConfiguration configuration)
        {
            _specificationData = new SpecificationData(configuration);
        }
        #endregion

        #region GetAllTV
        [HttpGet("GetAllTV/{id}")]
        public IActionResult GetAllTV(int id)
        {
            var data = _specificationData.GetAllTVSpec(id);
            if (data.SpecificationId == null)
            {
                return NotFound(new { message = "Not Found" });
            }
            else
            {
                return Ok(data);
            }
        }
        #endregion

        #region GetAllAC
        [HttpGet("GetAllAC/{id}")]
        public IActionResult GetAllAC(int id)
        {
            var data = _specificationData.GetAllACSpec(id);
            if (data.SpecificationId == null)
            {
                return NotFound(new { message = "Not Found" });
            }
            else
            {
                return Ok(data);
            }
        }
        #endregion

        #region PostTV
        [HttpPost]
        [Route("PostTV")]
        public IActionResult PostTV([FromBody] SpecificationModel model)
        {
            var data = _specificationData.InsertTV(model);
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

        #region PostAC
        [HttpPost]
        [Route("PostAC")]
        public IActionResult PostAC([FromBody] SpecificationModel model)
        {
            var data = _specificationData.InsertAC(model);
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
    }
}
