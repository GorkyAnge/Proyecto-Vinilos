using APIProductos.Models;
using System.Security.Cryptography;
using System.Text;

namespace APIProductos.Util
{
    public class Utils
    {
        public static string EncriptarClave(string clave)
        {
            StringBuilder sb = new StringBuilder();

            //Estamos usando el SHA256 Que es el modo de encriptación de la clave
            using(SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;

                byte[] result = hash.ComputeHash(enc.GetBytes(clave));

                //se itera cada uno de los elementos
                foreach(byte b in result)
                {
                    //se concatena todo en el resultado
                    //El formato x2 significa que la cadena debe formatearse en hexadecimal
                    sb.Append(b.ToString("X2"));
                }
                //devuelve el sb que es un string builder
                return sb.ToString();
            }
        }
    }
}
