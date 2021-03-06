﻿namespace Atelie.Comum
{
    public class ContatoDeEmail
    {
        public int Id { get; internal set; }

        public string Nome { get; internal set; }

        public bool Principal { get; internal set; }

        public virtual Email Email { get; internal set; }
    }
}
