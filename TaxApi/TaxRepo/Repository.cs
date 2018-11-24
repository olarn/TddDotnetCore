using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TaxRepo
{

    public class Repository : IRepository
    {
        private TaxContext db;
        public Repository(TaxContext db)
        {
            this.db = db;
        }

        public decimal getVatRate()
        {
            var vat = (from v in db.Vats
                       orderby v.EffectDate ascending
                       select v).ToList().FirstOrDefault();
            return vat.VatId;
        }
    }
}