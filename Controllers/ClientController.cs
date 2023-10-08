using EAD_Ticket_Reservation_system.Models;
using EAD_Ticket_Reservation_system.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EAD_Ticket_Reservation_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly Client _client;
        public ClientController(Client clientService)
        {
            this._client = clientService;
        }
        // GET: api/<ClientController>
        [HttpGet]
        public ActionResult<List<ClientModel>> Get()
        {
            return _client.Get();
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public ActionResult<ClientModel> Get(string id)
        {
           var client = _client.Get(id);

            if (client == null) 
            {
                return NotFound($"Client with Id = {id} not found");
            }

            return client;
        }

        // POST api/<ClientController>
        [HttpPost]
        public ActionResult<ClientModel> Post([FromBody] ClientModel client)
        {
            _client.Create(client);

            return CreatedAtAction(nameof(Get), new { id = client.Id }, client);
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] ClientModel client)
        {
            var existingClient = _client.Get(id);

            if(existingClient == null)
            {
                return NotFound($"Client with Id = {id} not found");
            }

            _client.Update(id, client);
            return NoContent();
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var client = _client.Get(id);

            if(client == null)
            {
                return NotFound($"Client with Id = {id} not found");
            }

            _client.Delete(id);

            return Ok($"Student with Id = {id} deleted");
        }
    }
}
