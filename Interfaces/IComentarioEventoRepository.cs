using Event_.Domains;

namespace Event_.Interfaces
{
    public interface IComentarioEventoRepository
    {
        void Cadastrar(ComentarioEvento comentarioEvento);

        ComentarioEvento BuscarPorIdDoUsuario(Guid UsuarioID, Guid EventoID);

        List<ComentarioEvento> Listar(Guid Id);

        void Deletar (Guid IdComentario);

    }
}
