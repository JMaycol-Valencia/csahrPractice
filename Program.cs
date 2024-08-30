using System;
using CoreEscuela.Entidades;

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

            //ARREGLO DE CURSOS
            var arregloCurso = new Curso[3];

            arregloCurso[0] = new Curso("105", TipoJornada.Noche);
            var curso6 = new Curso("106", TipoJornada.Mañana);
            arregloCurso[1] = curso6;
            arregloCurso[2] = new Curso("107", TipoJornada.Tarde);

            //CREACION DE CURSOS
            var  curso1 = new Curso("101", TipoJornada.Mañana);

            var curso2 = new Curso("102", TipoJornada.Tarde);

            var curso3 = new Curso("103", TipoJornada.Noche);
            
            escuela.TipoEscuela = TiposEscuela.Primaria;
            escuela.Departamento = "Cochabamba";

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

