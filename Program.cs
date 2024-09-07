using System;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;


namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Hello World!");

            var engine =  new EscuelaEngine();
            engine.inicializar();

            //LLAMADAS POR CONSOLA
            WriteLine("ESCUELAS");
            Printer.DibujarLinea();
            WriteLine(engine.Escuela);
            ImprimirCursosEscuelas(engine.Escuela);

        }
        private static void ImprimirCursosEscuelas(Escuela ?escuela)
        {
            Printer.DibujarLinea();
            WriteLine("CURSOS DE ESCUELA");
            Printer.DibujarLinea();

            if(escuela?.Cursos != null){
                foreach(var curso in escuela.Cursos){
                    WriteLine($"Name: {curso.Name}, ID: {curso.UniqueId}");
                }
            }
        }
    }
}

