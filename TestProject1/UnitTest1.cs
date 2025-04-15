using _21_12;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddItem()
        {
            // Arrange
            Backpack backpack = new Backpack
            {
                Color = "Чорний",
                Brand = "Adidas",
                Manufacturer = "Україна",
                Fabric = "Нейлон",
                Weight = 1.2,
                Volume = 30.0
            };

            Item item = new Item("Книга", 5.0);

            // Act
            backpack.AddItem(item);

            // Assert
            Assert.AreEqual(1, backpack.Contents.Count);
            Assert.AreEqual(item, backpack.Contents[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestAddItemExceedsVolume()
        {
            // Arrange
            Backpack backpack = new Backpack
            {
                Volume = 10.0
            };

            Item item1 = new Item("Книга", 5.0);
            Item item2 = new Item("Ноутбук", 6.0);

            // Act
            backpack.AddItem(item1);
            backpack.AddItem(item2);
        }

        [TestMethod]
        public void TestGetUsedVolume()
        {
            // Arrange
            Backpack backpack = new Backpack
            {
                Volume = 30.0
            };

            Item item1 = new Item("Книга", 5.0);
            Item item2 = new Item("Ноутбук", 15.0);

            // Act
            backpack.AddItem(item1);
            backpack.AddItem(item2);
            double usedVolume = backpack.GetUsedVolume();

            // Assert
            Assert.AreEqual(20.0, usedVolume);
        }

        [TestMethod]
        public void TestItemAddedEvent()
        {
            // Arrange
            Backpack backpack = new Backpack
            {
                Volume = 30.0
            };

            Item item = new Item("Книга", 5.0);
            bool eventFired = false;

            backpack.ItemAdded += (sender, e) =>
            {
                eventFired = true;
                Assert.AreEqual(item, e);
            };

            // Act
            backpack.AddItem(item);

            // Assert
            Assert.IsTrue(eventFired);
        }
    }
}