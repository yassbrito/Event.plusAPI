using Event_.Context;
using Event_.Domains;
using Event_.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Event_.Repositories
{
    public class PresencasEventosRepository : IPresencasEventosRepository
    {
        private readonly Event_Context? _context;

        public PresencasEventosRepository(Event_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid Id, PresencasEventos presencasEventos)
        {
            try
            {
                PresencasEventos presencaEventoBuscado = _context.PresencasEventos.Find(Id)!;

                if (presencaEventoBuscado != null)
                {
                    if (presencaEventoBuscado.Situacao)
                    {
                        presencaEventoBuscado.Situacao = false;
                    }
                    else
                    {
                        presencaEventoBuscado.Situacao = true;
                    }

                }

                _context.PresencasEventos.Update(presencaEventoBuscado!);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
           
        

        public PresencasEventos BuscarPorId(Guid Id)
        {
            try
            {
                return _context.PresencasEventos
                    .Select(p => new PresencasEventos
                    {
                        PresencasEventoID = p.PresencasEventoID,
                        Situacao = p.Situacao,

                        eventos = new Evento
                        {
                            EventoID = p.EventoID!,
                            DataEvento = p.eventos!.DataEvento,
                            NomeEvento = p.eventos.NomeEvento,
                            Descricao = p.eventos.Descricao,

                            instituicao = new Instituicoes
                            {
                                InstituicoesID = p.eventos.instituicao!.InstituicoesID,
                                NomeFantasia = p.eventos.instituicao!.NomeFantasia
                            }
                        }

                    }).FirstOrDefault(p => p.PresencasEventoID == Id)!;
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
                PresencasEventos presencasEventos = _context?.PresencasEventos.Find(Id)!;
                if (presencasEventos != null)
                {
                    _context?.PresencasEventos.Remove(presencasEventos);
                }
                _context?.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Inscrever(PresencasEventos inscricao)
        {
            try
            {

                inscricao.PresencasEventoID = Guid.NewGuid();

                _context.PresencasEventos.Add(inscricao);

                _context.SaveChanges();

            }
            catch
            {

            }
        }

        public List<PresencasEventos> Listar()
        {
            try
            {
                return _context!.PresencasEventos
                    .Select(p => new PresencasEventos
                    {
                        PresencasEventoID = p.PresencasEventoID,
                        Situacao = p.Situacao,

                        eventos = new Evento
                        {
                            EventoID = p.EventoID,
                            DataEvento = p.eventos!.DataEvento,
                            NomeEvento = p.eventos.NomeEvento,
                            Descricao = p.eventos.Descricao,

                            instituicao = new Instituicoes
                            {
                                InstituicoesID = p.eventos.instituicao!.InstituicoesID,
                                NomeFantasia = p.eventos.instituicao!.NomeFantasia
                            }
                        }

                    }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PresencasEventos> ListarMinhas(Guid Id)
        {
            return _context!.PresencasEventos
                .Select(p => new PresencasEventos
                {
                    PresencasEventoID = p.PresencasEventoID,
                    Situacao = p.Situacao,
                    UsuarioID = p.UsuarioID,
                    EventoID = p.EventoID,

                    eventos = new Evento
                    {
                        EventoID = p.EventoID,
                        DataEvento = p.eventos!.DataEvento,
                        NomeEvento = p.eventos!.NomeEvento,
                        Descricao = p.eventos!.Descricao,

                        instituicao = new Instituicoes
                        {
                            InstituicoesID = p.eventos.InstituicoesID,
                        }

                    }
                })

                .Where(p => p.UsuarioID == Id)
                .ToList();

        }
    }
}
