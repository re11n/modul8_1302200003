using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace modul8_1302200003
{
    internal class program
    {
        static void Main(string[] args)
        {
            BankTransferConfig bkconfig = new BankTransferConfig();
            dynamic config = GetConfig(bkconfig);

            if (config.lang == "en")
            {
                Console.WriteLine("Please insert the amount of money to transfer:");
            }
            else if (config.lang == "id")
            {
                Console.WriteLine("Masukkan jumlah uang yang akan di-transfer:");
            }

            string uangDiTranferStr = Console.ReadLine();
            int uangDiTransfer = int.Parse(uangDiTranferStr);
            int biayaTransfer;

            if (uangDiTransfer <= int.Parse(config.transfer.threshold))
            {
                biayaTransfer = int.Parse(config.transfer.low_fee);
            } else
            {
                biayaTransfer = config.transfer.high_fee;
            }

            if (config.lang == "en")
            {
                Console.WriteLine("Transfer fee = " + biayaTransfer);
                Console.WriteLine("Total amount = " + (biayaTransfer + uangDiTransfer) );

            } else if ( config.lang == "id")
            {
                Console.WriteLine("Biaya Transfer = " + biayaTransfer);
                Console.WriteLine("Total biaya = " + (biayaTransfer + uangDiTransfer));

            }

            string confirm;
            if(config.lang == "en")
            {
                Console.WriteLine("Please type '" + config.confirmation.en + "' to confirm he transaction: ");
                confirm = Console.ReadLine();

                if (confirm == (string)config.confirmation.en)
                {
                    Console.WriteLine("the transfer is completed");
                } else
                {
                    Console.WriteLine("transfer is canceled");
                }
            } else if (config.lang == "id")
            {
                Console.WriteLine("ketik '" + config.confirmation.en + "' untuk mengkonfirmasi transaksi: ");
                confirm = Console.ReadLine();

                if (confirm == (string)config.confirmation.en)
                {
                    Console.WriteLine("transfer berhasil");
                }
                else
                {
                    Console.WriteLine("transfer dibatalkan");
                }
            }

        }

        static dynamic GetConfig(BankTransferConfig bkconfig)
        {
            return bkconfig.ReadJson();
        }


    }
}