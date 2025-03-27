using Event_.Domains;
using Event_.Interfaces;
using Event_.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class PresencasEventosController : ControllerBase
    {
        private readonly IPresencasEventosRepository _presencasEventosRepository;

        public PresencasEventosController (IPresencasEventosRepository presencasEventosRepository)
        {
            _presencasEventosRepository = presencasEventosRepository;
        }

        [HttpPut]

        public IActionResult Put(Guid Id, PresencasEventos presencas)
        {
            try
            {
                _presencasEventosRepository.Atualizar(Id, presencas);
               return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                _presencasEventosRepository.Deletar(Id);
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
                List<PresencasEventos> ListaPresencasEventos = _presencasEventosRepository.Listar();
                return Ok(ListaPresencasEventos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{Id}")]
        public IActionResult Get(Guid Id)
        {
            try
            {
                List<PresencasEventos> ListaMinhas = _presencasEventosRepository.ListarMinhas(Id);
                return Ok(ListaMinhas);
            }
            catch (Exception)
            {
                throw;

            }
        }

            [HttpGet("BuscarPorId/{id}")]
            public IActionResult GetById(Guid id)
            {

                try
                {
                    PresencasEventos novaPresenca = _presencasEventosRepository.BuscarPorId(id);
                    return Ok(novaPresenca);
                }
                catch (Exception error)
                {
                    return BadRequest(error.Message);
                }
            }

        [HttpPost]
            public IActionResult Post(PresencasEventos presencasEventos)
            {
            try
            {
                _presencasEventosRepository.Inscrever(presencasEventos);
                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            }

        [HttpGet("ListarMinhas/{id}")]
        public IActionResult GetBeMy(Guid id)
        {
            try
            {
                return Ok(_presencasEventosRepository.ListarMinhas(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        }

    }


