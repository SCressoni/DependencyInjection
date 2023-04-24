using DependencyStore.Models;

namespace DependencyStore.Contracts;

public interface IPromoCodeRepository
{
    Task<PromoCode?> GetPromoCodeAsync(string promoCode);
}