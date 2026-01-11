using MemorizationApp.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemorizationApp.Data
{
    public class RecitalAdapter
    {
        public static GetRecitalsResponse DoGetAllRecitals(string connection)
        {
            RecitalsRepository repo = new RecitalsRepository(connection);
            List<Recital> recitals = repo.getAll();
            GetRecitalsData data = new GetRecitalsData { Recitals = recitals };
            return new GetRecitalsResponse { Status = ResponseStatus.Success, Data = data };
        }

        public static AddRecitalResponse DoAddRecital(string connection, Recital recital)
        {
            if(recital == null)
            {
                return new AddRecitalResponse { Status = ResponseStatus.Error, Message = "Recital Error" };
            }

            RecitalsRepository repo = new RecitalsRepository(connection);
            int id = repo.addRecital(recital);
            AddRecitalData data = new AddRecitalData { RecitalId = id };
            return new AddRecitalResponse { Status = ResponseStatus.Success, Data = data };
        }

        public static RecitalByIdResponse DoGetById(string connection, int id)
        {
            RecitalsRepository repo = new RecitalsRepository(connection);
            Recital recital = repo.getById(id);
            RecitalByIdData data = new RecitalByIdData { Recital = recital };
            return new RecitalByIdResponse { Status = ResponseStatus.Success, Data = data };
        }
    }
}
