using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using MinimalWebApiProject.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MinimalWebApiProject.Data;

class ProductTestApplication: WebApplicationFactory<Product>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        var root = new InMemoryDatabaseRoot();

        builder.ConfigureServices(services => {
            services.AddScoped(s => {
                return new DbContextOptionsBuilder<ProductDbContext>()
                            .UseInMemoryDatabase("TestDB", root)
                            .UseApplicationServiceProvider(s)
                            .Options;
            });
        });
        return base.CreateHost(builder);
    }
}