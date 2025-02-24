using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TopGol.Models;
using TopGol.Properties;

namespace TopGol.PAGES
{
    public partial class configuracao : FormsParent
    {
        ModuloDesktopEntities ct = new ModuloDesktopEntities();
        public configuracao()
        {
            InitializeComponent();
            checkBox1.Checked = dados.atual.RecebeNotificacao.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Settings() { lembrar = string.Empty }.Save();
            "Senha limpada com sucesso, feche o sistema para logar novamente".info();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           // if (checkBox1.Checked) 
            var user = ct.Usuarios.FirstOrDefault(u=> u.IdUsuario == dados.atual.IdUsuario);
            user.RecebeNotificacao = checkBox1.Checked;
            ct.SaveChanges();
            dados.atual = user;

        }
    }
}
