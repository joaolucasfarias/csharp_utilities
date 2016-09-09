namespace UTIL
{
    /// <summary>
    /// Classe que padroniza as mensagens exibidas pela aplicação
    /// </summary>
    public class Mensagens
    {
        /// <summary>
        /// Variável que armazena qualquer mensagem de erro do sistema.
        /// </summary>
        internal static string mensagem = string.Empty;

        /// <summary>
        /// Mensagem de erro padrão para erros de SQL.
        /// </summary>
        /// <param name="codigoErro">Código do erro ocorrido.</param>
        /// <param name="metodoExecutado">Nome do método executado no momento.</param>
        /// <param name="linhaErro">Linha do erro ocorrido.</param>
        /// <param name="mensagemErro">Mensagem do erro ocorrido.</param>
        /// <returns>Retorna uma string contendo uma mensagem padrão de erro.</returns>
        public static void erroSQL(int codigoErro, string mensagemErro)
        {
            mensagem = "Erro: " + codigoErro.ToString() + ".\nUm erro de banco de dados aconteceu ao tentar executar o método \"" + Utils.retornaNomeMetodo() + "\".\n\nMensagem de erro: " + mensagemErro;
        }

        /// <summary>
        /// Mensagem de erro padrão para erros em tempo de execução.
        /// </summary>
        /// <param name="codigoErro">Código do erro ocorrido.</param>
        /// <param name="metodoExecutado">Nome do método executado no momento.</param>
        /// <param name="mensagemErro">Mensagem do erro ocorrido.</param>
        /// <returns>Retorna uma string contendo uma mensagem padrão de erro.</returns>
        public static void erroComum(int codigoErro, string mensagemErro)
        {
            mensagem = "Erro: " + codigoErro.ToString() + ".\nUm erro, em tempo de execução, ocorreu ao tentar executar o método \"" + Utils.retornaNomeMetodo() + "\".\n\nMensagem de erro: " + mensagemErro;
        }

        /// <summary>
        /// Mensagem de aviso para quando um código não for digitado.
        /// </summary>
        public static void codigoVazio()
        {
            mensagem = "Código do atributo não informado!\nMétodo executado no momento: \"" + util.Utils.retornaNomeMetodo() + "\".";
        }

        /// <summary>
        /// Mensagem de aviso padrão para quando houver campos vazios.
        /// </summary>
        /// <param name="nomeCampo">Nome do campo que preencherá a mensagem.</param>
        public static void campoVazio(string nomeCampo)
        {
            mensagem = "O campo \"" + nomeCampo + "\" não pode ser vazio!";
        }

        /// <summary>
        /// Mensagem de aviso padrão para quando houver campos preenchidos de forma insuficiente.
        /// </summary>
        /// <param name="nomeCampo">Nome do campo que preencherá a mensagem.</param>
        public static void campoInsuficiente(string nomeCampo)
        {
            mensagem = "O campo \"" + nomeCampo + "\" não tem caracteres suficientes!";
        }

        /// <summary>
        /// Mensagem de aviso padrão para quando um campo estiver preenchido com um formato incorreto.
        /// </summary>
        /// <param name="nomeCampo">Nome do campo que preencherá a mensagem.</param>
        /// <param name="tipoCorreto">Tipo correto que deveria estar no campo.</param>
        public static void campoFormatoIncorreto(string nomeCampo, string tipoCorreto)
        {
            mensagem = "O campo \"" + nomeCampo + "\" deve conter APENAS " + tipoCorreto.ToLower() + "!";
        }

        /// <summary>
        /// Mensagem de aviso padrão exibida para quando um campo único for preenchido com valor já existente.
        /// </summary>
        /// <param name="nomeCampo">Nome do campo que preencherá a mensagem.</param>
        public static void campoIgual(string nomeCampo)
        {
            mensagem = "O campo \"" + nomeCampo + "\" deve ser único!";
            util.Utils.janelaAviso(5);
        }

        /// <summary>
        /// Preenche e exibe mensagem de aviso padrão de sucesso.
        /// </summary>
        public static void avisoSucesso()
        {
            mensagem = "Operação realizada com sucesso!";
            Utils.janelaAviso(1);
        }

        /// <summary>
        /// Preenche e exibe mensagem de aviso padrão de erro.
        /// </summary>
        public static void avisoFalha()
        {
            mensagem = "Falha ao tentar realizar a operação!";
            Utils.janelaAviso(3);
        }

        /// <summary>
        /// Mensagem padrão para perguntar se deseja prosseguir.
        /// </summary>
        public static void avisoProsseguir()
        {
            mensagem = "Deseja realmente prosseguir com a operação?";
        }
    }
}
