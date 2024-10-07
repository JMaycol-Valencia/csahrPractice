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
            WriteLine(engine.EscuelaA);
            Printer.Pitar();
            ImprimirCursosEscuelas(engine.EscuelaA);

        }
        private static void ImprimirCursosEscuelas(Escuela? escuela)
        {

            Printer.DibujarLinea(escuela.Nombre.Length + 4 );
            Printer.WriteTittle($"| {escuela.Nombre} |");

            if(escuela?.Cursos != null){
                foreach(var curso in escuela.Cursos){
                    Printer.WriteTittle($"Name: {curso.Name}, ID: {curso.UniqueId}");
                }
            }
        }
    }
}

