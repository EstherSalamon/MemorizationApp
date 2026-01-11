using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemorizationApp.Data.Classes
{
    public class GetRecitalsData
    {
        public List<Recital> Recitals { get; set; }
    }

    public class GetRecitalsResponse: FormResponse
    {
        public GetRecitalsData Data { get; set; }
    }
}
