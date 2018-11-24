using System;
using Microsoft.EntityFrameworkCore;

namespace TaxRepo
{
    public class Vat
    {
        public int VatId { get; set; }
        public DateTime EffectDate { get; set; }
    }
}