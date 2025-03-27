using Event_.Domains;
using Event_.Interfaces;
using Event_.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentarioEventoController : ControllerBase
    {
        private readonly IComentarioEventoRepository _ComentarioEventoRepository;

        public ComentarioEventoController(IComentarioEventoRepository comentarioEventoRepository)
        {
            _ComentarioEventoRepository = comentarioEventoRepository;
        }

        [HttpGet("BuscarPorIdDoUsuario/{UsuarioID},{EventoID}")]
        public IActionResult GetById(Guid UsuarioID, Guid EventoID)
        {
            try
            {
               ComentarioEvento comentarioBuscado = _ComentarioEventoRepository.BuscarPorIdDoUsuario(UsuarioID, EventoID);
                return Ok(comentarioBuscado);


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public IActionResult Post(ComentarioEvento comentarioEvento)
        {

            try
            {
                _ComentarioEventoRepository.Cadastrar(comentarioEvento);
                return Created();
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
                _ComentarioEventoRepository.Deletar(Id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get(Guid Id)
        {
            try
            {
                List<ComentarioEvento> ListarComentarioEvento = _ComentarioEventoRepository.Listar(Id);
                return Ok(ListarComentarioEvento);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
