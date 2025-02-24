using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TopGol.PAGES.autenticacao;
using TopGol.Properties;

namespace TopGol
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var config = new Settings();
            if (config.lembrar != "")
            {
                Models. dados.atual = new Models.ModuloDesktopEntities().Usuarios.FirstOrDefault(x => x.Email == config.lembrar);
                Application.Run(new telaBase());

            }
            else
            {
                 Application.Run(new telaAutenticacao());

            }
        }

    }

    public static class Messagens
    {
        public static DialogResult Alerta(this string texto)
        {
            return MessageBox.Show(texto, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DialogResult info(this string texto)
        {
            return MessageBox.Show(texto, "Informa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
