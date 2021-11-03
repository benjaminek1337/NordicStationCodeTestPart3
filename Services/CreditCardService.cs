using NordicStationCodeTestPart3.Models;
using NordicStationCodeTestPart3.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordicStationCodeTestPart3.Services
{
    public class CreditCardService : ICreditCardService
    {
        private readonly ICreditCardDbRepository<CreditCard> creditCards;

        public CreditCardService(ICreditCardDbRepository<CreditCard> creditCards)
        {
            this.creditCards = creditCards;
        }

        public async Task<CreditCard> GetCardByIdAsync(int id)
        {
            return await creditCards.GetByIdAsync(id);
        }

        public async Task<List<CreditCard>> GetCreditCardsAsync()
        {
            var creditCardsEnumerable = await creditCards.GetAllAsync();
            return creditCardsEnumerable.ToList();
        }

        public async Task<bool> AddCreditCardAsync(CreditCard creditCard)
        {
            bool cardNumberExists = await creditCards.ExistsAsync(x => x.CardNumber == creditCard.CardNumber);

            if (cardNumberExists)
            {
                return false;
            }

            creditCard.ModifiedDate = DateTime.Now;
            await creditCards.AddAsync(creditCard);
            return true;
        }

        public async Task<bool> UpdateCreditCardAsync(CreditCard creditCard)
        {
            bool cardNumberExists = await creditCards.ExistsAsync(x => x.CardNumber == creditCard.CardNumber && x.CreditCardID != creditCard.CreditCardID);

            if (cardNumberExists)
            {
                return false;
            }

            creditCard.ModifiedDate = DateTime.Now;
            await creditCards.UpdateAsync(creditCard);

            return true;
        }

        public async Task DeleteCardAsync(CreditCard creditCard)
        {
            await creditCards.DeleteAsync(creditCard);
        }

        public async Task<bool> CreditCardExists(int id)
        {
            return await creditCards.ExistsAsync(card => card.CreditCardID == id);
        }

    }
}
