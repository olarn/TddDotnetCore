using System;
using TaxLib;
using TaxRepo;

namespace TaxLib
{
    public class VatManager
    {
        private IRepository repo;
        private VatCalculator vatCalculator;
        public VatManager(IRepository repo, VatCalculator vatCalculator)
        {
            this.repo = repo;
            this.vatCalculator = vatCalculator;
        }

        public decimal calculateVat(decimal amount)
        {
            var vatRate = repo.getVatRate();
            return vatCalculator.calculateVat(amount, vatRate);
        }

        public decimal excludeVat(decimal from)
        {
            var vatRate = repo.getVatRate();
            return vatCalculator.excludeVat(from, vatRate);
        }
    }
}