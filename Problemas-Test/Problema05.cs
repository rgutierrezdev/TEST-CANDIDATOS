using ConsoleApp.Problema05;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Problemas_Test
{
    public class Problema05_Test
    {
        private Problema05 problema05;
        private readonly IUsuarioRepository usuarioRepo = Substitute.For<IUsuarioRepository>();
        private readonly IArchivoRepository archivoRepo = Substitute.For<IArchivoRepository>();

        [SetUp]
        public void Setup()
        {
            problema05 = new Problema05(usuarioRepo, archivoRepo);
        }

        [Test]
        public void CrearUsuariosArchivoTest()
        {
            string pathArchivo = "TEST";
            string[] resultadoArchivo = { "Rodrigo".PadRight(50)+"Gutierrez".PadRight(50)+"19941031"
                                        , "Rodrigo 2".PadRight(50)+"Gutierrez".PadRight(50)+"19941031"
                                        , "Rodrigo 3".PadRight(50)+"Gutierrez".PadRight(50)+"19941031" };

            archivoRepo.leerArchivo(pathArchivo).Returns(resultadoArchivo);
            var resultado = problema05.GenerarUsuariosDesdeArchivo(pathArchivo);


            Assert.True(resultado.TrueForAll(r => r.Creado));
        }
        [Test]
        public void CrearUsuariosTest()
        {
            Usuario user = new Usuario
            {
                Nombre = "Rodrigo",
                Apellido = "Gutierrez",
                FechaNacimiento = new DateTime(1994, 10, 31)
            };

            usuarioRepo.Save(user).Returns(user);
            var result = problema05.CrearUsuario(user);

            Assert.True(result.Creado);
        }
    }
}