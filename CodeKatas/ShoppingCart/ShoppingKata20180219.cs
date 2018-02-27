using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

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
            totalCost.Should().Be((decimal)0.50);
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
            totalCost.Should().Be((decimal)0.30);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnPriceForCantolope()
        {
            //arrange
            CashRegister cashRegister = new CashRegister();
            cashRegister.Scan("C40");

            //act
            decimal totalCost = cashRegister.TotalCost();

            //assert
            totalCost.Should().Be((decimal)0.60);
        }


        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnPriceForTomatoes()
        {
            //arrange
            CashRegister cashRegister = new CashRegister();
            cashRegister.Scan("T34");

            //act
            decimal totalCost = cashRegister.TotalCost();

            //assert
            totalCost.Should().Be((decimal)0.99);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldMultipleItemsShouldTotal()
        {
            //arrange
            CashRegister cashRegister = new CashRegister();
            cashRegister.Scan("T34");
            cashRegister.Scan("C40");

            //act
            decimal totalCost = cashRegister.TotalCost();

            //assert
            totalCost.Should().Be((decimal)1.59);
        }
        

        private class StoreItem
        {
            private readonly string _code;
            private readonly decimal _cost;

            public StoreItem(string code, decimal cost)
            {
                _code = code;
                _cost = cost;
            }

            public override bool Equals(object obj)
            {
                return Equals(obj as StoreItem);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return ((_code != null ? _code.GetHashCode() : 0) * 397) ^ _cost.GetHashCode();
                }
            }

            private bool Equals(StoreItem other)
            {
                return other != null && other._code == _code;
            }

            public decimal Cost()
            {
                return _cost;
            }
        }

        private class Tomato : StoreItem
        {
            public Tomato() : base("T34", 0.99m){}
        } 
        private class Bananas : StoreItem
        {
            public Bananas() : base("B15", 0.30m){}
        }
        private class Cantolope : StoreItem
        {
            public Cantolope() : base("C40", 0.60m){}
        }
        private class Apple : StoreItem
        {
            public Apple() : base("A99", 0.50m){}
        }

        private class CashRegister
        {
            private readonly List<StoreItem> _storeItems;

            public CashRegister() : this(new List<StoreItem>()) { }

            private CashRegister(List<StoreItem> storeItems)
            {
                _storeItems = storeItems;
            }

            public void Scan(string skuCode)
            {
                if (skuCode == "T34") _storeItems.Add(new Tomato());
                if (skuCode == "B15") _storeItems.Add(new Bananas());
                if (skuCode == "C40") _storeItems.Add(new Cantolope());
                if (skuCode == "A99") _storeItems.Add(new Apple());
            }

            public decimal TotalCost()
            {
                return _storeItems.Sum(item => item.Cost());
            }
        }
    }
}