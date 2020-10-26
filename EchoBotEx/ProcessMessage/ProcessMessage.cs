using EchoBotEx.Greeting;
using System;
using System.Threading.Tasks;

namespace EchoBotEx.ProcessMessages
{
    public class ProcessMessage : IProcessMessage
    {
        private readonly IGreetingMessage greetMessage;
        public ProcessMessage(IGreetingMessage greetingMessage)
        {
            this.greetMessage = greetingMessage;
        }
        public Task<string> MessageController(string message)
        {
            Task<string> reply = greetMessage.CheckGreetings(message);
            return reply;
        }
    }
}
