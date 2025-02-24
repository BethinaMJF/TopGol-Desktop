using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TopGol.Models;

namespace TopGol.Controls
{
    public partial class controlConvidado : UserControl
    {
        public Usuarios atual { get; set; }
        public controlConvidado(Usuarios user)
        {
            InitializeComponent();

            circular1.Image = user.Foto != null ? Image.FromStream(new MemoryStream(user.Foto)) : Properties.Resources.SemFoto;
            label1.Text = user.Email;
            label3.Text = string.IsNullOrWhiteSpace(user.apelido) ? "Apelido não cadastrado" : user.apelido;
            if (user.DataCadastro != null)
            {
                label2.Text = "Cadastrado";
            }
            else
            {

                label2.Text = "Pendente";
                label2.BackColor = Color.Yellow;

                if ((DateTime.Now - user.DataConvite).TotalDays >= 30)
                {
                    label2.Text = "Expirado";
                    label2.BackColor = Color.Red;
                }
            }
            
            atual = user;
        }

        private void controlConvidado_MouseMove(object sender, MouseEventArgs e)
        {
            if (atual.DataCadastro != null)
            {
                string diasCadastro = (DateTime.Now - atual.DataCadastro.Value).Days + " dias de cadastro";
                toolTip1.Show(diasCadastro, this, 2000);
            }
        }
    }
}
