using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoBotEx
{
    public class ChatBotConstant
    {
        public readonly static string RegexAlphaNumeric = "^[a-zA-Z0-9]*$";
        public readonly static string RegexNumberic = "^[0-9]*$";
        public readonly static string[] BankWords = { 
            "transfer", "pay", "trans", "payment", "services" };
        public readonly static string[] greetingWords = {
            "good morning", "good afternoon", "hi", "hi team", "hello", "how are you", "whats up" };
    }
}
