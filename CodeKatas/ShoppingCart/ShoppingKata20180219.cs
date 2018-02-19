using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas.ShoppingCart
{
    /// <summary>
    /// Checkout Kata
    /// Implement the code for a supermarket checkout that calculates the total price of a number of items.
    /// Goods are priced individually, however there are weekly special offers for when multiple items are bought.
    /// For example “Apples are 50 each or 3 for 130”.
    ///
    /// Weekly offers change frequently.
    ///
    /// SKUUnit PriceSpecial Offer
    ///
    /// A99 50	3 for 130
    /// B15 30	2 for 45
    /// C40 60	
    /// T34 99
    /// </summary>
    [TestClass]
    public class ShoppingKata20180219
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnPriceForApples()
        {
            //arrange
            CashRegister cashRegister = new CashRegister();
            cashRegister.Scan("A99");

            //act
            decimal totalCost = cashRegister.TotalCost();

            //assert
            totalCost.Should().Be((decimal) 0.50);
        }
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnPriceForBananas()
        {
            //arrange
            CashRegister cashRegister = new CashRegister();
            cashRegister.Scan("B15");

            //act
            decimal totalCost = cashRegister.TotalCost();

            //assert
            totalCost.Should().Be((decimal) 0.30);
        }
    }

    public class CashRegister   
    {
        private string _currentItem;

        public void Scan(string skuCode)
        {
            _currentItem = skuCode;
        }

        public decimal TotalCost()
        {
            if (_currentItem == "B15") return 0.30m;
            return 0.50m;
        }
    }
}