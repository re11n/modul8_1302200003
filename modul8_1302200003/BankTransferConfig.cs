using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace modul8_1302200003
{
    class BankTransferConfig
    {
        public string lang { get; set; }
        public transfers transfer { get; set; }
        public string method { get; set; }
        public confirmation confirmation { get; set; }
        public BankTransferConfig() { }
        public BankTransferConfig(string lang, transfers transfer, string method, confirmation confirmation)
        {
            this.lang = lang;
            this.transfer = transfer;
            this.method = method;
            this.confirmation = confirmation;
        }

        internal dynamic ReadJson()
        {
            string file = "bank_transfer_config.json";
            string dataStr = File.ReadAllText(file);
            BankTransferConfig dataBank = JsonSerializer.Deserialize<BankTransferConfig>(dataStr);
            return dataBank;
        }
    }

    class transfers
    {
        public string threshold { get; set; }
        public string low_fee { get; set; }
        public string high_fee { get; set; }
        public transfers() { }
        public transfers(string threshold, string low_fee, string high_fee)
        {
            this.threshold = threshold;
            this.low_fee = low_fee;
            this.high_fee = high_fee;
        }
    }

    class confirmation
    {
        public string en { get; set; }
        public string id { get; set; }
        public confirmation() { }
        public confirmation(string en, string id)
        {
            this.en = en;
            this.id = id;
        }

    }



}