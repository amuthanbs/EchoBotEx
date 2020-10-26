using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoBotEx.Greeting
{
    public interface IGreetingMessage
    {
        public Task<string> CheckGreetings(string msg);
        public Task<string> GreetingMessage(string message);
    }
}
