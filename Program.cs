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
            int dummy = 0;
            var listaObjetos2 = engine.GetObjetoEscuela(out int conteoAlumnos, out int conteoAsignaturas , out int conteoCursos, out int conteoEvaluaciones);
            var listaObjetos3 = engine.GetObjetoEscuela();

            //engine.EscuelaA.limpiarLugar();

            //MANEJO DE LINQ PARA OBTENER LOS OBTEJOS PARTICULARES DE LA LISTAOBJETOS
            // var listaLugar = from obj in listaObjetos
            //                 where obj is ILugar
            //                 select (ILugar) obj;

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

