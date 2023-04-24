using DependencyStore.Models;

namespace DependencyStore.Contracts;

public interface ICustomerRepository
{
    Task<Customer?> GetByIdAsync(string id);
}