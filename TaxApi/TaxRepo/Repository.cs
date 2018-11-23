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
            throw new System.NotImplementedException();
        }
    }
}