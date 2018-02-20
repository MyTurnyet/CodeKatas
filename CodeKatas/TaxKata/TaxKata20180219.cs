using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CodeKatas.TaxKata
{
    /// <summary>
    /// PROBLEM: SALES TAXES
    /// 
    /// Basic sales tax is applicable at a rate of 10% on all goods, except books, food, and medical products that are exempt.
    ///  Import duty is an additional sales tax applicable on all imported goods at a rate of 5%, with no exemptions.
    /// 
    /// When I purchase items I receive a receipt which lists the name of all the items and their price (including tax),
    /// finishing with the total cost of the items, and the total amounts of sales taxes paid. 
    /// 
    /// The rounding rules for sales tax are that for a tax rate of n%, a shelf price of p contains (np/100 rounded up to the nearest 0.05) amount of sales tax.
    /// 
    /// Write an application that prints out the receipt details for these shopping baskets...
    /// 
    /// INPUT:
    /// 
    /// Input 1: 1 book at 12.49 1 music CD at 14.99 1 chocolate bar at 0.85
    /// 
    /// Input 2: 1 imported box of chocolates at 10.00 1 imported bottle of perfume at 47.50
    /// 
    /// Input 3: 1 imported bottle of perfume at 27.99 1 bottle of perfume at 18.99 1 packet of headache pills at 9.75 1 box of imported chocolates at 11.25
    /// 
    /// OUTPUT
    /// 
    /// Output 1: 1 book : 12.49 1 music CD: 16.49 1 chocolate bar: 0.85 Sales Taxes: 1.50 Total: 29.83
    /// 
    /// Output 2: 1 imported box of chocolates: 10.50 1 imported bottle of perfume: 54.65 Sales Taxes: 7.65 Total: 65.15
    /// 
    /// Output 3: 1 imported bottle of perfume: 32.19 1 bottle of perfume: 20.89 1 packet of headache pills: 9.75 1 imported box of chocolates: 11.85 Sales Taxes: 6.70 Total: 74.68
    /// </summary>

    [TestClass]
    public class TaxKata20180219
    {

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnSalesTaxAs10Percent()
        {
            //arrange
            ICartItem item = new TaxableItem(18.99);

            //assert
            item.Tax().Should().Be(1.90);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnCostAsPricePlusSalesTax()
        {
            //arrange
            ICartItem item = new TaxableItem(18.99);

            //assert
            item.Cost().Should().Be(20.89);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnCostAsPricePlusSalesTaxAndImportTax()
        {
            //arrange
            ICartItem item = new ImportedTaxableItem(27.99);

            //assert
            item.Cost().Should().Be(32.19);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnNoTaxForNonTaxableItems()
        {
            //arrange
            ICartItem item = new NonTaxableItem(10.00);
            //assert
            item.Tax().Should().Be(0);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnCostWithoutSalesTax()
        {
            //arrange
            ICartItem item = new NonTaxableItem(10.00);
            //assert
            item.Cost().Should().Be(10);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnCostWithoutSalesTaxButWithImportTax()
        {
            //arrange
            ICartItem item = new ImportedNonTaxableItem(10.00);
            //assert
            item.Cost().Should().Be(10.50);
        }


        private class NonTaxableItem : ICartItem
        {
            private readonly double _price;
            private readonly SalesTax _tax;

            private NonTaxableItem(double price, SalesTax tax)
            {
                _price = price;
                _tax = tax;
            }
            public NonTaxableItem(double price) : this(price, new SalesTax(price)) { }

            public virtual double Tax()
            {
                return 0;
            }

            public double Cost()
            {
                return Math.Round(_price + Tax(), 2);
            }
        }

        private class ImportedNonTaxableItem : NonTaxableItem
        {
            private readonly double _price;

            public ImportedNonTaxableItem(double price) : base(price)
            {
                _price = price;
            }

            public override double Tax()
            {
                return new ImportTax(_price).AssesedAmount();
            }
        }

        private class TaxableItem : ICartItem
        {
            private readonly double _price;
            private readonly SalesTax _tax;

            private TaxableItem(double price, SalesTax tax)
            {
                _price = price;
                _tax = tax;
            }

            public TaxableItem(double price) : this(price, new SalesTax(price)) { }

            public virtual double Tax()
            {
                return _tax.AssesedAmount();
            }

            public double Cost()
            {
                return Math.Round(_price + Tax(), 2);
            }
        }

        private class ImportedTaxableItem : TaxableItem
        {
            private readonly double _price;


            public ImportedTaxableItem(double price) : base(price)
            {
                _price = price;
            }

            public override double Tax()
            {
                return base.Tax() + new ImportTax(_price).AssesedAmount();
            }
        }

        private interface ICartItem
        {
            double Tax();
            double Cost();
        }

        private class SalesTax
        {
            private readonly double _price;
            
            public SalesTax(double price)
            {
                _price = price;
            }

            public virtual double AssesedAmount()
            {
                return Math.Round(Math.Round(_price * .1 / (double)0.05m, 0) * (double)0.05m, 2);
            }
        }

        private class ImportTax : SalesTax
        {
            private readonly double _price;

            public ImportTax(double price) : base(price)
            {
                _price = price;
            }

            public override double AssesedAmount()
            {
                return Math.Round(Math.Round(_price * .05 / (double)0.05m, 0) * (double)0.05m, 2);
            }
        }

        private class ShoppingBasket
        {
            public ShoppingBasket()
            {
            }

            public void AddItem(ICartItem item)
            {

            }
        }
    }
}
