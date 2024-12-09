using static System.Console;
using System.Diagnostics;

namespace CoreEscuela.Util
{
    public static class Printer
    {
        public static void DrawLine(int tam = 10)
        {
            var linea = "".PadLeft(tam, '=');
            WriteLine(linea);
        }
        public static void WriteTittle(string titulo)
        {
            DrawLine();
            WriteLine(titulo);
            DrawLine();
        }

        public static void Pitar(int hz = 2000, int tiempo = 500, int cantidad = 1)
        {
            //COMPARACION DE
            while (cantidad-- > 0)
            {
                //Beep(hz, tiempo);
            }
        }

        public static void PresioneEnter()
        {
            WriteLine("Presione ENTER ...");
        }


        public static void PitarMac(int hz = 2000, int tiempo = 500, int cantidad = 1)
        {
            while (cantidad-- > 0)
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "/bin/bash",
                        Arguments = "-c \"say beep\"",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    }
                };
                process.Start();
                process.WaitForExit();
            }
        }
    }

}