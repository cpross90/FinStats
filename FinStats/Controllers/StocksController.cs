using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using FinStats.Data;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        readonly AppDb Db;
        public StocksController(AppDb db)
        {
            Db = db;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Db.Connection.OpenAsync();

            var result = await StocksQuery.LatestAsync(Db);

            await Db.Connection.CloseAsync();

            return new OkObjectResult(result);
        }
    }
}
