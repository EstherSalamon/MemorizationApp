using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemorizationApp.Data.Classes
{
    public class RecitalByIdData
    {
        public Recital Recital { get; set; }
    }

    public class RecitalByIdResponse: FormResponse
    {
        public RecitalByIdData Data { get; set; }
    }
}
