using System.Windows.Forms;

namespace UTIL
{
    internal partial class frmSplash : Form
    {
        private delegate void ProgressDelegate(string mensagem);
        private ProgressDelegate del;

        internal frmSplash()
        {
            InitializeComponent();
            del = this.atualizarTextoInterno;
        }

        private void atualizarTextoInterno(string mensagem)
        {
            if (this.Handle == null)
            {
                return;
            }
            this.lblAtual.Text = mensagem;
        }

        internal void atualizarTexto(string mensagem = "Atualizando...")
        {
            this.Invoke(del, mensagem);
        }
    }
}
