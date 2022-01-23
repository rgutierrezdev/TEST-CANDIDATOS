using System;

namespace ConsoleApp.Problema02.Fakes
{
    public class DAOFactory
    {
        public T GetDAO<T>()
        {
            return Activator.CreateInstance<T>();
        }
    }
}
