namespace ConsoleApp.Problema04
{
    public class Operacion : BaseOperacion
    {
        public decimal Sumar(decimal valor1, decimal valor2)
        {
            return ObtenerValorFinal(valor1 + valor2);            
        }
        public decimal Restar(decimal valor1, decimal valor2)
        {
            return ObtenerValorFinal(valor1 - valor2);
        }        
        public decimal Multiplicar(decimal valor1, decimal valor2)
        {
            return ObtenerValorFinal(valor1 * valor2);
        }
        public decimal Dividir(decimal valor1, decimal valor2)
        {
            return ObtenerValorFinal(valor1 / valor2);
        }
    }
}
