using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaxRepo;

namespace TaxRouter.Controllers
{
    [Route("api/vat/include")]
    [ApiController]
    public class VatControllers : ControllerBase
    {
        private readonly TaxContext taxContaxt;

        public VatControllers(TaxContext dbContext) 
        {
            taxContaxt = dbContext;
            if (taxContaxt.Vats.Count() == 0) 
            {
                taxContaxt.Vats.Add(new Vat { 
                    VatId = 7, 
                    EffectDate = DateTime.Now
                });
                taxContaxt.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<decimal> Get()
        {
            var repo = new Repository(taxContaxt);
            return repo.getVatRate();
        }

        [HttpGet("{amount}")]
        public ActionResult<string> Get(double amount)
        {
            return (amount * 1.07).ToString("#.##");
        }
    }
}