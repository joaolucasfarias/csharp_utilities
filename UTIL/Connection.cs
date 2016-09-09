namespace UTIL
{
    /// <summary>
    /// Classe que define a conexão com o banco de dados.
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// Variável estática que contém a String de conexão com o banco escolhido pelo método usado.
        /// </summary>
        public static string stringConexao = "";

        /// <summary>
        /// Monta a string de conexão com o banco de dados SQL Server.
        /// </summary>
        /// <param name="servidor">IP do servidor que irá se conectar.</param>
        /// <param name="banco">Nome do banco de dados.</param>
        /// <param name="usuario">Usuário usado para se conectar.</param>
        /// <param name="senha">Senha do banco de dados.</param>
        public static void conectaSQLServer(string servidor, string banco, string usuario, string senha)
        {
            stringConexao = "Server = " + servidor + "; Database = " + banco + "; User Id = " + usuario + "; Password = " + senha + ";";
        }

        /// <summary>
        /// Monta a string de conexão com o banco de dados PostgreSQL.
        /// </summary>
        /// <param name="servidor">IP do servidor que irá se conectar.</param>
        /// <param name="porta">Porta usada na conexão.</param>
        /// <param name="usuario">Usuário usado para se conectar.</param>
        /// <param name="senha">Senha do banco de dados.</param>
        /// <param name="banco">Nome do banco de dados.</param>
        public static void conectaPostgres(string servidor, string porta, string usuario, string senha, string banco)
        {
            stringConexao = "Server=" + servidor + "; Port=" + porta + "; User id=" + usuario + "; Password=" + senha + "; Database=" + banco + ";";
        }

        /// <summary>
        /// Monta a string de conexão com o banco de dados MySQL.
        /// </summary>
        /// <param name="servidor">IP do servidor que irá se conectar.</param>
        /// <param name="banco">Nome do banco de dados.</param>
        /// <param name="usuario">Usuário usado para se conectar.</param>
        /// <param name="senha">Senha do banco de dados.</param>
        public static void conectaMySql(string servidor,string banco,string usuario,string senha)
        {
            stringConexao = "Server = " + servidor + "; Database = " + banco + "; Uid = " + usuario + "; Pwd = " + senha + ";";
        }
    }
}
