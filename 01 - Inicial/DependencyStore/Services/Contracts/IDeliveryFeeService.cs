namespace DependencyStore.Services;

public interface IDeliveryFeeService
{
    Task<decimal> GetDeliveryFeeAsync(string zipcode);
}