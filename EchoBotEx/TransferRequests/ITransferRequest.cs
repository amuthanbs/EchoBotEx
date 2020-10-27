using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoBotEx.TransferRequests
{
    public interface ITransferRequest
    {
        string ProcessTransfer(string message);

    }
}
