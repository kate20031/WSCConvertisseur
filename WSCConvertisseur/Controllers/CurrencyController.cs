using Microsoft.AspNetCore.Mvc;
using WSCConvertisseur.Models;

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
        [HttpGet("{id}", Name = "GetCurrency")]
        public ActionResult<Currency> GetById(int id)
        {
            Currency? currency = currencies.FirstOrDefault((d) => d.Id == id);
            if (currency == null)
            {
                return NotFound();
            }
            return currency;
        }

        // POST api/<CurrencyController>
        [HttpPost]
        public ActionResult<Currency> Post([FromBody] Currency currency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            currencies.Add(currency);
            return CreatedAtRoute("GetCurrency", new { id = currency.Id }, currency);
        }

        // PUT api/<CurrencyController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Currency currency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != currency.Id)
            {
                return BadRequest();
            }

            int index = currencies.FindIndex((d) => d.Id == id);
            
            if (index < 0)
            {
                return NotFound();
            }

            currencies[index] = currency;
            return NoContent();
        }

        // DELETE api/<CurrencyController>/5
        [HttpDelete("{id}")]
        public ActionResult<Currency> Delete(int id)
        {
            Currency? currency = currencies.FirstOrDefault((d) => d.Id == id);
            if (currency == null)
            {
                return NotFound();
            }
            currencies.Remove(currency);

            return currency;

        }
    }
}
