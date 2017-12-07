using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ExemploCRUD {
    public class BancoDados {
        SqlConnection cn;
        SqlCommand comandos;
        SqlDataReader rd;
        public bool Adicionar (Categoria cat) {
            bool rs = false;
            try {
                cn = new SqlConnection ();
                cn.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=Papelaria;User id=sa;password=senai@123"; //se n quiser usar arroba deve-se usar \\. //Caminho do banco. Devemos informar o servidor, nome e usuário
                cn.Open ();
                comandos = new SqlCommand ();
                comandos.Connection = cn; //relação para saber onde executa o comando.
                comandos.CommandType = CommandType.Text; //tipo de comando de texto
                comandos.CommandText = "insert into Categorias(titulo)values(@vt)";
                comandos.Parameters.AddWithValue ("@vt", cat.Titulo);

                int r = comandos.ExecuteNonQuery ();

                if (r > 0)
                    rs = true;

                comandos.Parameters.Clear ();
            } catch (SqlException se) {
                throw new Exception ("Erro ao cadastrar. " + se.Message);
            } catch (Exception ex) {
                throw new Exception ("Erro inesperado. " + ex.Message);
            } finally {
                cn.Close ();
            }
            return rs;
        }
        public bool Atualizar (Categoria cat) {
            bool rs = false;
            try {
                cn = new SqlConnection ();
                cn.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=Papelaria;User id=sa;password=senai@123"; //se n quiser usar arroba deve-se usar \\. //Caminho do banco. Devemos informar o servidor, nome e usuário
                cn.Open ();
                comandos = new SqlCommand ();
                comandos.Connection = cn;
                comandos.CommandType = CommandType.Text;
                comandos.CommandText = "update Categorias set titulo=@vt where idCategoria=@vi";
                comandos.Parameters.AddWithValue ("@vt", cat.Titulo);
                comandos.Parameters.AddWithValue ("@vi", cat.IdCategoria); // os nomes titulo e id categoria são os parametros incluidos na classe categoria.

                int r = comandos.ExecuteNonQuery ();

                if (r > 0)
                    rs = true;

                comandos.Parameters.Clear ();
            } catch (SqlException se) {
                throw new Exception ("Erro ao atualizar. " + se.Message);
            } catch (Exception ex) {
                throw new Exception ("Erro inesperado. " + ex.Message);
            } finally {
                cn.Close ();
            }
            return rs;
        }
        public bool Deletar (Categoria cat) {
            bool rs = false;
            try {
                cn = new SqlConnection ();
                cn.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=Papelaria;User id=sa;password=senai@123"; //se n quiser usar arroba deve-se usar \\. //Caminho do banco. Devemos informar o servidor, nome e usuário
                cn.Open ();
                comandos = new SqlCommand ();
                comandos.Connection = cn;
                comandos.CommandType = CommandType.Text;
                comandos.CommandText = "delete from Categorias where idCategoria=@vi";
                comandos.Parameters.AddWithValue ("@vi", cat.IdCategoria);

                int r = comandos.ExecuteNonQuery (); //retorna valor numérico, não traz dado. retorna quantidade de comandos executados.

                if (r > 0)
                    rs = true;

                comandos.Parameters.Clear ();
            } catch (SqlException se) {
                throw new Exception ("Erro ao deletar. " + se.Message);
            } catch (Exception ex) {
                throw new Exception ("Erro inesperado. " + ex.Message);
            } finally {
                cn.Close ();
            }
            return rs;
        }
        public List<Categoria> ListarCategorias (int id) {
            List<Categoria> lista = new List<Categoria> ();
            try {
                cn = new SqlConnection ();
                cn.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=Papelaria;User id=sa;password=senai@123";
                cn.Open ();
                comandos = new SqlCommand ();
                comandos.Connection = cn;
                comandos.CommandType = CommandType.Text;
                comandos.CommandText = "Select * from Categorias where idCategoria=@vi";
                comandos.Parameters.AddWithValue ("@vi", id);
                rd = comandos.ExecuteReader (); //é um leitor de dados (data reader).

                while (rd.Read ()) { //enquando houver possibilidade de ler conteúdo dentro de rd
                    lista.Add (new Categoria { IdCategoria = rd.GetInt32 (0), Titulo = rd.GetString (1) }); //será criada uma lista e será adicionada uma nova categoria anônima, e será colocada dentro dos parâmetros. tem que colocar new categoria para tipar, e foi criado dentro do laço.
                    //poderia ser também da seguinte maneira
                    // Categoria ct = new Categoria(){
                    //     IdCategoria=rd.GetInt32(0),
                    //     Titulo=rd.GetString(1)};
                    //    lista.Add(ct);
                }
                comandos.Parameters.Clear ();
            } catch (SqlException se) {
                throw new Exception ("Erro ao tentar listar. " + se.Message);
            } catch (Exception ex) {
                throw new Exception ("Erro inesperado. " + ex.Message);
            } finally {
                cn.Close ();
            }
            return lista;
        }
        public List<Categoria> ListarCategorias (string titulo) {
            List<Categoria> lista = new List<Categoria> ();
            try {
                cn = new SqlConnection ();
                cn.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=Papelaria;User id=sa;password=senai@123";
                cn.Open ();
                comandos = new SqlCommand ();
                comandos.Connection = cn;
                comandos.CommandType = CommandType.Text;
                comandos.CommandText = "Select * from Categorias where titulo like @vi";
                comandos.Parameters.AddWithValue ("@vi", titulo);
                rd = comandos.ExecuteReader (); //é um leitor de dados (data reader).

                while (rd.Read ()) { //enquando houver possibilidade de ler conteúdo dentro de rd
                    lista.Add (new Categoria { IdCategoria = rd.GetInt32 (0), Titulo = rd.GetString (1) }); //será criada uma lista e será adicionada uma nova categoria anônima, e será colocada dentro dos parâmetros. tem que colocar new categoria para tipar, e foi criado dentro do laço.
                    //poderia ser também da seguinte maneira
                    // Categoria ct = new Categoria(){
                    //     IdCategoria=rd.GetInt32(0),
                    //     Titulo=rd.GetString(1)};
                    //    lista.Add(ct);
                }
                comandos.Parameters.Clear ();
            } catch (SqlException se) {
                throw new Exception ("Erro ao tentar listar. " + se.Message);
            } catch (Exception ex) {
                throw new Exception ("Erro inesperado. " + ex.Message);
            } finally {
                cn.Close ();
            }
            return lista;

        }

        public bool AdicionarCliente (Cliente cliente){
            bool rs = false;
            try{//vamos tentar inserir os dados na tabela
            cn = new SqlConnection(); // classe que ajuda a comunicação com o servidor
            cn.ConnectionString=@"Data Source=.\sqlexpress;initial catalog=Papelaria;user id=sa;password=senai@123";//temos que dizer o caminho login e senha para conectar//se estiver em outro computador que não o local precisamos saber o ip em vez do .\ .
            cn.Open();
            comandos = new SqlCommand();
            comandos.Connection = cn;//o banco neste caso é o cn
            comandos.CommandType = CommandType.StoredProcedure;
            comandos.CommandText = "sp_CadCliente";//informar o procedure

            SqlParameter pnome = new SqlParameter("@nome",SqlDbType.VarChar,50);//os parametros do procedure estão em "formato" sql, portanto precisamos "traduzir" para C# //tipo de dados do banco de dados = SqlDbType.
            pnome.Value = cliente.NomeCliente; //pnome é a representação do @nome no SQL, o .Value está adcionando valor ao NomeCLiente da classe Cliente
            comandos.Parameters.Add(pnome);//adicionado ao parâmetro.
            
            SqlParameter pemail = new SqlParameter("@email",SqlDbType.VarChar,100);
            pemail.Value = cliente.EmailCliente;
            comandos.Parameters.Add(pemail);

            SqlParameter pcpf = new SqlParameter("@cpf",SqlDbType.VarChar,20);
            pcpf.Value = cliente.CPFCliente;
            comandos.Parameters.Add(pcpf);

            int r = comandos.ExecuteNonQuery();
            if(r>1)
                rs = true;
                
            comandos.Parameters.Clear();
            }
            catch(SqlException se){
                throw new Exception("Erro ao tentar inserir os dados"+se.Message);
            }
            catch(Exception ex){
                throw new Exception("Erro inesperado"+ex.Message);
            }
            finally {
                cn.Close();
            }
            return rs;
        }
    }
}