using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FinStats;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        public StocksController(AppDb db)
        {
            Db = db;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Db.Connection.OpenAsync();
            var query = new StocksQuery(Db);
            var result = await query.LatestStockAsync();

            return new OkObjectResult(result);
        }

        public AppDb Db { get; }
    }
}
