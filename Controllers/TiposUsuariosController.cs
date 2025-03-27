using Event_.Domains;
using Event_.Interfaces;
using Event_.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TiposUsuariosController : ControllerBase
    {
        private readonly ITiposUsuariosRepository _tiposUsuariosRepository;

        public TiposUsuariosController(ITiposUsuariosRepository tiposUsuariosRepository)
        {
            _tiposUsuariosRepository = tiposUsuariosRepository;
        }

        [HttpPut]
        public IActionResult Put( Guid Id, TiposUsuarios tiposUsuarios)
        {
            try
            {
                _tiposUsuariosRepository.Atualizar(Id, tiposUsuarios);
                return NoContent();

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("BuscarPorId/{Id}")]
        public IActionResult GetById(Guid Id)
        {
            try
            {

                TiposUsuarios usuarioBuscado = _tiposUsuariosRepository.BuscarPorID(Id);

               return Ok(usuarioBuscado);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(TiposUsuarios novoTipoUsuario)
        {
            try
            {
                _tiposUsuariosRepository.Cadastrar(novoTipoUsuario);

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
                _tiposUsuariosRepository.Deletar(Id);
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
                List<TiposUsuarios> ListaTipoUsuario = _tiposUsuariosRepository.Listar();
                return Ok(ListaTipoUsuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
