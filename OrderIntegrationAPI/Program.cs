using AutoMapper;
using OrderIntegrationSystem.API.Middlewares;
using OrderIntegrationSystem.API.Profiles;
using OrderIntegrationSystem.Business.Interfaces;
using OrderIntegrationSystem.Business.Services;
using OrderIntegrationSystem.Common.FileOperations.Implementations;
using OrderIntegrationSystem.Common.FileOperations.Interfaces;
using OrderIntegrationSystem.Common.Parsers.Implementations;
using OrderIntegrationSystem.Common.Parsers.Interfaces;
using OrderIntegrationSystem.MockSystems.ERPSystem.Implementations;
using OrderIntegrationSystem.MockSystems.ERPSystem.Interfaces;
using OrderIntegrationSystem.SupplierDatabase.DbContexts;
using OrderIntegrationSystem.SupplierDatabase.DbContexts.Abstracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IFileReader, FileReader>();
builder.Services.AddSingleton<IOrderParser, OrderParser>();

builder.Services.AddSingleton<IOrderBusiness, OrderBusiness>();
builder.Services.AddSingleton<ISupplierContext, SupplierContext>();

builder.Services.AddSingleton<IERPSystemService, ERPSystemService>();

Uri endPointOrderManagement = new("https://ordersmanagementsystem.com/");
HttpClient httpClient = new()
{
    BaseAddress = endPointOrderManagement
};

builder.Services.AddSingleton<HttpClient>(httpClient);

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<CustomExceptionHandlerMiddleware>();

app.MapControllers();

app.Run();
