using App_Login.Models;
using App_Login.Models.Constant;
using App_Login.Repositories.Contract;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System.Data;
using System.Runtime.InteropServices;
using X.PagedList;

namespace App_Login.Repositories
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private readonly string _conexao;

        public ColaboradorRepository(IConfiguration conf)
        {
            _conexao = conf.GetConnectionString("ConexaoMySQL");
        }

        public void Atualizar(Colaborador colaborador)
        {
            throw new NotImplementedException();
        }

        public void AtualizarSenha(Colaborador colaborador)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Colaborador colaborador)
        {
            string Comum = ColaboradorTipoConstant.Comum;

            using (var conexao = new MySqlConnection(_conexao))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into Cliente(Nome, CPF, Telefone, Email, Senha, Tipo " +
                    " values(@Nome, @CPF, @Telefone, @Email, @Senha, @Tipo);", conexao);

                cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = colaborador.Nome;
                cmd.Parameters.Add("@Nascimento", MySqlDbType.VarChar).Value = colaborador.CPF;
                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = colaborador.Email;
                cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = colaborador.Senha;
                cmd.Parameters.Add("@Telefone", MySqlDbType.VarChar).Value = colaborador.Telefone;
                cmd.Parameters.Add("@Tipo", MySqlDbType.VarChar).Value = Comum;

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Excluir(int Id)
        {
            throw new NotImplementedException();
        }

        public Colaborador Login(string Email, string Senha)
        {
            using (var conexao = new MySqlConnection(_conexao))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Colaborador where Email= @Email and Senha = @Senha", conexao);

                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = Email;
                cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = Senha;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Colaborador colaborador = new Colaborador();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    colaborador.Id = Convert.ToInt32(dr["Id"]);
                    colaborador.Nome = Convert.ToString(dr["Nome"]);
                    colaborador.Email = Convert.ToString(dr["Email"]);
                    colaborador.Senha = Convert.ToString(dr["Senha"]);
                    colaborador.Tipo = Convert.ToString(dr["Tipo"]);
                }
                return colaborador;
            }
        }

        public Colaborador ObterColaborador(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Colaborador> ObterColaboradorPorEmail(string Email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Colaborador> ObterTodosColaboradores()
        {
            throw new NotImplementedException();
        }

        public IPagedList<Colaborador> ObterTodosColaboradores(int? pagina)
        {
            throw new NotImplementedException();
        }
    }
}
