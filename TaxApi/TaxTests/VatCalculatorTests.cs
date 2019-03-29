using System;
using Xunit;
using TaxLib;

namespace TaxTests
{
    public class VatCalculatorTests
    {
        // Arrange
        [Theory]
        [InlineData(100, 7, 107)]
        [InlineData(100, 10, 110)]
        public void Test_CalculateVat_WithVatRate(decimal amount, decimal vatRate, decimal expectedTotalAmount)
        {
            // Act
            var vatCalculator = new VatCalculator();
            decimal actualTotalAmount = vatCalculator.calculateVat(amount, vatRate);

            // Assert
            Assert.Equal(expectedTotalAmount, actualTotalAmount);
        }

        [Theory]
        [InlineData(107, 7, 100)]
        [InlineData(110, 10, 100)]
        [InlineData(100, 7, 93.46)]
        public void Test_CalculateExcludeVat(decimal totalAmount, decimal vatRate, decimal expectedAmount)
        {
            // Act
            var vatCalculator = new VatCalculator();
            decimal actualAmount = vatCalculator.excludeVat(totalAmount, vatRate);

            // Assert
            Assert.True(expectedAmount == actualAmount, $"expected {expectedAmount}, actual {actualAmount}");
        }

        [Fact(Skip = "This is an integration test.")]
        public void Test_Something()
        {
            Console.WriteLine("Skipped ============");
            Assert.True(false, "Not implemented.");
        }
    }
}
