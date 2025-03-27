using Event_.Domains;

namespace Event_.Interfaces
{
    public interface ITiposUsuariosRepository
    {
        void Cadastrar (TiposUsuarios tiposUsuarios);

        void Atualizar(Guid Id, TiposUsuarios tiposUsuarios);

        void Deletar(Guid Id);

        List<TiposUsuarios> Listar();

        TiposUsuarios BuscarPorID (Guid Id);

    }
}
