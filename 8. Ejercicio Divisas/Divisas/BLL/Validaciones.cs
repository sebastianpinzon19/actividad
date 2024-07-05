namespace BLL
{
    public class Validaciones
    {
        public static void ValidarPesos(double pesos)
        {
            if (pesos <= 0)
                throw new ArgumentException("La cantidad a convertir no puede ser igual o menor a cero");
        }

        public static void ValidarCambio(double cambio)
        {
            if (cambio <= 0)
                throw new ArgumentException("El tipo de cambio no puede ser menor o igual a cero");
        }
    }
}
