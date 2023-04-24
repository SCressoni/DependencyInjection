using RestSharp;

namespace DependencyStore.Services;

public class DeliveryFeeService :IDeliveryFeeService
{
    private readonly Configuration _configuration;

    public DeliveryFeeService(Configuration configuration)
        => _configuration = configuration;
    
    
    public async Task<decimal> GetDeliveryFeeAsync(string zipcode)
    {
        //var client = new RestClient("https://consultafrete.io/cep/");
        var client = new RestClient(_configuration.DeliveryFeeServiceUrl);
        var request = new RestRequest()
            .AddJsonBody(new
            {
                ZipCode = zipcode
            });
        var response = await client.PostAsync<decimal>(request);
        
        return response < 5 ? 5 : response;
          
    }
}