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
        public GetRecitalsResponse GetAll()
        {
            return RecitalAdapter.DoGetAllRecitals(_connectionString);
        }

        [HttpPost("add")]
        public AddRecitalResponse AddRecital(AddRecitalVM vm)
        {
            return RecitalAdapter.DoAddRecital(_connectionString, vm.Recital);
        }

        [HttpGet("byid")]
        public RecitalByIdResponse GetById([FromQuery] RecitalByIdVM vm)
        {
            return RecitalAdapter.DoGetById(_connectionString, vm.RecitalId);
        }

        [HttpPost("compare")]
        public CompareTextResponse CompareText(CompareTextVM vm) 
        {
            CompareTextRequest data = new CompareTextRequest { RecitalId = vm.RecitalId, CompareText = vm.CompareText, Preferences = vm.Preferences };
            return CompareTextIntent.DoCompare(_connectionString, data);
        }
    }
}