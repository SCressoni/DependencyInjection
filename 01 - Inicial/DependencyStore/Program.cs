using DependencyStore;
using DependencyStore.Contracts;
using DependencyStore.Extensions;
using DependencyStore.Repositories;
using DependencyStore.Services;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<Configuration>();

// Caso for usar Entity Framework usar o AddDbContext.
//builder.Services.AddScoped<SqlConnection>(x => new SqlConnection("CONN_STRING"));
//usando extention methods
var conn = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSqlConnection(conn);

// De:
//builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
//builder.Services.AddTransient<IPromoCodeRepository, PromoCodeRepository>();
// builder.Services.AddTransient<IDeliveryFeeService, DeliveryFeeService>();
// para: Extension Methods:
builder.Services.AddRepository();
builder.Services.AddServices();



builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();