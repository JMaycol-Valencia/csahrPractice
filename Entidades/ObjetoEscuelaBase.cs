using System;

namespace CoreEscuela.Entidades
{
    public abstract class ObjetoEscuelaBase
    {
        public string UniqueId {get; private set;}
        public string Nombre {get;set;}

        public ObjetoEscuelaBase(){
            UniqueId = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"Nombre Objeto: {Nombre}, ID: {UniqueId}";
        }
    }
}