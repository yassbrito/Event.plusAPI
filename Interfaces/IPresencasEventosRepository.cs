using Event_.Domains;

namespace Event_.Interfaces
{
    public interface IPresencasEventosRepository
    {
        void Inscrever (PresencasEventos inscricao);

        void Deletar (Guid Id);
        void Atualizar(Guid Id, PresencasEventos presencasEventos);

        List<PresencasEventos> Listar();

        List<PresencasEventos>ListarMinhas (Guid Id);
        PresencasEventos BuscarPorId (Guid Id);


    }
}
