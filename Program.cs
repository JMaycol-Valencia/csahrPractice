using System;
using CoreEscuela.Entidades;
using static System.Console;


namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");

            //CREACION DE ESCUELAS
            var escuela = new Escuela("Escuela feliz", 1997);
            var escuela2 = new Escuela("Escuela triste", 1998, TiposEscuela.Secundaria);

            //ARREGLO DE CURSOS SIMPLIFIACADO
            var arregloCurso = new Curso[3]{
                new Curso("105", TipoJornada.Noche),
                new Curso("106", TipoJornada.Mañana),
                new Curso("107", TipoJornada.Tarde)
            };
            
            escuela2.Cursos = new Curso[]{
                new Curso("201", TipoJornada.Mañana),
                new Curso("202", TipoJornada.Tarde),
                new Curso("203", TipoJornada.Noche)
            };

            //ARREGLO DE CURSOS SIMPLIFICADO 2
            // Curso[] arregloCurso2 = {
            //     new Curso("105", TipoJornada.Noche),
            //     new Curso("106", TipoJornada.Mañana),
            //     new Curso("107", TipoJornada.Tarde)
            // };
            
            //ARREGLO DE CURSOS CON ASIGNACION DE OBJETOS
            arregloCurso[0] = new Curso("105", TipoJornada.Noche);
            var curso6 = new Curso("106", TipoJornada.Mañana);
            arregloCurso[1] = curso6;
            arregloCurso[2] = new Curso("107", TipoJornada.Tarde);

            //CREACION DE CURSOS INDIVIDUALES SOBRE VARIABLES
            var  curso1 = new Curso("101", TipoJornada.Mañana);
            var curso2 = new Curso("102", TipoJornada.Tarde);
            var curso3 = new Curso("103", TipoJornada.Noche);

            //ASIGNACION DE VALORES A LA ESCUELA
            escuela.TipoEscuela = TiposEscuela.Primaria;
            escuela.Departamento = "Cochabamba";

            //LLAMADAS POR CONSOLA
            System.Console.WriteLine("ESCUELAS");
            System.Console.WriteLine("==============");
            Console.WriteLine(escuela);
            Console.WriteLine(escuela2);
            System.Console.WriteLine("CURSOS");
            System.Console.WriteLine("==============");
            System.Console.WriteLine(curso1.Name + " " + curso1.UniqueId);
            System.Console.WriteLine($"{curso2.Name} {curso2.UniqueId}");
            System.Console.WriteLine(curso3.Name + " " +  curso3.UniqueId);
            System.Console.WriteLine("RRECORRIDO DE ARREGLO");
            System.Console.WriteLine("WHILE");
            System.Console.WriteLine("==============");
            ImprimirCursos(arregloCurso);
            System.Console.WriteLine("DO WHILE");
            System.Console.WriteLine("==============");
            ImprimirCursosDoWhile(arregloCurso);
            System.Console.WriteLine("FOR");
            System.Console.WriteLine("==============");
            ImprimirCursosFor(arregloCurso);
            System.Console.WriteLine("FOREACH");
            System.Console.WriteLine("==============");
            ImprimirCursosForEach(arregloCurso);

            ImprimirCursosEscuelas(escuela2);

            bool rta = 10 == 10;//true
            int cantidad = 10;

            if (rta == false)
            {
                WriteLine("Se cumplio la condición #1");
            }
            else if (cantidad > 15)
            {
                WriteLine("Se cumplio la condición #2");
            }
            else
            {
                WriteLine("NO Se cumplio la condición");
            }

            if(cantidad > 5 && rta == false)
            {
                WriteLine("Se cumplio la condición #3");
            }

            
            if(cantidad > 5 && rta )
            {
                WriteLine("Se cumplio la condición #4");
            }

            cantidad = 10;
            if(
                (cantidad > 15 || !rta) 
                && (cantidad % 5 == 0 )
            )
            {
                WriteLine("Se cumplio la condición #5");
            }


        }

        private static void ImprimirCursosEscuelas(Escuela escuela2)
        {
            System.Console.WriteLine("================");
            System.Console.WriteLine("CURSOS DE ESCUELA");
            System.Console.WriteLine("================");

            if(escuela2?.Cursos != null){
                foreach(var curso in escuela2.Cursos){
                    WriteLine($"Name: {curso.Name}, ID: {curso.UniqueId}");
                }
            }
        }

        private static void ImprimirCursos(Curso[] arregloCurso){
            int contador = 0;
            while(contador < arregloCurso.Length){
                System.Console.WriteLine($"Nombre: {arregloCurso[contador].Name}, Id: {arregloCurso[contador].UniqueId}");
                contador++;
            }
        }

        private static void ImprimirCursosDoWhile(Curso[] arregloCurso){
            int contador = 0;
            do{
                System.Console.WriteLine($"Nombre: {arregloCurso[contador].Name}, Id: {arregloCurso[contador].UniqueId}");
                contador++;
            }while(contador < arregloCurso.Length);
        }

        private static void ImprimirCursosFor(Curso[] arregloCurso){
            for(int i = 0; i < arregloCurso.Length; i ++){
                System.Console.WriteLine($"Name : {arregloCurso[i].Name}, ID: {arregloCurso[i].UniqueId}, Jornada: {arregloCurso[i].Jornada}");
            }
        }

        private static void ImprimirCursosForEach(Curso[] arregloCurso){
            foreach(var curso in arregloCurso){
                System.Console.WriteLine($"Name: {curso.Name} ID: {curso.UniqueId} Jornada: {curso.Jornada}");
            }
        }
    }

}

