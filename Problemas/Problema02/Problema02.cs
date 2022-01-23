using ConsoleApp.Problema02.Fakes;

namespace ConsoleApp.Problema02
{
    public class Problema02
    {
        public void BorrarSiniestro(int id, DAOFactory daof)
        {
            daof.GetDAO<SiniestroDAO>().DeleteById(id);
        }
    }
}
