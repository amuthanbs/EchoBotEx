using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EchoBotEx.TransferRequests
{
    public class TransferRequest : ITransferRequest
    {
        public string ProcessTransfer(string message)
        {
            var splitted = message.ToLower().Split(' ');
            var reply = string.Empty;
            string amount = null, toAccount = null;//, fromAccount=null;
            bool found = false;
            foreach (string str in splitted)
            {
                if (str.Equals("transfer"))
                {
                    found = true;
                }
                if (found && str.Contains("rs"))
                {
                    amount = str;
                }
                if (found && Regex.IsMatch(str, ChatBotConstant.RegexNumberic))
                {
                    toAccount = str;
                }
            }
            if (string.IsNullOrEmpty(amount) && string.IsNullOrEmpty(toAccount))
            {
                reply = " if you want to transfer please give amount and account";
            }else if (string.IsNullOrEmpty(amount))
            {
                reply = " please provide the amount details to transfer to account:"+toAccount;
            }
            else if (string.IsNullOrEmpty(toAccount))
            {
                reply = " please provide the account details to transfer the amount :" + amount;
            }
            else
            {
                reply = amount + " will be transfered to account " + toAccount;
            }
            return reply;
        }
    }
}
