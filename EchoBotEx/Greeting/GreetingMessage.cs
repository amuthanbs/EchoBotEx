using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoBotEx.Greeting
{
    public class GreetingMessage : IGreetingMessage
    {
        public string CheckGreetings(string msg)
        {
            string[] greetingWords = { 
                "good morning", "good afternoon", "hi", "hi team", "hello", "how are you", "whats up" };
            if (ChatBotConstant.greetingWords.Contains(msg.ToLower()))
            {
                return GenerateGreetingMessage();
            }
            return "";
        }

        string GenerateGreetingMessage()
        {
            string message = "Good Morning";
            int tm = DateTime.Now.Hour;
            if(!(tm>=0 && tm<= 12)){
                message = "Good Evening";
            }
            return message;
        }
    }
}
