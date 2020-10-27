using EchoBotEx.Greeting;
using System;
using System.Threading.Tasks;
using Porter2Stemmer;
using System.Collections.Generic;
using EchoBotEx.TransferRequests;

namespace EchoBotEx.ProcessMessages
{
    public class ProcessMessage : IProcessMessage
    {
        private readonly IGreetingMessage greetMessage;
        private readonly ITransferRequest transferRequest;
        public ProcessMessage(IGreetingMessage greetingMessage,
            ITransferRequest transferRequest)
        {
            this.greetMessage = greetingMessage;
            this.transferRequest = transferRequest;
        }
        public Task<string> MessageController(string message)
        {
            //Greeting 
            var result = greetMessage.CheckGreetings(message);
            if (!string.IsNullOrEmpty(result))
            {
                return Task.FromResult(result);
            }

            string stemmedMessage = Stemming(message);
            List<string> strlst = FindKeyword(stemmedMessage);
            if ((strlst.Count > 1))
            {
                return Task.FromResult("Can you please provide exact details");
            }
            string route = FindRoutingKeyword(strlst[0]);
            switch (route)
            {
                case "transfer":
                    result = transferRequest.ProcessTransfer(message);
                    break;
                default:
                    break;
            }
            //Task<string> reply = greetMessage.CheckGreetings(message);
            return Task.FromResult(result);
        }
        string Stemming(string message)
        {
            string[] splited = message.Split(' ');
            string newString = "";
            foreach (string s in splited)
            {
                if (Array.IndexOf(ChatBotConstant.BankWords, s) >= 0)
                    newString += s + " ";
            }
            return newString;
        }
        List<string> FindKeyword(string message)
        {
            var strlst = new List<String>();
            var splitted = message.Split(' ');
            foreach (string str in splitted)
            {
                if (Array.IndexOf(ChatBotConstant.BankWords, str) >= 0)
                {
                    strlst.Add(str);
                }
            }
            return strlst;
        }
        string FindRoutingKeyword(string keywords)
        {
            switch (keywords)
            {
                case "trans" :
                case "transfer":
                    return "transfer";
                case "pay":
                case "payment":
                    return "payments";
                case "service":
                    return "services";
                default:
                    return "error";
            }
        }
    }
}
