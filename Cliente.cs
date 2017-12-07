using System;

namespace ExemploCRUD
{
    public class Cliente
    {
        public int IdCliente { get; set; } //classe clientes que permite transitar os dados para a tabela clientes. Não é a tabela clientes que está no banco SQL.
        public string NomeCliente { get; set; }
        public string EmailCliente { get; set; }
        public string CPFCliente { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}