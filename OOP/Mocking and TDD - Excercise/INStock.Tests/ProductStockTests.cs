namespace INStock.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    public class ProductStockTests
    {
        private ProductStock productStock;
        [SetUp]
        public void Initialize()
        {
            this.productStock = new ProductStock();
        }
        [Test]
        [TestCase("maratonki", 100, 5, 1)]
        public void AddMethodShouldAddANewProductInTheStock(string label, decimal price, int quantity, int expectedResult)
        {
            //Arrange
            Product product = new Product(label, price, quantity);

            //Act
            this.productStock.Add(product);
            //Assert
            Assert.AreEqual(expectedResult, this.productStock.Count);
        }

        [Test]
        [TestCase("maratonki", 100, 5)]
        public void AddMethodShouldThrowExceptionWhenGivenProductHasTheSameLabelLikeAProductInTheStockRepository(string label, decimal price, int quantity)
        {
            //Arrange
            Product product = new Product(label, price, quantity);
            //Act
            this.productStock.Add(product);
            //Assert
            Assert.Throws<InvalidOperationException>(() => this.productStock.Add(product));
        }

        [Test]
        [TestCase("maratonki", "slushalki")]
        public void ContainsMethodShouldReturnTrueOrFalseIfGivenProductIsOtItIsNotInStock(string label1, string label2)
        {
            //Arrange
            Product firstPproduct = new Product(label1, 100, 10);
            Product secondProduct = new Product(label2, 100, 10);
            //Act
            this.productStock.Add(firstPproduct);
            bool actualResult = this.productStock.Contains(firstPproduct);
            //Assert
            Assert.AreEqual(true, this.productStock.Contains(firstPproduct));
            Assert.AreEqual(false, this.productStock.Contains(secondProduct));
        }

        [Test]
        public void CountPropertyShouldReturnTheNumberOfProductsCurrentlyInStock()
        {
            //Assert
            Assert.That(this.productStock.Count, Is.EqualTo(0));

            //Act
            this.productStock.Add(new Product("label", 100, 50));

            //Assert
            Assert.That(this.productStock.Count, Is.EqualTo(1));
        }

        [Test]
        [TestCase("maratonki", "slushalki", "mishka", "torpedo", 2, "mishka")]
        public void FindMethodShouldReturnTheProductAtTheGivenPositionIfItIsLowerThanProductsCount(
            string label1,
            string label2,
            string label3,
            string label4,
            int indexToFind,
            string expectedProductLabel)
        {
            //Arrange
            Product firstPproduct = new Product(label1, 100, 10);
            Product secondProduct = new Product(label2, 60, 5);
            Product thirdPproduct = new Product(label3, 150, 2);
            Product forthProduct = new Product(label4, 200, 1);
            //Act
            this.productStock.Add(firstPproduct);
            this.productStock.Add(secondProduct);
            this.productStock.Add(thirdPproduct);
            this.productStock.Add(forthProduct);
            Product wantedProduct = this.productStock.Find(indexToFind);
            //Assert
            Assert.AreEqual(wantedProduct.Label, expectedProductLabel);
        }

        [Test]
        [TestCase("maratonki", "slushalki", "mishka", "torpedo", 5)]
        public void FindMethodShouldThrowAnExceptionIfGivenIndexIsOutOfRange(
            string label1,
            string label2,
            string label3,
            string label4,
            int indexToFind
            )
        {
            //Arrange
            Product firstPproduct = new Product(label1, 100, 10);
            Product secondProduct = new Product(label2, 60, 5);
            Product thirdPproduct = new Product(label3, 150, 2);
            Product forthProduct = new Product(label4, 200, 1);
            //Act
            this.productStock.Add(firstPproduct);
            this.productStock.Add(secondProduct);
            this.productStock.Add(thirdPproduct);
            this.productStock.Add(forthProduct);

            //Assert
            Assert.Throws<IndexOutOfRangeException>(() => this.productStock.Find(indexToFind));
        }

        [Test]
        [TestCase("maratonki", "slushalki", "mishka", "torpedo", "mishka")]
        public void FindByLabelMethodShouldReturnTheProductWithTheGivenLabelIfItIsInStock(
            string label1,
            string label2,
            string label3,
            string label4,
            string labelToFind)
        {
            //Arrange
            Product firstPproduct = new Product(label1, 100, 10);
            Product secondProduct = new Product(label2, 60, 5);
            Product thirdPproduct = new Product(label3, 150, 2);
            Product forthProduct = new Product(label4, 200, 1);
            //Act
            this.productStock.Add(firstPproduct);
            this.productStock.Add(secondProduct);
            this.productStock.Add(thirdPproduct);
            this.productStock.Add(forthProduct);
            Product wantedProduct = this.productStock.FindByLabel(labelToFind);
            //Assert
            Assert.AreEqual(wantedProduct.Label, labelToFind);
        }

        [Test]
        [TestCase("maratonki", "slushalki", "mishka", "torpedo", "ranica")]
        public void FindByLabelMethodShouldThrowAnExceptionIfThereIsNotAProductWithTheGivenLabel(
            string label1,
            string label2,
            string label3,
            string label4,
            string labelToFind)
        {
            //Arrange
            Product firstPproduct = new Product(label1, 100, 10);
            Product secondProduct = new Product(label2, 60, 5);
            Product thirdPproduct = new Product(label3, 150, 2);
            Product forthProduct = new Product(label4, 200, 1);
            //Act
            this.productStock.Add(firstPproduct);
            this.productStock.Add(secondProduct);
            this.productStock.Add(thirdPproduct);
            this.productStock.Add(forthProduct);
            //Assert
            Assert.Throws<ArgumentException>(() => this.productStock.FindByLabel(labelToFind));
        }

        [Test]
        [TestCase("maratonki", "slushalki", "mishka", "torpedo", 70, 160)]
        public void FindAllInPriceRangeMethodShouldReturnAllTheProductsThatHaveAPriceInTheGivenRange(
            string label1,
            string label2,
            string label3,
            string label4,
            decimal rangeStart,
            decimal rangeEnd)
        {
            //Arrange
            Product firstPproduct = new Product(label1, 100, 10);
            Product secondProduct = new Product(label2, 60, 5);
            Product thirdPproduct = new Product(label3, 150, 2);
            Product forthProduct = new Product(label4, 200, 1);
            //Act
            this.productStock.Add(firstPproduct);
            this.productStock.Add(secondProduct);
            this.productStock.Add(thirdPproduct);
            this.productStock.Add(forthProduct);
            Product[] productsReturned = this.productStock.FindAllInPriceRange(rangeStart, rangeEnd).ToArray();

            //Assert
            foreach (var product in productsReturned)
            {
                Assert.That(product.Price >= rangeStart && product.Price <= rangeEnd);
            }
        }

        [Test]
        [TestCase("maratonki", "slushalki", "mishka", "torpedo", 70, 160)]
        public void FindAllInPriceRangeMethodShouldReturnAllTheProductsThatHaveAPriceInTheGivenRangeDescending(
            string label1,
            string label2,
            string label3,
            string label4,
            decimal rangeStart,
            decimal rangeEnd)
        {
            //Arrange
            Product firstPproduct = new Product(label1, 100, 10);
            Product secondProduct = new Product(label2, 60, 5);
            Product thirdPproduct = new Product(label3, 150, 2);
            Product forthProduct = new Product(label4, 200, 1);
            //Act
            this.productStock.Add(firstPproduct);
            this.productStock.Add(secondProduct);
            this.productStock.Add(thirdPproduct);
            this.productStock.Add(forthProduct);
            Product[] productsReturned = this.productStock.FindAllInPriceRange(rangeStart, rangeEnd).ToArray();
            Product[] sortedProducts = productsReturned.OrderByDescending(x => x.Price).ToArray();

            //Assert
            for (int i = 0; i < productsReturned.Length; i++)
            {
                Assert.That(productsReturned[i].Label, Is.EqualTo(sortedProducts[i].Label));
            }
        }

        [Test]
        [TestCase("maratonki", "slushalki", "mishka", "torpedo", 300, 500)]
        public void FindAllInPriceRangeMethodShouldReturnEmptyEnumerationIfThereIsNotAnyProductWithPriceInTheGivenRange(
            string label1,
            string label2,
            string label3,
            string label4,
            decimal rangeStart,
            decimal rangeEnd)
        {
            //Arrange
            Product firstPproduct = new Product(label1, 100, 10);
            Product secondProduct = new Product(label2, 60, 5);
            Product thirdPproduct = new Product(label3, 150, 2);
            Product forthProduct = new Product(label4, 200, 1);
            //Act
            this.productStock.Add(firstPproduct);
            this.productStock.Add(secondProduct);
            this.productStock.Add(thirdPproduct);
            this.productStock.Add(forthProduct);
            Product[] productsReturned = this.productStock.FindAllInPriceRange(rangeStart, rangeEnd).ToArray();

            //Assert
            Assert.That(productsReturned.Length, Is.EqualTo(0));
        }

        [Test]
        [TestCase("maratonki", 100, "slushalki", 60, "mishka", 60, "torpedo", 200, 60)]
        public void FindAllByPriceMethodShouldReturnAllTheProductsInStockWithTheSamePriceAsTheGivenOne(
            string label1, decimal price1,
            string label2, decimal price2,
            string label3, decimal price3,
            string label4, decimal price4,
            decimal givenPrice)
        {
            //Arrange
            Product firstPproduct = new Product(label1, price1, 10);
            Product secondProduct = new Product(label2, price2, 5);
            Product thirdPproduct = new Product(label3, price3, 2);
            Product forthProduct = new Product(label4, price4, 1);
            //Act
            this.productStock.Add(firstPproduct);
            this.productStock.Add(secondProduct);
            this.productStock.Add(thirdPproduct);
            this.productStock.Add(forthProduct);
            Product[] productsReturned = this.productStock.FindAllByPrice(givenPrice).ToArray();

            //Assert
            foreach (var product in productsReturned)
            {
                Assert.That(product.Price, Is.EqualTo(givenPrice));
            }

        }

        [Test]
        [TestCase("maratonki", 100, "slushalki", 60, "mishka", 60, "torpedo", 200, 50)]
        public void FindAllByPriceMethodShouldReturnEmptyEnumerationIfThereIsNotAnyProductInStockWithTheSamePriceAsTheGivenOne(
            string label1, decimal price1,
            string label2, decimal price2,
            string label3, decimal price3,
            string label4, decimal price4,
            decimal givenPrice)
        {
            //Arrange
            Product firstPproduct = new Product(label1, price1, 10);
            Product secondProduct = new Product(label2, price2, 5);
            Product thirdPproduct = new Product(label3, price3, 2);
            Product forthProduct = new Product(label4, price4, 1);
            //Act
            this.productStock.Add(firstPproduct);
            this.productStock.Add(secondProduct);
            this.productStock.Add(thirdPproduct);
            this.productStock.Add(forthProduct);
            Product[] productsReturned = this.productStock.FindAllByPrice(givenPrice).ToArray();

            //Assert
            Assert.That(productsReturned.Length, Is.EqualTo(0));
        }

        [Test]
        [TestCase("maratonki", 10, "slushalki", 5, "mishka", 2, "torpedo", 1, 5)]
        public void FindAllByQuantityMethodShouldReturnAllTheProductsInStockWithTheSameQuantityAsTheGivenOne(
            string label1, int quantity1,
            string label2, int quantity2,
            string label3, int quantity3,
            string label4, int quantity4,
            int givenQuantity)
        {
            //Arrange
            Product firstPproduct = new Product(label1, 100, quantity1);
            Product secondProduct = new Product(label2, 60, quantity2);
            Product thirdPproduct = new Product(label3, 60, quantity3);
            Product forthProduct = new Product(label4, 200, quantity4);
            //Act
            this.productStock.Add(firstPproduct);
            this.productStock.Add(secondProduct);
            this.productStock.Add(thirdPproduct);
            this.productStock.Add(forthProduct);
            Product[] productsReturned = this.productStock.FindAllByQuantity(givenQuantity).ToArray();

            //Assert
            foreach (var product in productsReturned)
            {
                Assert.That(product.Quantity, Is.EqualTo(givenQuantity));
            }

        }

        [Test]
        [TestCase("maratonki", 10, "slushalki", 5, "mishka", 2, "torpedo", 1, 11)]
        public void FindAllByQuantityMethodShouldReturnEmptyEnumerationIfThereIsNotAnyProductsInStockWithTheSameQuantityAsTheGivenOne(
            string label1, int quantity1,
            string label2, int quantity2,
            string label3, int quantity3,
            string label4, int quantity4,
            int givenQuantity)
        {
            //Arrange
            Product firstPproduct = new Product(label1, 100, quantity1);
            Product secondProduct = new Product(label2, 60, quantity2);
            Product thirdPproduct = new Product(label3, 60, quantity3);
            Product forthProduct = new Product(label4, 200, quantity4);
            //Act
            this.productStock.Add(firstPproduct);
            this.productStock.Add(secondProduct);
            this.productStock.Add(thirdPproduct);
            this.productStock.Add(forthProduct);
            Product[] productsReturned = this.productStock.FindAllByQuantity(givenQuantity).ToArray();

            //Assert
            Assert.That(productsReturned.Length, Is.EqualTo(0));
        }

        [Test]
        [TestCase(new string[4] { "maratonki", "slushalki", "mishka", "torpedo" }, new int[4] { 100, 60, 60, 200 }, new int[4] { 10, 5, 2, 1 })]
        public void GetEnumeratorShouldReturnAllTheProductsInStock(
            string[] labels,
            int[] prices,
            int[] quantities)
        {
            //Arrange
            for (int i = 0; i < labels.Length; i++)
            {
                this.productStock.Add(new Product(labels[i], (decimal)prices[i], quantities[i]));
            }
            //Act
            int counter = 0;


            //Assert
            foreach (var product in this.productStock)
            {
                Assert.AreEqual(labels[counter], product.Label);
                Assert.AreEqual((decimal)prices[counter], product.Price);
                Assert.AreEqual(quantities[counter], product.Quantity);
                counter++;
            }
        }

        [Test]
        [TestCase(new string[4] { "maratonki", "slushalki", "mishka", "torpedo" }, new int[4] { 100, 60, 60, 200 }, new int[4] { 10, 5, 2, 1 }, 0)]
        public void IndexerShouldReturnTheProductAtTheGivenIndexPosition(
            string[] labels,
            int[] prices,
            int[] quantities,
            int index)
        {
            //Arrange
            for (int i = 0; i < labels.Length; i++)
            {
                this.productStock.Add(new Product(labels[i], (decimal)prices[i], quantities[i]));
            }
            //Act
            Product wantedProduct = this.productStock[index];
            //Assert
            Assert.AreEqual(labels[index], wantedProduct.Label);
            Assert.AreEqual((decimal)prices[index], wantedProduct.Price);
            Assert.AreEqual(quantities[index], wantedProduct.Quantity);
        }

        [Test]
        [TestCase(new string[4] { "maratonki", "slushalki", "mishka", "torpedo" }, new int[4] { 100, 60, 60, 200 }, new int[4] { 10, 5, 2, 1 }, 200)]
        public void FindMostExpensiveProductShouldReturnTheProductWithTheHighestPrice(
            string[] labels,
            int[] prices,
            int[] quantities,
            decimal highestPrice)
        {
            //Arrange
            for (int i = 0; i < labels.Length; i++)
            {
                this.productStock.Add(new Product(labels[i], (decimal)prices[i], quantities[i]));
            }
            //Act
            Product wantedProduct = this.productStock.OrderByDescending(x => x.Price).First();
            //Assert
            Assert.AreEqual(highestPrice, wantedProduct.Price);

        }

        [Test]
        public void FindMostExpensiveProductShouldThrowExceptionIfThereIsNotAnyProductInStock()
        {
            //Assert
            Assert.Throws<InvalidOperationException>(() => this.productStock.FindMostExpensiveProduct());
        }
    }
}
