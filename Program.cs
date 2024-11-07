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
            Dictionary<int, string> diccionario = new Dictionary<int, string>();
            diccionario.Add(10,"maycol");
            diccionario.Add(11,"aldrin");
            diccionario.Add(12,"mariela");

            foreach(var keyValPair in diccionario){
                WriteLine($"Value : {keyValPair.Value} Key: {keyValPair.Key}");
            }

            Printer.WriteTittle("Acceos al Diccionario");
            WriteLine(diccionario[12]);

            var dic=  new Dictionary<string , string>();
            dic.Add("peli uno", "buena");
            WriteLine(dic["peli uno"]);

            //LA SIGUEINTE LINEA NOS DARA UN ERROR
            dic.Add("peli uno", "Super buena");
            WriteLine(dic["peli uno"]);
            
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

