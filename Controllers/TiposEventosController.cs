using Event_.Domains;
using Event_.Interfaces;
using Event_.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Event_Plus.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoEventosController : ControllerBase
    {
        private readonly ITiposEventosRepository _tipoEventosRepository;

        public TipoEventosController(ITiposEventosRepository tipoEventosRepository)
        {

            _tipoEventosRepository = tipoEventosRepository;
        }

        ////// <summary>
        /// Lista Tipo de Eventos
        /// </summary>
        /// <returns>Listar os Tipos de Eventos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<TiposEventos> tipoEventos = _tipoEventosRepository.Listar();

                return Ok(tipoEventos);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Cadastrar os Tipo Eventos
        /// </summary>
        /// <param name="novoTipoEvento">Tipo Evento cadastrado</param>
        /// <returns>Novo Tipo Evento</returns>
        [HttpPost]
        public IActionResult Post(TiposEventos novoTipoEvento)
        {

            try
            {
                _tipoEventosRepository.Cadastrar(novoTipoEvento);

                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Deletar um Tipo Evento
        /// </summary>
        /// <param name="id">Id do Tipo de Evento</param>
        /// <returns>Linha vazia</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {

            try
            {
                _tipoEventosRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Atualizar um Tipo De Evento
        /// </summary>
        /// <param name="id">Id do TipoEvento</param>
        /// /// <param name="tipoEvento">Titulo do Filme</param>
        /// <returns>Tipo Evento Atualizado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TiposEventos tipoEvento)
        {
            try
            {
                _tipoEventosRepository.Atualizar(id, tipoEvento);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Atualizar um Tipo De Evento
        /// </summary>
        /// <param name="id">Id do TipoEvento</param>
        /// <returns>Tipo Evento Buscado</returns>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                TiposEventos tipoEventosBuscado = _tipoEventosRepository.BuscarPorId(id);
                return Ok(tipoEventosBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }




}




