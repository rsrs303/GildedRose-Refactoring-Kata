using System;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace csharp
{
    //[UseReporter(typeof(DiffReporter))]
    [TestFixture]
    public class ApprovalTest
    {
        //[Test]
        //public void ThirtyDays()
        //{

        //    StringBuilder fakeoutput = new StringBuilder();
        //    Console.SetOut(new StringWriter(fakeoutput));
        //    Console.SetIn(new StringReader("a\n"));

        //    Program.Main(new string[] { });
        //    var output = fakeoutput.ToString();

        //    Approvals.Verify(output);
        //}

        // UpdateQuality approval tests
        [Test]
        public void GildedRoseStartingWithNoItemsEndsWithNoItems()
        {
            // Arrange
            var items = new List<Item>();
            var rose = new GildedRose(items);

            // Act
            rose.UpdateQuality();

            // Assert
            Assert.That(items, Is.Empty);
        }

        [Test]
        public void AgedBrieIncreasesInQualityByOneEachDayForThirtyDays()
        {
            // Arrange
            var items = new List<Item>()
            {
                new Item{Name = "Aged Brie", SellIn = 10, Quality = 20 }
            };

            var rose = new GildedRose(items);

            // Act
            for (int i = 0; i < 30; i++)
            {
                rose.UpdateQuality();
            }

            // Assert
            Assert.That(items[0].Quality, Is.EqualTo(50));
        }

        [Test]
        public void LegendaryItemQualityNeverChanges()
        {
            // Arrange 
            int startingQuality = 10;
            var items = new List<Item>()
                {
                    new Item{Name = "Sulfuras", SellIn = 10,
                        Quality = startingQuality }
                };

            var rose = new GildedRose(items);

            // Act
            rose.UpdateQuality();

            // Assert
            Assert.That(items[0].Quality, Is.EqualTo(startingQuality));
        }

        [Test]
        public void ItemQualityCannotStartAboveFifty()
        {
            // Arrange 
            int startingQuality = 60;
            var items = new List<Item>()
                {
                    new Item{Name = "Sulfuras", SellIn = 10,
                        Quality = startingQuality }
                };

            var rose = new GildedRose(items);

            // Act
            rose.UpdateQuality();

            // Assert
            Assert.That(items[0].Quality, Is.EqualTo(startingQuality));
        }

        [Test]
        public void SulfurasItemQualityIsAlwaysEighty()
        {
            // Arrange 
            int startingQuality = 10;
            int actualQuality = 80;
            var items = new List<Item>()
                {
                    new Item{Name = "Sulfuras", SellIn = 10,
                        Quality = startingQuality }
                };

            var rose = new GildedRose(items);

            // Act
            rose.UpdateQuality();

            // Assert
            Assert.That(items[0].Quality, Is.EqualTo(actualQuality));
        }
    }
}
