using MemorizationApp.Data;
using MemorizationApp.Data.Classes;
using MemorizationApp.Web.ApiTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MemorizationApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecitalsController : ControllerBase
    {
        private readonly string _connectionString;

        public RecitalsController(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("ConStr");
        }

        [HttpGet("all")]
        public List<Recital> GetAll()
        {
            RecitalsRepository repo = new RecitalsRepository(_connectionString);
            return repo.getAll();
        }

        [HttpPost("add")]
        public AddRecitalResponse AddRecital(Recital recital) //make them take in obj and return obj, not this
        {
            RecitalsRepository repo = new RecitalsRepository(_connectionString);
            int id = repo.addRecital(recital);
            return new AddRecitalResponse { RecitalId = id };
        }

        [HttpGet("byid")]
        public Recital GetById(int id)
        {
            RecitalsRepository repo = new RecitalsRepository(_connectionString);
            return repo.getById(id);
        }

        [HttpPost("test/knowledge")]
        public CheckTextResponse CheckLogic(CheckTextVM vm) 
        {
            var data = new CheckTextRequest { RecitalId = vm.Id, RecitalText = vm.Text };
            return CompareText.DoCompare(data, _connectionString);
        }
    }
}
