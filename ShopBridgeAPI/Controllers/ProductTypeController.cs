using ShopBridgeRepo.Models;
using ShopBridgeRepo.Repository;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ShopBridgeAPI.Controllers
{
    public class ProductTypeController : ApiController
    {
        [HttpGet]
        [Route("product/types")]
        public IHttpActionResult GetAllProductTypess()
        {
            try
            {
                ProductTypeRepo pTypeRepo = new ProductTypeRepo();
                List<ProductType> lstPTypes = new List<ProductType>();
                lstPTypes = pTypeRepo.GetProductTypes();
                // return new string[] { "value1", "value2" };
                return Ok(lstPTypes);
            }
            catch
            {
                return BadRequest("Something went wrong");
            }

        }

        [HttpGet]
        [Route("product/types/{id}")]
        public IHttpActionResult GetProductTypesByID(int id)
        {
            try
            {
                ProductTypeRepo pTypeRepo = new ProductTypeRepo();
                List<ProductType> lstPTypes = new List<ProductType>();
                lstPTypes = pTypeRepo.GetProductTypes(id);
                // return new string[] { "value1", "value2" };
                return Ok(lstPTypes);
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpPost]
        [Route("product/addproducttype")]
        public IHttpActionResult AddProductType([FromBody]string productTypeName)
        {
            try
            {
                ProductTypeRepo pTypeRepo = new ProductTypeRepo();
                int result = 0;
                result = pTypeRepo.AddProductType(productTypeName);
                if (result == 1)
                    return Ok("Record Added Succesfully");
                else
                    return Ok("Something Went Wrong..!!");
            }
            catch
            {
                return BadRequest("Something went wrong");
            }

        }

        [HttpPost]
        [Route("product/updateproducttype")]
        public IHttpActionResult UpdateProductType([FromBody] ProductType productType)
        {
            try
            {
                ProductTypeRepo pTypeRepo = new ProductTypeRepo();
                int result = 0;
                result = pTypeRepo.UpdateProductType(productType);
                if (result == 1)
                    return Ok("Record Updated Succesfully");
                else
                    return Ok("Something Went Wrong..!!");
            }
            catch
            {
                return BadRequest("Something went wrong , Record Not Updated");
            }
        }

        [HttpPost]
        [Route("product/deleteproducttype")]
        public IHttpActionResult DeleteProductType([FromBody]int id)
        {
            try
            {
                ProductTypeRepo pTypeRepo = new ProductTypeRepo();
                int result = 0;
                result = pTypeRepo.DeleteProductType(id);
                if (result == 1)
                    return Ok("Record Deleted Succesfully");
                else
                    return Ok("Something Went Wrong..!!");
            }
            catch
            {
                return BadRequest("Something went wrong , Record Not Updated");
            }
        }
    }
}
