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

                int r = comandos.ExecuteNonQuery ();//retorna valor numérico, não traz dado. retorna quantidade de comandos executados.

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
        public List<Categoria> ListarCategorias(int id){
            List<Categoria> lista = new List<Categoria>();
            try{
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=Papelaria;User id=sa;password=senai@123";
                cn.Open();
                comandos = new SqlCommand();
                comandos.Connection = cn;
                comandos.CommandType = CommandType.Text;
                comandos.CommandText="Select * from Categorias where idCategoria=@vi";
                comandos.Parameters.AddWithValue("@vi",id);
                rd = comandos.ExecuteReader();//é um leitor de dados (data reader).

                while(rd.Read()){
                    lista.Add(new Categoria{IdCategoria=rd.GetInt32(0),Titulo=rd.GetString(1)});
                }
            }
        }
    }
}