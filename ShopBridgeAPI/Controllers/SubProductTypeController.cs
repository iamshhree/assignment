using ShopBridgeRepo.Models;
using ShopBridgeRepo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopBridgeAPI.Controllers
{
    public class SubProductTypeController : ApiController
    {
        [HttpGet]
        [Route("subproduct/types")]
        public IHttpActionResult GetAllSubProductTypess()
        {
            try
            {
                SubProductTypeRepo pTypeRepo = new SubProductTypeRepo();
                List<SubProductType> lstPTypes = new List<SubProductType>();
                lstPTypes = pTypeRepo.GetSubProductTypes();
                // return new string[] { "value1", "value2" };
                return Ok(lstPTypes);
            }
            catch
            {
                return BadRequest("Something went wrong");
            }

        }

        [HttpGet]
        [Route("subproduct/types/{id}")]
        public IHttpActionResult GetSubProductTypesByID(int id)
        {
            try
            {
                SubProductTypeRepo pTypeRepo = new SubProductTypeRepo();
                List<SubProductType> lstPTypes = new List<SubProductType>();
                lstPTypes = pTypeRepo.GetSubProductTypes(id);
                // return new string[] { "value1", "value2" };
                return Ok(lstPTypes);
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpPost]
        [Route("subproduct/addsubproducttype")]
        public IHttpActionResult AddsubproductType([FromBody]SubProductType subProductType)
        {
            try
            {
                SubProductTypeRepo pTypeRepo = new SubProductTypeRepo();
                int result = 0;
                result = pTypeRepo.AddSubProductType(subProductType);
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
        [Route("subproduct/updatesubproducttype")]
        public IHttpActionResult UpdateSubProductType([FromBody] SubProductType subproductType)
        {
            try
            {
                SubProductTypeRepo pTypeRepo = new SubProductTypeRepo();
                int result = 0;
                result = pTypeRepo.UpdateSubProductType(subproductType);
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
        [Route("subproduct/deletesubproducttype")]
        public IHttpActionResult DeleteSubProductType([FromBody]int id)
        {
            try
            {
                SubProductTypeRepo pTypeRepo = new SubProductTypeRepo();
                int result = 0;
                result = pTypeRepo.DeleteSubProductType(id);
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
