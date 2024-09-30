using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Seguridad
{
    public static class Seguridad
    {
        public static bool sesionIniciada(object user)
        {
            User usuario = user != null ? (User)user : null;
            if (usuario != null && usuario.Id != 0)
            {
                return true;
            }
            return false;
        }
    }
}

