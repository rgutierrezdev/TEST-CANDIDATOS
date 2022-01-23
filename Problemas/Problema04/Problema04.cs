namespace ConsoleApp.Problema04
{
    public class Problema04
    {
        public decimal EjecutarOperacion(OPERADORES tipoOperacion, decimal valor1, decimal valor2)
        {
            decimal resultado = 0;
            Operacion operacion = new Operacion();

            switch (tipoOperacion)
            {
                case OPERADORES.SUMA:
                {                    
                    resultado = operacion.Sumar(valor1, valor2);
                    break;
                }
                case OPERADORES.RESTA:
                {                    
                    resultado = operacion.Restar(valor1, valor2);
                    break;
                }
                case OPERADORES.MULTIPLICACION:
                {                    
                    resultado = operacion.Multiplicar(valor1, valor2);
                    break;
                }
                case OPERADORES.DIVIDIR:
                {                    
                    resultado = operacion.Dividir(valor1, valor2);
                    break;
                }
            }

            return resultado;
        }
    }

    public enum OPERADORES
    {
        SUMA = 1,
        RESTA = 2,
        MULTIPLICACION = 3,
        DIVIDIR = 4
    }
}
