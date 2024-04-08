using NUnit.Framework;

using TestApp.Product;

namespace TestApp.Tests;

[TestFixture]
public class ProductInventoryTests
{
    private ProductInventory _inventory = null!;
    
    [SetUp]
    public void SetUp()
    {
        this._inventory = new();
    }
    
    [Test]
    public void Test_AddProduct_ProductAddedToInventory()
    {
        // Arrange
        var inventory = new ProductInventory();
        string name = "Bumper";
        double price = 1000;
        int quantity = 2;

        // Act
        inventory.AddProduct(name, price, quantity);
        string inventoryDisplay = inventory.DisplayInventory();

        // Assert
        StringAssert.Contains(name, inventoryDisplay);
        StringAssert.Contains(price.ToString(" "), inventoryDisplay);
        StringAssert.Contains(quantity.ToString(), inventoryDisplay);
    }

    [Test]
    public void Test_DisplayInventory_NoProducts_ReturnsEmptyString()
    {
        // Arrange
        var inventory = new ProductInventory();

        // Act
        string inventoryDisplay = inventory.DisplayInventory();

        // Assert
        Assert.AreEqual("Product Inventory:", inventoryDisplay);
    }

    [Test]
    public void Test_DisplayInventory_WithProducts_ReturnsFormattedInventory()
    {
        // Arrange
        var inventory = new ProductInventory();
        string name = "Test Product";
        double price = 10.99;
        int quantity = 5;
        inventory.AddProduct(name, price, quantity);

        // Act
        string inventoryDisplay = inventory.DisplayInventory();

        // Assert
        StringAssert.Contains(name, inventoryDisplay);
        StringAssert.Contains(price.ToString(" "), inventoryDisplay);
        StringAssert.Contains(quantity.ToString(), inventoryDisplay);
    }

    [Test]
    public void Test_CalculateTotalValue_NoProducts_ReturnsZero()
    {
        // Arrange
        var inventory = new ProductInventory();

        // Act
        double totalValue = inventory.CalculateTotalValue();

        // Assert
        Assert.AreEqual(0, totalValue);
    }

    [Test]
    public void Test_CalculateTotalValue_WithProducts_ReturnsTotalValue()
    {
        // Arrange
        var inventory = new ProductInventory();
        string name = "Test Product";
        double price = 10.99;
        int quantity = 5;
        inventory.AddProduct(name, price, quantity);
        double expectedTotalValue = price * quantity;

        // Act
        double actualTotalValue = inventory.CalculateTotalValue();

        // Assert
        Assert.AreEqual(expectedTotalValue, actualTotalValue);
    }
}
