using System.Diagnostics.Eventing.Reader;
using Event_.Domains;
using Event_.Interfaces;
using Event_.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoRepository _EventosRepository;

        public EventoController(IEventoRepository EventosRepository)
        {
            _EventosRepository = EventosRepository;
        }

        [HttpPost]
        public IActionResult Post( Evento eventoRepository)
        {
            try
            {
                _EventosRepository.Cadastrar(eventoRepository);
                return Created();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public IActionResult Put(Guid Id, Evento evento)
        {
            try
            {
                _EventosRepository.Atualizar(Id, evento);
                return NoContent();

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        } 

        [HttpGet("{Id}")]
        public IActionResult GetById(Guid Id)
        {
            try
            {
                Evento EventoBuscado = _EventosRepository.BuscarPorID(Id);
                return Ok(EventoBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

      

        [HttpDelete]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                _EventosRepository.Deletar(Id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Evento> ListaEvento = _EventosRepository.Listar();
                return Ok(ListaEvento);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{ListarId}")]
        public IActionResult Get(Guid Id)
        {
            try
            {
                List<Evento> ListaEventoPorID = _EventosRepository.ListarPorID(Id);
                return Ok(ListaEventoPorID);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{ListarProximoEvento}")]
        public IActionResult ListarProximoEvento()
        {
            try
            {
                List<Evento> ListaProximoEvento = _EventosRepository.ListarProximoEvento();
                return Ok(ListaProximoEvento);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
