using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp.Problema08
{
    public class Problema08
    {
        public void Ejecutar()
        {
            var incrementador = new Incrementador();
            var tasks = new Task[10];

            for (int i = 0; i < tasks.Count(); i++)
            {
                tasks[i] = new Task(delegate ()
                {
                    incrementador.IncrementarSoloSiValorEsCero();
                });

                tasks[i].Start();
            }

            Task.WaitAll(tasks);

            System.Diagnostics.Debug.WriteLine($"El valor debe ser 1 y es: {incrementador.Valor}");
        }
    }
}
