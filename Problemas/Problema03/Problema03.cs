using ConsoleApp.Problema03.Fakes;

namespace ConsoleApp.Problema03
{
    public class Problema03
    {
        public void CrearUsuario(Usuario usuario, DAOFactory daof)
        {                        
            if(daof.GetDAO<UsuarioDAO>().FindUnique(usuario) == null)
            {
                usuario.Password = HashUtil.MD5(usuario.Password);
                daof.GetDAO<UsuarioDAO>().Save(usuario);
            }                        
        }
    }
}
