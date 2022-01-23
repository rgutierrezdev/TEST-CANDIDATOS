using System;

namespace ConsoleApp.Problema07.Fakes
{
    public class DAOFactory
    {
        public T GetDAO<T>()
        {
            return Activator.CreateInstance<T>();
        }
    }
}
