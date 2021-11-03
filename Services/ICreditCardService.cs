using NordicStationCodeTestPart3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NordicStationCodeTestPart3.Services
{
    public interface ICreditCardService
    {
        Task<bool> AddCreditCardAsync(CreditCard creditCard);
        Task<bool> CreditCardExists(int id);
        Task DeleteCardAsync(CreditCard creditCard);
        Task<CreditCard> GetCardByIdAsync(int id);
        Task<List<CreditCard>> GetCreditCardsAsync();
        Task<bool> UpdateCreditCardAsync(CreditCard creditCard);
    }
}