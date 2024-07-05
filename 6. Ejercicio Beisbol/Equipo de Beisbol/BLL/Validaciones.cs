namespace BLL
{
    public class Validaciones
    {
        public static void ValidarNumero(int numero)
        {
            if (numero < 0)
            {
                throw new ArgumentException("no puede ingresar valores menores a 0");
            }
        }

        public static void ValidarString(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException("El campo no puede estar vacio");
            }
        }

    }
}
