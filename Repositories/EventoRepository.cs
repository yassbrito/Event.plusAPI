using Event_.Context;
using Event_.Domains;
using Event_.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Event_.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly Event_Context? _context;

        public EventoRepository(Event_Context context)
        {
            _context = context;
        }
        public void Atualizar(Guid Id, Evento evento)
        {

            try
            {
                Evento EventoBuscado = _context?.Evento.Find(Id)!;

                if (EventoBuscado != null)
                {
                    EventoBuscado.NomeEvento = evento.NomeEvento;

                    EventoBuscado.TiposEventosID = evento.TiposEventosID;

                    EventoBuscado.Descricao  = evento.Descricao;

                    EventoBuscado.DataEvento = evento.DataEvento;
                }
                _context!.Evento.Update(EventoBuscado!);
                _context?.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Evento BuscarPorID(Guid Id)
        {
            return _context!.Evento
                    .Select(e => new Evento
                    {
                        EventoID = e.EventoID,
                        NomeEvento = e.NomeEvento,
                        Descricao = e.Descricao,
                        DataEvento = e.DataEvento,
                        TipoEvento = new TiposEventos
                        {
                            TituloTipoEvento = e.TipoEvento!.TituloTipoEvento
                        },
                        instituicao = new Instituicoes
                        {
                            NomeFantasia = e.instituicao!.NomeFantasia
                        }
                    }).FirstOrDefault(e => e.EventoID == Id)!;
        }

        public void Cadastrar(Evento novoEvento)
        {
            try
            {
                // Verifica se a data do evento é maior que a data atual
                if (novoEvento.DataEvento < DateTime.Now)
                {
                    throw new ArgumentException("A data do evento deve ser maior ou igual a data atual.");
                }

                novoEvento.EventoID = Guid.NewGuid();

                _context?.Evento.Add(novoEvento);

                _context?.SaveChanges();
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
                Evento eventoBuscado = _context!.Evento.Find(Id)!;

                if (eventoBuscado != null)
                {
                    _context.Evento.Remove(eventoBuscado);


                }


               _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Evento> Listar()
        {
            try
            {
                return _context!.Evento
                    .Select(e => new Evento
                    {
                        EventoID = e.EventoID,
                        NomeEvento = e.NomeEvento,
                        Descricao = e.Descricao,
                        DataEvento = e.DataEvento,
                        TiposEventosID = e.TiposEventosID,
                        TipoEvento = new TiposEventos
                        {
                            TiposEventosID = e.TiposEventosID,
                            TituloTipoEvento = e.TipoEvento!.TituloTipoEvento
                        },
                        InstituicoesID = e.InstituicoesID,
                        instituicao = new Instituicoes
                        {
                            InstituicoesID = e.InstituicoesID,
                            NomeFantasia = e.instituicao!.NomeFantasia
                        }
                    }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Evento> ListarPorID(Guid Id)
        {
            try
            {
                return _context.Evento
                    .Include(e => e.TiposEventosID)
                    .Select(e => new Evento
                    {
                        EventoID = e.EventoID,
                        NomeEvento = e.NomeEvento,
                        Descricao = e.Descricao,
                        DataEvento = e.DataEvento,
                        //TipoEvento = e.TipoEvento,
                        TipoEvento = new TiposEventos
                        {
                            TiposEventosID = e.TiposEventosID,
                            TituloTipoEvento = e.TipoEvento!.TituloTipoEvento
                        },
                        InstituicoesID = e.InstituicoesID,
                        instituicao = new Instituicoes
                        {
                            InstituicoesID = e.InstituicoesID,
                            NomeFantasia = e.instituicao!.NomeFantasia
                        },
                        PresencasEventos = new PresencasEventos
                        {
                            UsuarioID = e.PresencasEventos!.UsuarioID,
                            Situacao = e.PresencasEventos!.Situacao
                        }
                    })
                    .Where(e => e.PresencasEventos!.Situacao == true && e.PresencasEventos.UsuarioID == Id)
                    .ToList();
            }
            catch (Exception)
            {

                throw;

            }

        }

        public List<Evento> ListarProximoEvento()
        {
            try
            {
                return _context!.Evento
                    .Select(e => new Evento
                    {
                        EventoID = e.EventoID,
                        NomeEvento = e.NomeEvento,
                        Descricao = e.Descricao,
                        DataEvento = e.DataEvento,
                        TiposEventosID = e.TiposEventosID,
                        TipoEvento = new TiposEventos
                        {
                            TiposEventosID = e.TiposEventosID,
                            TituloTipoEvento = e.TipoEvento!.TituloTipoEvento
                        },
                        InstituicoesID = e.InstituicoesID,
                        instituicao = new Instituicoes
                        {
                            InstituicoesID = e.InstituicoesID,
                            NomeFantasia = e.instituicao!.NomeFantasia
                        }

                    })
                    .Where(e => e.DataEvento >= DateTime.Now)
                    .ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
