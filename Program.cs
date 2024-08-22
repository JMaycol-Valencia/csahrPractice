using CoreEscuela.Entidades;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");

            var escuela = new Escuela("Escuela feliz", 1997);
            var escuela2 = new Escuela("Escuela triste", 1998, TiposEscuela.Secundaria);

            escuela.TipoEscuela = TiposEscuela.Primaria;
            escuela.Departamento = "Cochabamba";
            Console.WriteLine(escuela);
        }
    }

}

