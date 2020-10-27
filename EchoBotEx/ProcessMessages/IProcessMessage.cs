using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoBotEx.ProcessMessages
{
    public interface IProcessMessage
    {
        public Task<string> MessageController(string message);
    }
}
