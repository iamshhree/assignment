using ShopBridgeRepo.Models;
using ShopBridgeRepo.Repository;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ShopBridgeAPI.Controllers
{
    public class productdetailsDetailsController : ApiController
    {
        [HttpPost]
        [Route("productdetails/types")]
        public IHttpActionResult GetAllProductDetails([FromBody]Pagination<ProductDetails> pagination)
        {
            try
            {
                ProductDetailsRepo pTypeRepo = new ProductDetailsRepo();
                List<ProductDetails> lstPTypes = new List<ProductDetails>();
                if (pagination.SearchedRecord == "" || pagination.SearchedRecord == null)
                    lstPTypes = pTypeRepo.GetProductDetails(pagination);
                else
                    lstPTypes = pTypeRepo.GetProductDetails(pagination);
                pagination.TotalRecordCount = pTypeRepo.GetProductDetailsCount(pagination);
                pagination.ResponseResult = lstPTypes;
                return Ok(pagination);
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }

        }

        

        [HttpPost]
        [Route("productdetails/addproductdetails")]
        public IHttpActionResult AddProductDetails([FromBody]ProductDetails productDetails)
        {
            try
            {
                ProductDetailsRepo pTypeRepo = new ProductDetailsRepo();
                int result = 0;
                result = pTypeRepo.AddProductDetails(productDetails);
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
        [Route("productdetails/updateproductdetails")]
        public IHttpActionResult UpdateProductDetails([FromBody] ProductDetails productDetails)
        {
            try
            {
                ProductDetailsRepo pTypeRepo = new ProductDetailsRepo();
                int result = 0;
                result = pTypeRepo.UpdateProductDetails(productDetails);
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
        [Route("productdetails/deleteproductdetails")]
        public IHttpActionResult DeleteProductDetails([FromBody]int id)
        {
            try
            {
                ProductDetailsRepo pTypeRepo = new ProductDetailsRepo();
                int result = 0;
                result = pTypeRepo.DeleteProductDetails(id);
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
