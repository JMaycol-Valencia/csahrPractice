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
            AppDomain.CurrentDomain.ProcessExit += (obj, s) => Printer.WriteTittle("Firma de Salida");


            var engine = new EscuelaEngine();
            engine.inicializar();
            Printer.WriteTittle("BIENVENIDOS A LA ESCUELA");

            //REPORTEADOR
            var reporteador = new Reporteador(engine.GetDiccionarioObjetos());
            var evaList = reporteador.GetListaEvaluacion();
            var evaAsig = reporteador.GetListaAsignatura();
            var evalXAsig = reporteador.GetDicEvalxAsig();

            Printer.WriteTittle("Captura de una Evaluacion por Consola");
            var newEval = new Evaluacion();
            string nombre, notastring;
            //float nota;

            WriteLine("Ingrese el nombre de la evaluacion");
            Printer.PresioneEnter();
            nombre = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                //throw new ArgumentException("El valor del nombre no puede swervacio");
                Printer.WriteTittle("El valor del nombre no puede ser vacio");
            }
            else
            {
                newEval.Nombre = nombre.ToLower();
                WriteLine("El nombre de la evaluacion ha sido ingresado correctamente");
            }

            WriteLine("Ingrese la nota de la evaluacion");
            Printer.PresioneEnter();
            notastring = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(notastring))
            {
                //throw new ArgumentException("El valor de la nota no puede swervacio");
                Printer.WriteTittle("El valor de la nota no puede ser vacio");
                WriteLine("Saliendo del programa");
            }
            else
            {
                try
                {
                    newEval.Nota = float.Parse(notastring);
                    if (newEval.Nota < 0 || newEval.Nota > 5)
                    {   
                        throw new ArgumentOutOfRangeException("La nota debe etar entre 0 y 5");
                    }
                    WriteLine("La nota de evaluacion ha sido ingresada correctamente");
                    return;
                }
                catch(ArgumentException arge){
                    Printer.WriteTittle(arge.Message);
                    
                }
                catch(Exception){
                    Printer.WriteTittle("El valor de la nota no es un numero valido");
                    WriteLine("Saliendo del programa");
                }
                finally{
                    Printer.WriteTittle("finally");
                }
            }
        }

        private static void AccionDelEvento(object sender, EventArgs e)
        {
            Printer.WriteTittle("Saliendo");
            Printer.WriteTittle("Salio");
        }

        private static void ImprimirCursosEscuelas(Escuela escuela)
        {

            if (escuela == null)
            {
                return;
            }

            Printer.DrawLine(escuela.Nombre.Length + 4);
            Printer.WriteTittle($"| {escuela.Nombre} |");

            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    Printer.WriteTittle($"Name: {curso.Nombre}, ID: {curso.UniqueId}");
                }
            }
        }
    }
}

