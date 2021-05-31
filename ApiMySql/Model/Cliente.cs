using System;

namespace ApiMySql.Model
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Lancamento { get; set; } = DateTime.Now;

    }
}
