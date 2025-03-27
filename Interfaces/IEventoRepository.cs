using Event_.Domains;

namespace Event_.Interfaces
{
    public interface IEventoRepository
    {
        void  Cadastrar (Evento novoEvento);

        List<Evento> Listar();

        void Atualizar (Guid Id, Evento evento);

        void Deletar (Guid Id);

        Evento BuscarPorID (Guid Id);

        List<Evento> ListarProximoEvento();

        List<Evento>ListarPorID(Guid Id);

    }
}
