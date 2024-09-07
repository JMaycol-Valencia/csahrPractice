using CoreEscuela.Entidades;

namespace CoreEscuela
{
    public class EscuelaEngine
    {
        public Escuela ?Escuela { get; set; }

        public EscuelaEngine()
        {
            
        }

        public void inicializar()
        {
            Escuela = new Escuela("Escuela triste", 1998, TiposEscuela.Secundaria, departamento: "cochabamba");

            Escuela.Cursos = new List<Curso>(){
                new Curso("201", TipoJornada.Mañana),
                new Curso("202", TipoJornada.Tarde),
                new Curso("203", TipoJornada.Noche),
                new Curso("206", TipoJornada.Noche),
                new Curso("207", TipoJornada.Mañana),
                new Curso("208", TipoJornada.Mañana),
            };
        }

    }
}