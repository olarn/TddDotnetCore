using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TaxRouter.Controllers
{
    [Route("api/vat/include")]
    [ApiController]
    public class VatControllers : ControllerBase
    {
        [HttpGet]
        public ActionResult<double> Get()
        {
            return 7;
        }

        [HttpGet("{amount}")]
        public ActionResult<string> Get(double amount)
        {
            return (amount * 1.07).ToString("#.##");
        }
    }
}