using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repositorios
{
    public class ContatosRepositorio
    {
        public static IEnumerable ObterContatos()
        {
            try
            {

                using (var conn = new SqlConnection(@"Data Source=DESKTOP-HQUTBC2\SQLEXPRESS; Initial Catalog=SSL; User Id=sa; Password=5239870ab;"))
                {
                    conn.Open();

                    string sql = @" SELECT CD_CONTATO as cdContato
                                         , NM_RAZAO_SOCIAL as nmRazaoSocial
                                         , NM_FANTASIA as nmFantasia
                                         , DS_CNPJ_CPF as dsCnpjCpf
                                         , DS_EMAIL as dsEmail
                                         , DS_FONE as dsFone
                                   FROM dbo.CONTATOS ";
                    return conn.Query<Contatos>(sql);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                string erro = e.ToString();
                return new string[] { erro };
            }
        }

        public static IEnumerable ObterContato(int cdContato)
        {
            try
            {

                using (var conn = new SqlConnection(@"Data Source=DESKTOP-HQUTBC2\SQLEXPRESS; Initial Catalog=SSL; User Id=sa; Password=5239870ab;"))
                {
                    conn.Open();

                    string sql = @" SELECT CD_CONTATO as cdContato
                                         , NM_RAZAO_SOCIAL as nmRazaoSocial
                                         , NM_FANTASIA as nmFantasia
                                         , DS_CNPJ_CPF as dsCnpjCpf
                                         , DS_EMAIL as dsEmail
                                         , DS_FONE as dsFone
                                    FROM dbo.CONTATOS
                                    WHERE CD_CONTATO = @cdContato ";
                    return conn.Query<Contatos>(sql, new { cdContato });
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                string erro = e.ToString();
                return new string[] { erro };
            }
        }

        public static Contatos CadastrarContato(Contatos contato)
        {
            try
            {

                using (var conn = new SqlConnection(@"Data Source=DESKTOP-HQUTBC2\SQLEXPRESS; Initial Catalog=SSL; User Id=sa; Password=5239870ab;"))
                {
                    conn.Open();

                    string sql = @" INSERT INTO dbo.CONTATOS
                                          (  NM_RAZAO_SOCIAL
                                           , NM_FANTASIA
                                           , DS_CNPJ_CPF
                                           , DS_EMAIL
                                           , DS_FONE )
                                     VALUES
                                           ( @nmRazaoSocial
		                                   , @nmFantasia
                                           , @dsCnpjCpf
		                                   , @dsEmail
		                                   , @dsFone ); ";

                    sql += @" SELECT CD_CONTATO as cdContato
                                         , NM_RAZAO_SOCIAL as nmRazaoSocial
                                         , NM_FANTASIA as nmFantasia
                                         , DS_CNPJ_CPF as dsCnpjCpf
                                         , DS_EMAIL as dsEmail
                                         , DS_FONE as dsFone
                                    FROM dbo.CONTATOS
                                    WHERE CD_CONTATO = CAST(SCOPE_IDENTITY() as int); "; ;

                   return conn.Query<Contatos>(sql, contato).Single();

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                string erro = e.ToString();
                return contato;
            }
        }

        public static Contatos AtualizarContato(int cdContato, Contatos contato)
        {
            try
            {

                using (var conn = new SqlConnection(@"Data Source=DESKTOP-HQUTBC2\SQLEXPRESS; Initial Catalog=SSL; User Id=sa; Password=5239870ab;"))
                {
                    conn.Open();

                    string sql = @" UPDATE [dbo].[CONTATOS]
                                       SET [NM_RAZAO_SOCIAL] = @nmRazaoSocial
                                          ,[NM_FANTASIA] = @nmFantasia
                                          ,[DS_CNPJ_CPF] = @dsCnpjCpf
                                          ,[DS_EMAIL] = @dsEmail
                                          ,[DS_FONE] = @dsFone 
                                     WHERE CD_CONTATO = @cdContato ; ";

                    sql += @" SELECT CD_CONTATO as cdContato
                                         , NM_RAZAO_SOCIAL as nmRazaoSocial
                                         , NM_FANTASIA as nmFantasia
                                         , DS_CNPJ_CPF as dsCnpjCpf
                                         , DS_EMAIL as dsEmail
                                         , DS_FONE as dsFone
                                    FROM dbo.CONTATOS
                                    WHERE CD_CONTATO = @cdContato; "; ;
                    contato.cdContato = cdContato;
                    return conn.Query<Contatos>(sql, contato).Single();

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                string erro = e.ToString();
                return contato;
            }
        }

        public static void DeletarContato(int cdContato)
        {
            try
            {

                using (var conn = new SqlConnection(@"Data Source=DESKTOP-HQUTBC2\SQLEXPRESS; Initial Catalog=SSL; User Id=sa; Password=5239870ab;"))
                {
                    conn.Open();

                    string sql = @" DELETE FROM [dbo].[CONTATOS] WHERE CD_CONTATO = @cdContato";

                    conn.Execute(sql, new { cdContato });
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                string erro = e.ToString();
            }
        }
    }
}
