using System;
using System.Threading.Tasks;
using GenericMediatRPattern.Models;
using GenericMediatRPattern.PaymentService.Command;
using GenericMediatRPattern.PaymentService.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GenericMediatRPattern.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("SetCashpayment")]
        public async Task<ActionResult> SetCashPayment([FromBody] CashPaymentModel model)
        {
            string key = Guid.NewGuid().ToString();
            var query = new PaymentManagerSetHandlerRequest<CashPaymentModel>(key, model);
            var response = await _mediator.Send(query);
            return Ok(response.Result);
        }

        [HttpGet]
        [Route("GetCashpayment")]
        public async Task<ActionResult<CashPaymentModel>> GetCashPayment(string key)
        {
            var query = new PaymentManagerGetHandlerRequest<CashPaymentModel>(key);
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpPost]
        [Route("SetCheckPayment")]
        public async Task<ActionResult> SetCheckPayment([FromBody] CheckPaymentModel model)
        {
            string key = Guid.NewGuid().ToString();
            var query = new PaymentManagerSetHandlerRequest<CheckPaymentModel>(key, model);
            var response = await _mediator.Send(query);
            return Ok(response.Result);
        }

        [HttpGet]
        [Route("GetCheckPayment")]
        public async Task<ActionResult<CashPaymentModel>> GetCheckPayment(string key)
        {
            var query = new PaymentManagerGetHandlerRequest<CheckPaymentModel>(key);
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
