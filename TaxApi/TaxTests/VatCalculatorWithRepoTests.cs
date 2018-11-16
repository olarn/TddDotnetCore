using System;
using Xunit;
using Moq;
using TaxLib;
using TaxRepo;

namespace TaxTests
{
    public class VatCalculatorWithRepoTests
    {

        [Theory]
        [InlineData(100, 7, 107)]
        [InlineData(100, 10, 110)]
        public void Test_TexController_CalculateVat_with_repo(decimal amount, decimal vatRate, decimal expectedTotalAmount)
        {
            // Arrange
            var vatCalculator = new VatCalculator();
            var mock = new Mock<IRepository>();
            mock.Setup(r => r.getVatRate()).Returns(vatRate);
            var repo = mock.Object;
            var vatManager = new VatManager(repo, vatCalculator);

            // Act
            var actualTotalAmount = vatManager.calculateVat(amount);

            // Assert
            Assert.Equal(expectedTotalAmount, actualTotalAmount);
            mock.Verify(r => r.getVatRate(), Times.Once);
        }

        [Theory]
        [InlineData(107, 7, 100)]
        [InlineData(110, 10, 100)]
        public void Test_TaxController_excludeVat_WithRepo(decimal totalAmount, decimal vatRate, decimal expectedAmount)
        {
            // Arrange
            var vatCalculator = new VatCalculator();
            var mock = new Mock<IRepository>();

            mock.Setup(r => r.getVatRate()).Returns(vatRate);

            var repo = mock.Object;
            var vatManager = new VatManager(repo, vatCalculator);

            // Act
            var actualAmount = vatManager.excludeVat(from: totalAmount);

            // Assert
            Assert.True(expectedAmount == actualAmount, $"expected {expectedAmount}, actual {actualAmount}");
        }
    }
}