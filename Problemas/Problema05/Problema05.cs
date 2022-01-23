using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace ConsoleApp.Problema05
{
    public class Problema05
    {
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly IArchivoRepository _archivoRepo;

        public Problema05(IUsuarioRepository usuarioRepo, IArchivoRepository archivoRepo)
        {
            _usuarioRepo = usuarioRepo;
            _archivoRepo = archivoRepo;
        }
        public List<Usuario> GenerarUsuariosDesdeArchivo(string rutaArchivo)
        {
            List<Usuario> usuarios = new List<Usuario>();
            var lineas = _archivoRepo.leerArchivo(rutaArchivo);

            foreach(var linea in lineas)
            {
                usuarios.Add(
                    CrearUsuario(new Usuario
                    {
                        Nombre = linea.Substring(0, 50).Trim(),
                        Apellido = linea.Substring(50, 50).Trim(),
                        FechaNacimiento = DateTime.ParseExact(linea.Substring(100, 8), "yyyyMMdd", CultureInfo.InvariantCulture)
                    }));
            }

            return usuarios;
        }

        public Usuario CrearUsuario(Usuario user)
        {
            try
            {
                _usuarioRepo.Save(user);
                user.Creado = true;
            }
            catch(Exception e)
            {
                user.Creado = false;
                user.Detalle = e.Message;
            }
           
            return user;
        }
    }
}
