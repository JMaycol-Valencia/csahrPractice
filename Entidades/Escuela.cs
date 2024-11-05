using CoreEscuela.Util;

namespace CoreEscuela.Entidades
{
    public class Escuela:ObjetoEscuelaBase, ILugar
    {  
        //Propiedad Ejemplo 2 (mas comun)
        public int AñoCreacion { get; set; }
        public string Departamento { get; set; }
        public string Direccion { get; set; }
        public TiposEscuela TipoEscuela { get; set; }

        public List<Curso> Cursos { get; set; }

        public Escuela(string nombre, int año, TiposEscuela tipo, string departamento = "")
        {
            //Asignacion de tipos de valores no opcionales
            (Nombre, AñoCreacion, TipoEscuela) = (nombre, año, tipo);
            //ASIGNACION DE VALORES OPCIONALES
            Departamento = departamento;
            Cursos = new List<Curso>();
        }

        public override string ToString()
        {
            return $"Nombre\"{Nombre}\", Creacon{AñoCreacion}, {System.Environment.NewLine} Tipo{ TipoEscuela}, Departamento{ Departamento}";
        }

        public void limpiarLugar()
        {
            Printer.DrawLine();
            Printer.WriteTittle("Limpiando Escuela...");
            foreach(var curso in Cursos){
                curso.limpiarLugar();
            }
            Printer.WriteTittle($"Escuela \"{Nombre}\"limpio");
            Printer.Pitar(hz:1500,tiempo:500,cantidad:2);
        }        
    }
}