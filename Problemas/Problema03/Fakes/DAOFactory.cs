using System;

namespace ConsoleApp.Problema03.Fakes
{
    public class DAOFactory
    {
        public T GetDAO<T>()
        {
            return Activator.CreateInstance<T>();
        }
    }
}
