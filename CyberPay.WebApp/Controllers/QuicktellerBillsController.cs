using CyberPay.Cmd.Payload.Quickteller;
using CyberPay.Cmd.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CyberPay.WebApp.Controllers
{
    [RoutePrefix("api/quickteller")]
    public class QuicktellerBillsController : ApiController
    {
        private readonly IQuickTellerBillProvider billProvider;

        public QuicktellerBillsController() : this(new QuickTellerBillProvider())
        {
        }

        public QuicktellerBillsController(IQuickTellerBillProvider billProvider)
        {
            this.billProvider = billProvider;
        }

        [Route("getbillers")]
        public HttpResponseMessage GetBillers()
        {
            var billers = billProvider.GetBillers();
            ApiResult<List<QuicktellerBiller>> result = new ApiResult<List<QuicktellerBiller>>();
            return Request.CreateResponse(billers);
        }

        [Route("getBankCodes")]
        public HttpResponseMessage GetCodes()
        {
            var banksCodes = billProvider.GetBanksCodes();
            ApiResult<List<QuicktellerBiller>> res = new ApiResult<List<QuicktellerBiller>>();
            return Request.CreateResponse(banksCodes);
        }
       
        [HttpPost]
        [Route("sendPaymentTransactions")]
        public async Task<IHttpActionResult> SendPaymentTransactions(SendBillPaymentTransaction model)
        {
            if (ModelState.IsValid)
            {
                var send = billProvider.SendBillPaymentTransaction(model.Amount,model.PinData,model.SecureData,model.MSISDN,model.TransactionRef,model.CardBin);
                ApiResult<SendBillPaymentTransaction> res = new ApiResult<SendBillPaymentTransaction>();
                return Created("QuickTellerBillProvider/SendBillPaymentTransaction", send);
            }
            return BadRequest(ModelState);
        }
    }
}