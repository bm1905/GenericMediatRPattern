using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GenericMediatRPattern.Models;
using GenericMediatRPattern.PaymentService.Command;
using GenericMediatRPattern.PaymentService.Query;
using GenericMediatRPattern.PaymentValidationProcessor.Command;
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
        [Route("SetCashPayment")]
        public async Task<ActionResult> SetCashPayment([FromBody] CashPaymentModel model)
        {
            string key = Guid.NewGuid().ToString();
            var paymentQuery = new PaymentManagerSetHandlerRequest<CashPaymentModel>(key, model);
            var paymentResponse = await _mediator.Send(paymentQuery);

            if (!paymentResponse.Result) return Ok(false);

            var paymentValidationProcessorQuery = new PaymentValidationProcessorHandlerRequest(key, model.Locale);
            var paymentValidationProcessorResponse = await _mediator.Send(paymentValidationProcessorQuery);

            return paymentValidationProcessorResponse.Response.IsValid ? Ok(new { Data = paymentValidationProcessorResponse }) : Ok(false);
        }

        [HttpGet]
        [Route("GetCashPayment")]
        public async Task<ActionResult<CashPaymentModel>> GetCashPayment(string key)
        {
            var query = new PaymentManagerGetHandlerRequest<CashPaymentModel>(key);
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetAllCashPayments")]
        public async Task<ActionResult<List<CashPaymentModel>>> GetAllCashPayments()
        {
            var query = new PaymentManagerGetAllHandlerRequest<CashPaymentModel>();
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpPost]
        [Route("SetCheckPayment")]
        public async Task<ActionResult> SetCheckPayment([FromBody] CheckPaymentModel model)
        {
            string key = Guid.NewGuid().ToString();
            var paymentQuery = new PaymentManagerSetHandlerRequest<CheckPaymentModel>(key, model);
            var paymentResponse = await _mediator.Send(paymentQuery);

            if (!paymentResponse.Result) return Ok(false);

            var paymentValidationProcessorQuery = new PaymentValidationProcessorHandlerRequest(key, model.Locale);
            var paymentValidationProcessorResponse = await _mediator.Send(paymentValidationProcessorQuery);

            return paymentValidationProcessorResponse.Response.IsValid ? Ok(new { Data = paymentValidationProcessorResponse }) : Ok(false);
        }

        [HttpGet]
        [Route("GetCheckPayment")]
        public async Task<ActionResult<CheckPaymentModel>> GetCheckPayment(string key)
        {
            var query = new PaymentManagerGetHandlerRequest<CheckPaymentModel>(key);
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetAllCheckPayments")]
        public async Task<ActionResult<List<CheckPaymentModel>>> GetAllCheckPayments()
        {
            var query = new PaymentManagerGetAllHandlerRequest<CheckPaymentModel>();
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
