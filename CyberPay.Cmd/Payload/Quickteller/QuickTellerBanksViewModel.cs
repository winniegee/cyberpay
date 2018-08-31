using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberPay.Cmd.Payload.Quickteller
{
    public class QuickTellerBanksViewModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("cbnCode")]
        public string CBNCode { get; set; }
        [JsonProperty("bankName")]
        public string BankName { get; set; }
        [JsonProperty("bankCode")]
        public string BankCode { get; set; }
    }
}
