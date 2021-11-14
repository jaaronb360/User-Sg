using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AaronBriones.User.Interfaces;

namespace AaronBriones.User.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ArrayCalcController : ControllerBase
    {
        ///https://localhost:44364/api/arraycalc/reverse?productIds=1&productIds=5&productIds=12&productIds=3

        private readonly ILogger<ArrayCalcController> _logger;
        private readonly IProductService _productService;


        public ArrayCalcController(ILogger<ArrayCalcController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

      
        [HttpGet("reverse")]
        public ActionResult reverse([FromQuery(Name = "productIds")] int[] productIds)
        {
         
            try
            {
                if (productIds.Length == 0)
                    throw new Exception("No Items");


                return Content(JsonConvert.SerializeObject(_productService.Reverse(productIds)));
            } catch(Exception e)
            {
                return Content(e.Message);
            }


        }
        //https://localhost:44364/api/arraycalc/deletepart?position=2&productIds=1&productIds=5&productIds=12&productIds=3
        [HttpGet("deletepart")]
        public IActionResult deletepart([FromQuery(Name = "position")] int? position, [FromQuery(Name = "productIds")] int[] productIds)
        {
            try
            {
                if (productIds.Length == 0)
                    throw new Exception("No Items");

                if (position == null)
                    throw new Exception("Position required");

                if (position < 1)
                    throw new Exception("Position value should start with 1");

                if (position > productIds.Length)
                    throw new Exception("Position value should be within provided array.");

                return Content(JsonConvert.SerializeObject(_productService.Remove(position.Value, productIds)));
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }



    }
}
