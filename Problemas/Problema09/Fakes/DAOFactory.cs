using System;

namespace ConsoleApp.Problema09
{
    public class DAOFactory
    {
        private static DAOFactory _daof;

        public static DAOFactory GetInstance()
        {
            var retval = _daof ?? new DAOFactory();
            return retval;
        }

        public T GetDAO<T>()
        {
            return Activator.CreateInstance<T>();
        }
    }
}
