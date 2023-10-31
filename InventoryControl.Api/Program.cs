using InventoryControl.Application.Repositories;
using InventoryControl.Application.Services;
using InventoryControl.Application.Services.CategoryService;
using InventoryControl.Domain.Repositories;
using InventoryControl.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionStringMySql = builder.Configuration.GetConnectionString("ConnectionMySql");
builder.Services.AddDbContext<DatabaseContext>(o => o.UseMySql(connectionStringMySql,
                                                            ServerVersion.Parse("MySql 8.0")));

builder.Services.AddDbContext<DatabaseContext>(
    options =>
        options.UseMySql(
            ServerVersion.Parse("MySql 8.0"),
            x => x.MigrationsAssembly("InventoryControl.Domain")));

builder.Services.AddScoped<IRepositoryBase, RepositoryBase>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
            
app.UseAuthorization();

app.MapControllers();

app.Run();
