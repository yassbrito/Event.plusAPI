using Event_.Context;
using Event_.Domains;
using Event_.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace Event_.Repositories
{
    public class TiposEventosRepository : ITiposEventosRepository
    {

        private readonly Event_Context? _context;

        public TiposEventosRepository (Event_Context context)
        {
            _context = context;
        }


        //variavel
        //metodo construtor
        //Desenvolver os metodos que foram criados na interface
        public void Atualizar(Guid id, TiposEventos tipoEvento)
        {
            try
            {
                TiposEventos tipoBuscado = _context.TiposEventos.Find(id)!;

                if (tipoBuscado != null)
                {
                    tipoBuscado.TituloTipoEvento = tipoEvento.TituloTipoEvento;
                }

                _context.TiposEventos.Update(tipoBuscado!);

                _context.SaveChanges();
            }

            catch (Exception)
            {
                throw;
            }
        }

        public TiposEventos BuscarPorId(Guid id)
        {
            try
            {
                return _context.TiposEventos.Find(id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Cadastrar(TiposEventos tipoEvento)
        {
            try
            {
                tipoEvento.TiposEventosID = Guid.NewGuid();

                _context!.TiposEventos.Add(tipoEvento);

                _context.SaveChanges();

            }

            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid Id)
        {
            try
            {
                TiposUsuarios tipoBuscado = _context.TiposUsuarios.Find(Id)!;

                if (tipoBuscado != null)
                {
                    _context.TiposUsuarios.Remove(tipoBuscado);

                }

                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TiposEventos> Listar()
        {
            try
            {
                return _context.TiposEventos
                    .OrderBy(tp => tp.TituloTipoEvento)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
