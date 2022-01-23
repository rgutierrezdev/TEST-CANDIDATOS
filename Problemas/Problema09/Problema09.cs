namespace ConsoleApp.Problema09
{
    public class Problema09
    {
        private Servidor _servidor;
        private Aplicacion _aplicacion;

        public string ObtenerConfiguracion(string codigoAplicacion, string parametro, DAOFactory daof)
        {
            string resultado;

            if (_aplicacion == null)
            {
                _aplicacion = daof.GetDAO<AplicacionDAO>().ObtenerPorCodigo(codigoAplicacion);
                resultado = ObtenerConfiguracion(codigoAplicacion, parametro, daof);
            }
            else
            {
                bool parametroNivelAplicacion = _aplicacion.Parametros.TryGetValue(parametro, out resultado);
                if (!parametroNivelAplicacion)
                {
                    if (_servidor == null)
                    {
                        _servidor = daof.GetDAO<ServidorDAO>().ObtenerPorAplicacion(_aplicacion);
                        resultado = ObtenerConfiguracion(codigoAplicacion, parametro, daof);
                    }
                    else
                    {
                        bool parametroNivelServidor = _servidor.Parametros.TryGetValue(parametro, out resultado);
                        if (!parametroNivelServidor)
                        {
                            resultado = daof.GetDAO<DominioDAO>().ObtenerParametro(parametro);
                        }
                    }
                }
            }

            return resultado;
        }
    }
}
