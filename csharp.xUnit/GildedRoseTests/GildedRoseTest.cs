using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void foo()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal("foo", Items[0].Name);
    }

    [Fact]
    public void givenSellInPositiveQualityDownByOne()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 20 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(19, Items[0].Quality);
    }
    [Fact]
    public void givenSellInNotPositiveQualityDownByTwo()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 20 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(18, Items[0].Quality);
    }
    [Fact]
    public void nonNegativeQuality()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 0 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(0, Items[0].Quality);
    }
    [Fact]
    public void agedBrieQualityIncrease()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(1, Items[0].Quality);
    }
    [Fact]
    public void qualityStayAtFifty()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 50 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(50, Items[0].Quality);
    }
    [Fact]
    public void sulfurasNeverDecreasesQuality()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(80, Items[0].Quality);
    }
    [Fact]
    public void sulfurasSellinNeverChanges()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(10, Items[0].SellIn);
    }
    [Fact]
    public void bspQualIncrBy2SellInTenDays()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(22, Items[0].Quality);
    }
    [Fact]
    public void bspQualIncrBy3SellInFiveDays()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(23, Items[0].Quality);
    }
    [Fact]
    public void backStagePassQualityAtZeroAfterConcert()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 49 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(0, Items[0].Quality);
    }
}

//{
//                Name = "Backstage passes to a TAFKAL80ETC concert",
//                SellIn = 15,
//                Quality = 20
//            },
//            new Item
//            {
//                Name = "Backstage passes to a TAFKAL80ETC concert",
//                SellIn = 10,
//                Quality = 49
//            },
//            new Item
//            {
//                Name = "Backstage passes to a TAFKAL80ETC concert",
//                SellIn = 5,
//                Quality = 49
//            }