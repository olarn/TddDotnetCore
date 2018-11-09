﻿using System;

namespace TaxLib
{
    public class VatCalculator
    {
        public decimal calculateVat(decimal amount, decimal vatRate)
        {
            return amount + (amount * vatRate / 100);
        }

        public decimal excludeVat(decimal totalAmount, decimal vatRate)
        {
            return totalAmount / (1 + (vatRate / 100));
        }
    }
}
