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

            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.DrawLine(20);

            Printer.WriteTittle("Pruebas de polimorfismo");

            var alumnoTest =  new Alumno{Nombre="Jh Dios te Salve"};
            Printer.WriteTittle("Alumno");
            WriteLine($"Alumno: {alumnoTest.Nombre}");
            WriteLine($"Alumno: {alumnoTest.UniqueId}");
            WriteLine($"Alumno: {alumnoTest.GetType()}");
            
            ObjetoEscuelaBase ob = alumnoTest;
            Printer.WriteTittle("ObjetoPadre");
            WriteLine($"ObjetoPadre: {ob.Nombre}");
            WriteLine($"ObjetoPadre: {ob.UniqueId}");
            WriteLine($"ObjetoPadre: {ob.GetType()}");

            var objDummy = new ObjetoEscuelaBase(){Nombre="Fran Casttle"};
            Printer.WriteTittle("ObjetoDummy");
            WriteLine($"ObjetoDummy: {objDummy.Nombre}");
            WriteLine($"ObjetoDummy: {objDummy.UniqueId}");
            WriteLine($"ObjetoDummy: {objDummy.GetType()}");

            //SI TENEMOS ESPECIFICADOS COMO REQUERIDOS A NUESTRAS PROPIEDADES LO MEJOR ES USAR ESTE METODO
            //DE LO CONTRARIO CREAR LOS OBJETOS LIBREMENTE
            // var evaluacion = new Evaluacion()
            // {
            //     Nombre = "Mid Term Exam",
            //     Nota = 4.5f,
            //     Alumno = new Alumno { Nombre = "Alumno 1" },
            //     Asignatura = new Asignatura { Nombre = "Asignatura 1" }
            // };
            
            //METODO PARA CREAR OBJETOS LIBREMENTE
            var evaluacion = new Evaluacion(){Nombre = "Evaluacion 1", Nota=4.5f};
            Printer.WriteTittle("evaluacion");
            WriteLine($"evaluacion: {evaluacion.Nombre}");
            WriteLine($"evaluacion: {evaluacion.UniqueId}");
            WriteLine($"evaluacion: {evaluacion.Nota}");
            WriteLine($"evaluacion: {evaluacion.GetType()}");

            ob = evaluacion;
            Printer.WriteTittle("ObjetoEValuacion Copia");
            WriteLine($"ObjetoEValuacion Copia: {ob.Nombre}");
            WriteLine($"ObjetoEValuacion Copia: {ob.UniqueId}");
            WriteLine($"ObjetoEValuacion Copia: {ob.GetType()}");

            //VALIDACION 1 SI EL OJETO ES DEL TIPO QUE REQUERIMOS
            if(ob is Alumno){
                Alumno alumnoRecuperado = (Alumno) ob;
            }

            //VALIDACION 2 PARA COMPROBAR SI EL OBJETO ES ALUMNO 
            //SI NO LO ES DEVUELVE NULL
            Alumno alumnoRecuperado2 = ob as Alumno;
            if(alumnoRecuperado2 != null){
                //codigo a ejecutar
            }

            //METODO PARA PODER DECIRLE AL COMPILADOR QUE VEA UN ALUMNOTEST COMO UNA EVALUACION
            //PERO NO ES RECOMENDABLE
            // evaluacion = (Evaluacion) (ObjetoEscuelaBase) alumnoTest;

            var numero = 21;
            WriteLine($"El numero es {numero}");
            WriteLine(numero.GetType());
        }
        private static void ImprimirCursosEscuelas(Escuela? escuela)
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

