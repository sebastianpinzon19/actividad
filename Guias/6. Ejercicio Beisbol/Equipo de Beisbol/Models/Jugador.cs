using BLL;

namespace Models
{
    public abstract class Jugador
    {
        private int numeroUniforme;
        public int NumeroUniforme
        {
            get { return numeroUniforme; }
            set { Validaciones.ValidarNumero(value); numeroUniforme = value; }
        }

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { Validaciones.ValidarString(value); nombre = value; }
        }

        private string posicion;
        public string Posicion
        {
            get { return posicion; }
            set { Validaciones.ValidarString(value);posicion = value; }
        }

        public Jugador(int numeroUniforme, string nombre, string posicion)
        {
            NumeroUniforme = numeroUniforme;
            Nombre = nombre;
            Posicion = posicion;
        }
        public abstract string MostrarDatos();
    }
}
