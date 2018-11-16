using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TaxRouter.Controllers
{
    [Route("api/vat/exclude")]
    [ApiController]
    public class VatExcludeControllers : ControllerBase
    {
        [HttpGet]
        public ActionResult<decimal> Get()
        {
            return 7;
        }

        [HttpGet("{amount}")]
        public ActionResult<string> Get(decimal amount)
        {
            return (amount / (decimal)1.07).ToString("#.00");
        }
    }
}