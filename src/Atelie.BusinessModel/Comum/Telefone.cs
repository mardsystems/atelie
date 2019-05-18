using System;
using System.Collections.Generic;
using System.Text;

namespace Atelie.Comum
{
    public interface ITelefone
    {
        string DDD { get; }

        string Numero { get; }

        TipoDeTelefone Tipo { get; }
    }
}
