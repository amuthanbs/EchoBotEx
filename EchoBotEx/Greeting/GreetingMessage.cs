using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoBotEx.Greeting
{
    public class GreetingMessage : IGreetingMessage
    {
        //public async Task<string> IGreetingMessage.GreetingMessage(string message)
        //{
            
        //}
        
        public async Task<string> CheckGreetings(string msg)
        {
            string[] greetingWords = { "good morning",

        "good afternoon",

        "hi",

        "hi team",

        "hi name",

        "hello",

        "how are you",

        "whats up" };

            string[] msgSplit = msg.Split(' ');

            return await Task.FromResult("");
        }

        async Task<string> IGreetingMessage.GreetingMessage(string message)
        {
            
            int tm = DateTime.Now.Hour;
            if(tm>=0 && tm<= 12){
                message = "Good Morning";
            }else if(tm>12){
                message = "Good Evening";
            }
            
            return await Task.FromResult(message);
        }
    }
}
