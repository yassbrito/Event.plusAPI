using Event_.Context;
using Event_.Domains;
using Event_.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Event_.Repositories
{
    public class ComentarioEventoRepository : IComentarioEventoRepository
    {
        private readonly Event_Context? _context;

        public ComentarioEventoRepository(Event_Context context)
        {
            _context = context;
        }

        public ComentarioEvento BuscarPorIdDoUsuario(Guid UsuarioID, Guid EventoID)
        {
            try
            {
                return _context.ComentarioEvento
                    .Select(c => new ComentarioEvento
                    {
                        ComentarioEventoID = c.ComentarioEventoID,
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        UsuarioID = c.UsuarioID,
                        EventoID = c.EventoID,

                        usuario = new Usuario
                        {
                            NomeUsuario = c.usuario!.NomeUsuario
                        },

                        evento = new Evento
                        {
                            NomeEvento = c.evento!.NomeEvento,
                        }

                    }).FirstOrDefault(c => c.UsuarioID == UsuarioID && c.EventoID == EventoID)!;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            try
            {
                comentarioEvento.ComentarioEventoID = Guid.NewGuid();

                _context.ComentarioEvento.Add(comentarioEvento);

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid ComentarioEventoID)
        {
            try
            {
                ComentarioEvento comentarioEventoBuscado = _context.ComentarioEvento.Find(ComentarioEventoID)!;

                if (comentarioEventoBuscado != null)
                {
                    _context.ComentarioEvento.Remove(comentarioEventoBuscado);
                }


                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ComentarioEvento> Listar(Guid id)
        {
            try
            {
                return _context.ComentarioEvento
                    .Select(c => new ComentarioEvento
                    {
                        ComentarioEventoID = c.ComentarioEventoID,
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        UsuarioID = c.UsuarioID,
                        EventoID = c.EventoID,

                        usuario = new Usuario
                        {
                            NomeUsuario = c.usuario!.NomeUsuario
                        },

                        evento = new Evento
                        {
                            NomeEvento = c.evento!.NomeEvento,
                        }

                    }).Where(c => c.EventoID == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }
    


    }
}
