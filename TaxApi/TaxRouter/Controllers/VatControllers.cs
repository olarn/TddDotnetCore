using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaxRepo;
using TaxLib;

namespace TaxRouter.Controllers
{
    [Route("api/vat/include")]
    [ApiController]
    public class VatControllers : ControllerBase
    {
        private readonly TaxContext db;
        private Repository taxRepo;

        public VatControllers(TaxContext dbContext) 
        {
            db = dbContext;
            if (db.Vats.Count() == 0) 
            {
                db.Vats.Add(new Vat { 
                    VatId = 7, 
                    EffectDate = DateTime.Now
                });
                db.SaveChanges();
            }
            taxRepo = new Repository(db);
        }

        [HttpGet]
        public ActionResult<decimal> Get()
        {
            return taxRepo.getVatRate();
        }

        [HttpGet("{amount}")]
        public ActionResult<string> Get(decimal amount)
        {
            var vatCalculator = new VatCalculator();
            var vatRate = taxRepo.getVatRate();
            return vatCalculator.calculateVat(amount, vatRate).ToString();
        }
    }
}