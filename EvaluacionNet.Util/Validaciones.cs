using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionNet.Util
{
    public class Validaciones
    {
        public static bool UsuarioEsValido(string nombre)
        {
            string[] usuariosValidos = { "juliana", "pedro", "juan", "lina"};
            string nombreLower = nombre.Trim().ToLower();
            if (usuariosValidos.Contains(nombreLower))
            {
                return true;
            }
            return false;
        }
    }
}
