using Apsiyon.CreditCardService.Model;
using Apsiyon.CreditCardService.Model.Mongo;
using Apsiyon.CreditCardService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apsiyon.CreditCardService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class BankingController : ControllerBase
    {
        private readonly PaymentService _paymentService;

        public BankingController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("WithdrawMoney")]
        public async Task<IActionResult> WithdrawMoney(CreditCardViewModel model)
        {
            var result = await _paymentService.WithdrawMoney(new Model.Mongo.CreditCard
            {
                CardNumber = model.CardNumber,
                Cvv = model.Cvv,
                Owner = model.Owner,
                ValidMonth = model.ValidMonth,
                ValidYear = model.ValidYear
            }, model.Money);
            return Ok(result);
        }


        [HttpPost("AddCard")]
        public async Task<IActionResult> AddCard(CreditCardViewModel model)
        {
            CreditCard creditCard = new CreditCard
            {
                CardNumber = model.CardNumber,
                Cvv = model.Cvv,
                Owner = model.Owner,
                ValidMonth = model.ValidMonth,
                ValidYear = model.ValidYear,
                Balance = model.Money
            };

            await _paymentService.Add(creditCard);

            return Ok();
        }

    }
}
