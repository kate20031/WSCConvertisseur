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

        /// <summary>
        /// Get all currencies.
        /// </summary>
        /// <returns>A list of all currencies</returns>
        // GET: api/<CurrencyController>
        [HttpGet]
        [ProducesResponseType(200)]
        public IEnumerable<Models.Currency> GetAll()
        {
            return currencies;
        }


        /// <summary>
        /// Get a single currency.
        /// </summary>
        /// <param name="id">The ID of the currency</param>
        /// <returns>Http response</returns>
        /// <response code="200">When the currency is found</response>
        /// <response code="404">When the currency is not found</response>
        // GET api/<CurrencyController>/5
        [HttpGet("{id}", Name = "GetCurrency")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<Currency> GetById(int id)
        {
            Currency? currency = currencies.FirstOrDefault((d) => d.Id == id);
            if (currency == null)
            {
                return NotFound();
            }
            return currency;
        }

        /// <summary>
        /// Creating a new currency.
        /// </summary>
        /// <param name="currency">The currency to create</param>
        /// <returns>Http response</returns>
        /// <response code="201">When the currency is created</response>
        /// <response code="400">When the currency is invalid</response>
        // POST api/<CurrencyController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<Currency> Post([FromBody] Currency currency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            currencies.Add(currency);
            return CreatedAtRoute("GetCurrency", new { id = currency.Id }, currency);
        }

        /// <summary>
        /// Updating an existing currency.
        /// </summary>
        /// <param name="id">The id of the currency to update</param>
        /// <param name="currency">The updated currency</param>
        /// <returns>Http response</returns>
        /// <response code="204">When the currency is updated</response>
        /// <response code="400">When the id in URL does not match the id in the request body</response>
        /// <response code="404">When the currency is not found</response>
        // PUT api/<CurrencyController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
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

        /// <summary>
        /// Deleting an existing currency.
        /// </summary>
        /// <param name="id">The id of the currency to delete</param>
        /// <returns>The deleted currency</returns>
        /// <response code="200">When the currency is deleted</response>
        /// <response code="404">When the currency is not found</response>
        // DELETE api/<CurrencyController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
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
