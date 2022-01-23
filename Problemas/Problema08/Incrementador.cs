using System.Threading;

namespace ConsoleApp.Problema08
{
    public class Incrementador
    {
        public int Valor { get; private set; }

        public void IncrementarSoloSiValorEsCero()
        {
            IncrementarValor();
        }

        private void IncrementarValor()
        {
            Thread.Sleep(250);
            Valor++;
        }
    }
}
