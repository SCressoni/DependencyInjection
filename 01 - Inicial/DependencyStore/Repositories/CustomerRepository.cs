using Dapper;
using DependencyStore.Contracts;
using DependencyStore.Models;
using Microsoft.Data.SqlClient;

namespace DependencyStore.Repositories;
public class CustomerRepository : ICustomerRepository
{
    private readonly SqlConnection _connection;
    
    public CustomerRepository(SqlConnection connection)
        => _connection = connection;
    
    public async Task<Customer?> GetByIdAsync(string customerId)
    {
        // #1 - Recupera o cliente
        await using (var conn = new SqlConnection("CONN_STRING"))
        {
            const string query = "SELECT [Id], [Name], [Email] FROM CUSTOMER WHERE ID=@customerId";
            return await _connection.QueryFirstOrDefaultAsync<Customer>(query, new
            {
                id = customerId
            });
        }
    }
}