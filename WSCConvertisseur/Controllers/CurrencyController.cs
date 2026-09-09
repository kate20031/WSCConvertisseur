using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WSCConvertisseur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {

        
        private List<Models.Currency> currencies;
        public CurrencyController() {
            currencies = new List<Models.Currency>();
            currencies.Add(new Models.Currency(1, "Dollar", 1.08));
            currencies.Add(new Models.Currency(2, "Swiss Franc", 1.07));
            currencies.Add(new Models.Currency(3, "Yen", 120));
        }

        // GET: api/<CurrencyController>
        [HttpGet]
        public IEnumerable<Models.Currency> GetAll()
        {
            return currencies;
        }

        // GET api/<CurrencyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CurrencyController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CurrencyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CurrencyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
