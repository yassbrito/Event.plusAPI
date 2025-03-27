using Event_.Context;
using Event_.Domains;
using Event_.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace webapi.event_.Repositories
{
    public class UsuariosRepository : IUsuarioRepository
    {
        private readonly Event_Context _context;

        public UsuariosRepository(Event_Context context)
        {
            _context = context;
        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _context.Usuario
                    .Select(u => new Usuario
                    {
                        UsuarioID = u.UsuarioID,
                        NomeUsuario = u.NomeUsuario,
                        Email = u.Email,
                        Senha = u.Senha,

                        TipoUsuario = new TiposUsuarios
                        {
                            TiposUsuariosID = u.TipoUsuarioID,
                            TituloTipoUsuario = u.TipoUsuario!.TituloTipoUsuario
                        }
                    }).FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    //bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    //if (confere)
                    //{
                    //    return usuarioBuscado!;
                    //}
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }
    

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _context.Usuario
                    .Select(u => new Usuario
                    {
                        UsuarioID = u.UsuarioID,
                        NomeUsuario = u.NomeUsuario,
                        Email = u.Email,
                        Senha = u.Senha,

                        TipoUsuario = new TiposUsuarios
                        {
                            TiposUsuariosID = u.TipoUsuario!.TiposUsuariosID,
                            TituloTipoUsuario = u.TipoUsuario!.TituloTipoUsuario
                        }

                    }).FirstOrDefault(u => u.UsuarioID == id)!;

                if (usuarioBuscado != null)
                {
                    return usuarioBuscado;

                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {

            try
            {
                usuario.UsuarioID = Guid.NewGuid();

                //usuario.Senha = Criptografia.GerarHash(usuario.Senha!);


                _context.Usuario.Add(usuario);


                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }


}