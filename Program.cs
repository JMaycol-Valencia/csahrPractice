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
            Printer.DrawLine();
            WriteLine(engine.EscuelaA);
            //Printer.Pitar();
            ImprimirCursosEscuelas(engine.EscuelaA);
            var listaObjetos = engine.GetObjetoEscuela();
            //RRECORRIENDO LA LISTA DE OBJETOS PARA MOSTRARLA
            // foreach (var item in listaObjetos)
            // {
            //     WriteLine(item.ToString());
            // }
            
            var listaLugar = from obj in listaObjetos
                            where obj is ILugar
                            select (ILugar) obj;

        }
        private static void ImprimirCursosEscuelas(Escuela escuela)
        {

            if(escuela == null){
                return;
            }

            Printer.DrawLine(escuela.Nombre.Length + 4 );
            Printer.WriteTittle($"| {escuela.Nombre} |");

            if(escuela?.Cursos != null){
                foreach(var curso in escuela.Cursos){
                    Printer.WriteTittle($"Name: {curso.Nombre}, ID: {curso.UniqueId}");
                }
            }
        }
    }
}

