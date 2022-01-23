using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Problema05
{
    public interface IArchivoRepository : IDisposable
    {
        string[] leerArchivo(string _path);
    }
}
