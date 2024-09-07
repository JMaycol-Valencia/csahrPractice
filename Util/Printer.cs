using static System.Console;
namespace CoreEscuela.Util
{
    public static class Printer
    {
            public static void DibujarLinea(int tam = 10)
            {
                var linea = "".PadLeft(tam, '=');
                WriteLine(linea);
            }
            public static void WriteTittle(string titulo = "Patito")
            {
                DibujarLinea();
                WriteLine(titulo);
                DibujarLinea();
            }
    }

}