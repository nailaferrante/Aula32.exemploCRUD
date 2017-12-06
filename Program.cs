using System;

namespace ExemploCRUD {
    class Program {
        static void Main (string[] args) {
            BancoDados bd = new BancoDados ();
            Categoria cat = new Categoria ();

            Console.WriteLine("Informe o título da categoria a ser adicionado:");
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
            }
           
        }
    }
}