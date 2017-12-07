using System;
using System.Data.SqlClient;

namespace ExemploCRUD {
    class Program {
        static void Main (string[] args) {
            BancoDados bd = new BancoDados ();
            Categoria cat = new Categoria ();
            Cliente cliente = new Cliente();

            /*Console.WriteLine("Informe o título da categoria a ser adicionado:");
            cat.Titulo = Console.ReadLine();

            try{
            if(bd.Adicionar(cat)){
                Console.WriteLine("Adicionado com sucesso!");
            }
            else{
                Console.WriteLine("Não foi possível incluir.");
            }
            }
            catch (Exception ex) {
                throw new Exception ("Erro ao cadastrar. " + ex.Message);
            }*/
           
            Console.WriteLine("Informe o ID do cliente a ser adicionado:");
            cliente.IdCliente = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Informe o nome do cliente a ser adicionado:");
            cliente.NomeCliente = Console.ReadLine();
            Console.WriteLine("Informe o e-mail do cliente a ser adicionado:");
            cliente.EmailCliente =Console.ReadLine();
            Console.WriteLine("Informe o CPF do cliente a ser adicionado:");
            cliente.CPFCliente =Console.ReadLine();
            cliente.DataCadastro = DateTime.Now;
            
           try{
            if(bd.AdicionarCliente(cliente)){
                Console.WriteLine("Adicionado com sucesso!");
            }
            else{
                Console.WriteLine("Não foi possível incluir.");
            }
            }
            catch (SqlException ex) {
                throw new Exception ("Erro ao cadastrar. " + ex.Message);
            }
            catch (Exception se) {
                throw new Exception ("Erro ao cadastrar. " + se.Message);
            }
           
        }
    }
}