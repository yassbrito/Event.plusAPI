using Event_.Domains;

namespace Event_.Interfaces
{
    public interface IUsuarioRepository
    {

        void Cadastrar (Usuario novousuario);  
        
        Usuario BuscarPorId (Guid id);

        Usuario BuscarPorEmailESenha (string email, string senha);


    }
}
