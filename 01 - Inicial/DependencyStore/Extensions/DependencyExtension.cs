using DependencyStore.Contracts;
using DependencyStore.Repositories;
using DependencyStore.Services;
using Microsoft.Data.SqlClient;

namespace DependencyStore.Extensions;

public static class DependencyExtension
{
    // usando o "this IServiceCollection service" o .net ignora o parametro, nao sendo necessario 
    // informar na chamada - exemplo da chamada na classe program:
    // DependencyExtension.AddSqlConection(connectionString);
    public static void AddSqlConnection(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<SqlConnection>(x => new SqlConnection(connectionString));
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IDeliveryFeeService, DeliveryFeeService>();
    }

    public static void AddRepository(this IServiceCollection services)
    {
        services.AddTransient<ICustomerRepository, CustomerRepository>();
        services.AddTransient<IPromoCodeRepository, PromoCodeRepository>();
    }

}