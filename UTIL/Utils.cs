using System;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace UTIL
{
    public class Utils
    {
        /// <summary>
        /// Texto que será exibido na tela de Splash, quando invocada. Por padrão, mostra Atualizando...
        /// </summary>
        private static string textoSplashScreen = "Atualizando...";

        /// <summary>
        /// Variável que define se a tela de Splash deverá ser fechada, ou não
        /// </summary>
        private static bool fechaSplashScreen;

        /// <summary>
        /// Aplica o hash SHA256 a um valor.
        /// </summary>
        /// <param name="valor">Valor que receberá a criptografia.</param>
        /// <returns>Retorna uma string de 64 caracteres com o valor do hash.</returns>
        public static string aplicarHash(string valor)
        {
            SHA256Managed sha256 = new SHA256Managed();
            StringBuilder resultado = new StringBuilder();
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(valor), 0, Encoding.UTF8.GetByteCount(valor));
            foreach (byte cadaByte in hash)
            {
                resultado.Append(cadaByte.ToString("x2"));
            }
            return resultado.ToString();
        }

        /// <summary>
        /// Retorna o nome do método atualmente em execução.
        /// </summary>
        /// <returns>Retorna uma string com o nome do método em execução.</returns>
        internal static string retornaNomeMetodo()
        {
            var stack = new System.Diagnostics.StackFrame(2);
            return stack.GetMethod().DeclaringType.FullName.ToString() + "." + stack.GetMethod().Name.ToString();
        }

        /// <summary>
        /// Verifica se há uma mensagem de aviso ou erro, a exibindo se necessário. Retorna verdadeiro caso não exista mensagem a ser exibida.
        /// </summary>
        /// <returns></returns>
        public static bool verificarMensagem()
        {
            if (Mensagens.mensagem != string.Empty)
            {
                janelaAviso(3);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Verifica se o campo está vazio, ou não. Retorna falso, assim como deixa o foco no campo e uma mensagem é exibida caso o campo esteja vazio.
        /// </summary>
        /// <param name="txt">Campo que será verificado.</param>
        /// <returns>Retorna verdadeiro caso o campo esteja preenchido.</returns>
        public static bool verificaCampo(TextBox txt)
        {
            if (txt.Text.Trim().Length == 0)
            {
                Mensagens.campoVazio(txt.Tag.ToString());
                janelaAviso(2);
                txt.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Verifica se o campo está vazio, ou não. Retorna falso, assim como deixa o foco no campo e uma mensagem é exibida caso o campo esteja vazio.
        /// </summary>
        /// <param name="cbx">Campo que será verificado.</param>
        /// <returns>Retorna verdadeiro caso o campo esteja preenchido.</returns>
        public static bool verificaCampo(ComboBox cbx)
        {
            if (cbx.Text.Trim().Length == 0)
            {
                Mensagens.campoVazio(cbx.Tag.ToString());
                janelaAviso(2);
                cbx.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Verifica se o campo tem caracteres suficientes. Retorna falso, assim como deixa o foco no campo e uma mensagem é exibida caso o campo esteja de forma com menos caracteres que o necessário.
        /// </summary>
        /// <param name="txt">Campo que será verificado.</param>
        /// <param name="qtdeCaracteres">Quantidade de caracteres que o campo deve ter.</param>
        /// <returns>Retorna verdadeiro caso o campo esteja preenchido com caracteres o suficiente.</returns>
        public static bool verificarTamanhoCampo(TextBox txt, int qtdeCaracteres)
        {
            if (txt.Text.Trim().Length < qtdeCaracteres)
            {
                Mensagens.campoInsuficiente(txt.Tag.ToString());
                janelaAviso(4);
                txt.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Verifica se o conteúdo do campo é inteiro. Retorna falso, assim como deixa o foco no campo e uma mensagem é exibida caso o campo não tenha somente números.
        /// </summary>
        /// <param name="txt">Campo que será verificado.</param>
        /// <returns>Retorna verdadeiro caso o campo esteja preenchido de forma correta.</returns>
        public static bool verificarCampoInteiro(TextBox txt)
        {
            int teste;
            foreach (char letra in txt.Text.Trim())
                if (!int.TryParse(letra.ToString(), out teste))
                {
                    Mensagens.campoFormatoIncorreto(txt.Tag.ToString(), "números");
                    janelaAviso(5);
                    txt.Focus();
                    return false;
                }
            return true;
        }

        /// <summary>
        /// Verifica se o conteúdo do campo é um email. Retorna falso, assim como deixa o foco no campo e uma mensagem é exibida caso o campo não tenha um email.
        /// </summary>
        /// <param name="txt">Campo que será verificado.</param>
        /// <returns>Retorna verdadeiro caso o campo esteja preenchido de forma correta.</returns>
        public static bool verificarEmail(TextBox txt)
        {
            try
            {
                var teste = new MailAddress(txt.Text);
                return true;
            }
            catch
            {
                Mensagens.campoFormatoIncorreto(txt.Tag.ToString(), "um email válido!");
                janelaAviso(5);
                txt.Focus();
                return false;
            }
        }

        /// <summary>
        /// Exibe mensagem de pergunta.
        /// </summary>
        /// <param name="tipo">Tipo da pergunta. 1 = Prosseguir.</param>
        /// <returns></returns>
        public static bool pergunta(int tipo = 1)
        {
            string caption = "Pergunta!";
            bool retorno = false;
            MessageBoxButtons botoes = MessageBoxButtons.YesNo;
            MessageBoxIcon icone = MessageBoxIcon.Question;

            if (tipo == 1)
                Mensagens.avisoProsseguir();

            if (MessageBox.Show(Mensagens.mensagem, caption, botoes, icone) == DialogResult.Yes)
                retorno = true;

            Mensagens.mensagem = string.Empty;

            return retorno;
        }

        /// <summary>
        /// Jalena padrão de avisos
        /// </summary>
        /// <param name="tipo">Indica os componentes da janela. 1 = Sucesso. 2 = Campo vazio. 3 = Falha. 4 = Campo insuficiente. 5 = Formato incorreto.</param>
        internal static void janelaAviso(int tipo)
        {
            string caption = "Aviso!";
            MessageBoxButtons botao = MessageBoxButtons.OK;
            MessageBoxIcon icone = MessageBoxIcon.Exclamation;

            if (tipo == 1)
            {
                caption = "Sucesso!";
                icone = MessageBoxIcon.Information;
            }
            else if (tipo == 2)
                caption = "Campo vazio!";
            else if (tipo == 3)
            {
                caption = "Erro!";
                icone = MessageBoxIcon.Hand;
            }
            else if (tipo == 4)
                caption = "Campo insuficiente!";
            else if (tipo == 5)
                caption = "Formato incorreto!";

            MessageBox.Show(Mensagens.mensagem, caption, botao, icone);
            Mensagens.mensagem = string.Empty;
        }

        /// <summary>
        /// Converte uma string para um PictureBoxSizeMode que é usado no ajuste da imagem no PictureBox.
        /// </summary>
        /// <param name="pic">String que contém o tipo de ajuste que será convertido.</param>
        /// <returns>Retorna um PictureBoxSizeMode correspondente a string passada, ou PictureBoxSizeMode.StretchImage caso não consiga converter.</returns>
        public static PictureBoxSizeMode converteStringParaPictureBoxSizeMode(string pic)
        {
            if (pic.ToLower() == "PictureBoxSizeMode.Normal".ToLower())
                return PictureBoxSizeMode.Normal;
            else if (pic.ToLower() == "PictureBoxSizeMode.StretchImage".ToLower())
                return PictureBoxSizeMode.StretchImage;
            else if (pic.ToLower() == "PictureBoxSizeMode.AutoSize".ToLower())
                return PictureBoxSizeMode.AutoSize;
            else if (pic.ToLower() == "PictureBoxSizeMode.CenterImage".ToLower())
                return PictureBoxSizeMode.CenterImage;
            else if (pic.ToLower() == "PictureBoxSizeMode.Zoom".ToLower())
                return PictureBoxSizeMode.Zoom;
            else
                return PictureBoxSizeMode.StretchImage;
        }

        /// <summary>
        /// Exibe a tela de splash.
        /// </summary>
        public static void exibirSplashScreen()
        {
            fechaSplashScreen = false;
            Thread thread = new Thread(new ThreadStart(mostrarSplashScreen));
            thread.Start();
        }

        /// <summary>
        /// Usado para a thread da tela de splash
        /// </summary>
        private static void mostrarSplashScreen()
        {
            frmSplash splashScreen = new frmSplash();
            splashScreen.Show();
            while (!fechaSplashScreen)
            {
                splashScreen.atualizarTexto(textoSplashScreen);
                Application.DoEvents();
            }
            splashScreen.Close();
            splashScreen.Dispose();
        }

        /// <summary>
        /// Muda o texto exibido na tela de splash. Padrão de "Atualizando..."
        /// </summary>
        /// <param name="texto">Texto usado na tela de splash.</param>
        public static void mudarTextoSplashScreen(string texto = "Atualizando...")
        {
            textoSplashScreen = texto;
        }

        /// <summary>
        /// Fecha a tela de splash
        /// </summary>
        public static void fecharSplashScreen()
        {
            fechaSplashScreen = true;
        }
    }
}