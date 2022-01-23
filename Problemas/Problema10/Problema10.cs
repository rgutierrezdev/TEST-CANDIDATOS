using System;
using ConsoleApp.Problema10.Fakes;

namespace ConsoleApp.Problema10
{
    public class Problema10
    {
        private static Proceso _emision;
        private static Proceso _cancelacion;
        private static Proceso _endoso;
        private static Proceso _renovacion;

        public static T GetProceso<T>() where T : Proceso
        {
            Proceso proceso = AsignarProceso(null, typeof(T));

            if (proceso != null)
                return (T)proceso;

            proceso = (T)Activator.CreateInstance(typeof(T));
            AsignarProceso(proceso, null);

            return (T)proceso;
        }

#if DEBUG
        public static void SetProceso<T>(T proceso) where T : Proceso
        {
            _ = AsignarProceso(proceso, null);
        }
#endif

        private static Proceso AsignarProceso(Proceso proceso, Type type)
        { 
            var localType = proceso != null ? proceso.GetType() : type;

            if (localType == typeof(Emision))
            {
                if (proceso == null)
                    proceso = _emision;
                else
                    _emision = proceso;
            }

            if (localType == typeof(Cancelacion))
            {
                if (proceso == null)
                    proceso = _cancelacion;
                else
                    _cancelacion = proceso;
            }

            if (localType == typeof(Endoso))
            {
                if (proceso == null)
                    proceso = _endoso;
                else
                    _endoso = proceso;
            }

            if (localType == typeof(Renovacion))
            {
                if (proceso == null)
                    proceso = _renovacion;
                else
                    _renovacion = proceso;
            }

            return proceso;
        }
    }
}
