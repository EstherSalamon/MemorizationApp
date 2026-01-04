using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemorizationApp.Data.Classes
{
    public class FormResponse
    {
        public ResponseStatus Status { get; set; }
        public string Message { get; set; }
    }

    public enum ResponseStatus
    {
        Success,
        Error,
    }
}
