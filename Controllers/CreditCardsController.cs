using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NordicStationCodeTestPart3.DataAccess;
using NordicStationCodeTestPart3.Models;
using NordicStationCodeTestPart3.Services;

namespace NordicStationCodeTestPart3
{
    public class CreditCardsController : Controller
    {
        private readonly ICreditCardService creditCardService;

        public CreditCardsController(ICreditCardService creditCardService)
        {
            this.creditCardService = creditCardService;
        }

        // GET: CreditCards
        public async Task<IActionResult> Index()
        {
            return View(await creditCardService.GetCreditCardsAsync());
        }

        // GET: CreditCards/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var creditCard = await creditCardService.GetCardByIdAsync(id);

            if (id == 0 && creditCard == null)
            {
                return BadRequest();
            }

            if (creditCard == null)
            {
                return NotFound();
            }

            return View(creditCard);
        }

        // GET: CreditCards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CreditCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CreditCardID,CardType,CardNumber,ExpMonth,ExpYear")] CreditCard creditCard)
        {
            if (ModelState.IsValid)
            {
                if(await creditCardService.AddCreditCardAsync(creditCard))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["CreationError"] = $"The creditcard number { creditCard.CardNumber } already exists";
            return View(creditCard);
        }

        // GET: CreditCards/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var creditCard = await creditCardService.GetCardByIdAsync(id);

            if (id == 0 && creditCard == null)
            {
                return BadRequest();
            }

            if (creditCard == null)
            {
                return NotFound();
            }

            return View(creditCard);
        }

        // POST: CreditCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CreditCardID,CardType,CardNumber,ExpMonth,ExpYear")] CreditCard creditCard)
        {
            if (id != creditCard.CreditCardID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if(await creditCardService.UpdateCreditCardAsync(creditCard))
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await creditCardService.CreditCardExists(creditCard.CreditCardID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            ViewData["UpdateError"] = $"The creditcard number { creditCard.CardNumber } already exists on another card";
            return View(creditCard);
        }

        // GET: CreditCards/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var creditCard = await creditCardService.GetCardByIdAsync(id);
            if (id == 0 && creditCard == null)
            {
                return BadRequest();
            }

            if (creditCard == null)
            {
                return NotFound();
            }

            return View(creditCard);
        }

        // POST: CreditCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var creditCard = await creditCardService.GetCardByIdAsync(id);
            try
            {
                await creditCardService.DeleteCardAsync(creditCard);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Delete));
            }
            
        }

    }
}
