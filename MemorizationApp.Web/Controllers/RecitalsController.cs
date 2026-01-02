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
        public AddRecitalResponse AddRecital(Recital recital)
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
        public CompareTextResponse CheckLogic(CompareTextVM vm) 
        {
            var data = new CompareTextRequest { RecitalId = vm.RecitalId, CompareText = vm.CompareText };
            return CompareText.DoCompare(data, _connectionString);
        }
    }
}
//TODO: all apis should send in object
// and returntype { status: success; data: any } | { status: error; messages: [] }