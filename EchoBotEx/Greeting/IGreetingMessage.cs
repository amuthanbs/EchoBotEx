using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoBotEx.Greeting
{
    public interface IGreetingMessage
    {
        public string CheckGreetings(string msg);
        //string GenerateGreetingMessage(string message);
    }
}
