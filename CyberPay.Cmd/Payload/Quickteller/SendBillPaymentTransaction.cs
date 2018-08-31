using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberPay.Cmd.Payload.Quickteller
{
   public class SendBillPaymentTransaction
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        [JsonProperty("pinData")]
        public string PinData { get; set; }
        [JsonProperty("secureData")]
        public string SecureData { get; set; }
        [JsonProperty("msisdn")]
        public long MSISDN { get; set; }
        [JsonProperty("transactionRef")]
        public string TransactionRef { get; set; }
        [JsonProperty("cardBin")]
        public Int64 CardBin { get; set; }
    }
}
