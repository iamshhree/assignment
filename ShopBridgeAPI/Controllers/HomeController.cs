using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ShopBridgeAPI.Controllers
{
    public class HomeController : ApiController
    {
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("Home")]
        public IHttpActionResult Index()
        {
            try
            {
                return Ok("Record Added Successfully");
            }
            catch
            {
                return BadRequest("Record Added Successfully");
            }
           
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult Hello()
        {
           

            return Ok();


        }
    }


}
