using ES_Backend.Data;
using ES_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ES_Backend.Controllers
{
    [Route("ES/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductData _productdata;

        #region configuration
        public ProductController(IConfiguration configuration)
        {
            _productdata = new ProductData(configuration);
        }
        #endregion

        #region GetAllProduct
        [HttpGet]
        [Route("GetAllProduct")]
        public IActionResult GetAllProduct()
        {
            var data = _productdata.SelectAll();
            if (data.IsNullOrEmpty())
            {
                return NotFound(new { message = "Not Found" });
            }
            else
            {
                return Ok(data);
            }
        }
        #endregion

        #region GetById
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var data = _productdata.SelectById(id);
            if (data.ProductId == null)
            {
                return NotFound(new { message = "Not Found" });
            }
            else
            {
                return Ok(data);
            }
        }
        #endregion

        #region PostProduct
        [HttpPost]
        [Route("PostProduct")]
        public IActionResult PostProduct([FromBody] ProductModel model)
        {
            var data = _productdata.Insert(model);
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

        #region PutProduct
        [HttpPut("PutProduct/{id}")]
        public IActionResult PutProduct([FromBody] ProductModel model, int id)
        {
            var data = _productdata.Update(model, id);
            if (data == false)
            {
                return NotFound(new { message = "Not Found" });
            }
            else
            {
                return Ok(new { message = "Data Updated Successfully" });
            }
        }
        #endregion

        #region DeleteProduct
        [HttpDelete("DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var data = _productdata.Delete(id);
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

        #region SearchProduct
        [HttpPost]
        [Route("SearchProduct")]
        public IActionResult Search([FromBody] SearchModel model)
        {
            var data = _productdata.SearchProduct(model);
            if (data.IsNullOrEmpty())
            {
                return NotFound(new { message = "Not Found" });
            }
            else
            {
                return Ok(data);
            }
        }
        #endregion
    }
}
