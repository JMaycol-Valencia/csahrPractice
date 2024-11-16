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
            
            //DELEGADOS
            AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;
            //EVENTO DECLARADO CON ARROW FUNCTION
            AppDomain.CurrentDomain.ProcessExit += (obj, s)=> Printer.WriteTittle("Firma");
            

            var engine =  new EscuelaEngine();
            engine.inicializar();
            
            //Forzamos un error o excepcion
            //throw new Exception();

            //LLAMADAS POR CONSOLA
            WriteLine("ESCUELAS");
            Printer.DrawLine();
            WriteLine(engine.EscuelaA);
            //Printer.Pitar();
            //ImprimirCursosEscuelas(engine.EscuelaA);
            Dictionary<int, string> diccionario = new Dictionary<int, string>();
            diccionario.Add(10,"maycol");
            diccionario.Add(11,"aldrin");
            diccionario.Add(12,"mariela");

            foreach(var keyValPair in diccionario){
                WriteLine($"Value : {keyValPair.Value} Key: {keyValPair.Key}");
            }
            
            var diccionariotmp = engine.GetDiccionarioObjetos();
            engine.ImprimirDiccionario(diccionariotmp,true);

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

