using System;
using CoreEscuela.App;
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
            
            //DELEGADOS
            AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;
            //EVENTO DECLARADO CON ARROW FUNCTION
            AppDomain.CurrentDomain.ProcessExit += (obj, s)=> Printer.WriteTittle("Firma");
            

            var engine =  new EscuelaEngine();
            engine.inicializar();
            Printer.WriteTittle("BIENVENIDOS A LA ESCUELA");

            //REPORTEADOR
            var reporteador = new Reporteador(engine.GetDiccionarioObjetos());
            var evaList = reporteador.GetListaEvaluacion();
            var evaAsig = reporteador.GetListaAsignatura();

            // foreach(var eva in evaList){
            //     WriteLine(eva.ToString());
            // }

        }

        private static void AccionDelEvento(object sender, EventArgs e)
        {
            Printer.WriteTittle("Saliendo");
            Printer.WriteTittle("Salio");
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

