using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TopGol.Models;

namespace TopGol.PAGES.autenticacao
{
    public partial class redefinir : FormsParent
    {
        public redefinir()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ct = new ModuloDesktopEntities();
            var user = ct.Usuarios.FirstOrDefault(u => u.Email == dados.atual.Email);
            user.Senha = textBox1.Text;
            ct.SaveChanges();
            "Senha gravda com sucesso".info();

            new login().Show();
            Hide();
        }
    }
}
