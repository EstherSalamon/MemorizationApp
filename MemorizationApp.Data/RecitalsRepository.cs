using MemorizationApp.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemorizationApp.Data
{
    public class RecitalsRepository
    {
        private readonly string _connectionString;

        public RecitalsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Recital> getAll()
        {
            RecitalDataContext context = new RecitalDataContext(_connectionString);
            return context.Recitals.ToList();
        }

        public int addRecital(Recital recital)
        {
            RecitalDataContext context = new RecitalDataContext(_connectionString);
            context.Recitals.Add(recital);
            context.SaveChanges();
            return recital.Id;
        }

        public Recital getById(int id)
        {
            RecitalDataContext context = new RecitalDataContext(_connectionString);
            return context.Recitals.FirstOrDefault(r => r.Id == id);
        }
    }
}

// TODO: remove efcore?