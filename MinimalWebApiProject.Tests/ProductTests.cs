using System.Net;
using System.Net.Http.Json;
using MinimalWebApiProject.Models;

namespace MinimalWebApiProject.Tests;

public class ProductTest
{
    [Fact]
    public async Task GetProducts()
    {
        await using var application = new ProductTestApplication();

        var client = application.CreateClient();
        var res = await client.GetAsync("/api/products");
        
        Assert.Equal(HttpStatusCode.OK, res.StatusCode);
    }

    [Fact]
    public async Task CreateProduct()
    {
        await using var application = new ProductTestApplication();

        var client = application.CreateClient();

        var res = await client.PostAsJsonAsync("/api/products", new Product {
            ProductName = "Iphone",
            PricePerUnit = 1000,
            QtyPerUnit = "10",
            UnitsInStock = 4,
            UnitsOnOrder = 10,
            Discontinued = false
        });
        Assert.Equal(HttpStatusCode.Created, res.StatusCode);
    }
}