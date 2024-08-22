namespace CoreEscuela.Entidades
{
    class Escuela
    {
        //Atributos
        string nombre = "anonimo";
        //Propiedad Ejemplo 1
        public string Nombre
        {
            get { return "copia: " + nombre; }
            set { nombre = value.ToUpper(); }
        }    
        //Propiedad Ejemplo 2 (mas comun)
        public int AñoCreacion { get; set; }
        public string ?Departamento { get; set; }
        public TiposEscuela TipoEscuela { get; set; }

        //Constructor Ejeemplo 1
        // public Escuela(string nombre, int año){
        //     this.nombre = nombre;
        //     this.AñoCreacion = año;
        // }
        // public Escuela(string nombre, int año,TiposEscuela tipo, string departamento = "")
        // {
        //     this.Nombre = nombre;
        //     this.AñoCreacion = año;
        //     this.TipoEscuela = tipo;    
        //     this.Departamento = departamento;
        // }


        //Constructor Ejemplo 2
        public Escuela(string nombre, int año) => (Nombre, AñoCreacion) = (nombre, año);

        public Escuela(string nobre, int año, TiposEscuela tipo, string departamento = "")
        {
            //Asignacion de tipos de valores no opcionales
            (Nombre, AñoCreacion, TipoEscuela) = (nobre, año, tipo);
            Departamento = departamento;
        }

      
        public override string ToString()
        {
            return $"Nombre\"{Nombre}\", Creacon{AñoCreacion}, {System.Environment.NewLine} Tipo{ TipoEscuela}, Departamento{ Departamento}";
        }
    }
}