namespace ConsoleApp.Problema05
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public UsuarioRepository()
        {
            System.Diagnostics.Debug.WriteLine("Se creó un UsuarioRepository y se conectó a la DB.");
        }

        public Usuario Save(Usuario usuario)
        {
            System.Diagnostics.Debug.WriteLine("Llamada a UsuarioRepository.Save()");
            return usuario;
        }
    }
}