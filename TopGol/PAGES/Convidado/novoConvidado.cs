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

namespace TopGol.PAGES
{
    public partial class novoConvidado : FormsParent
    {
        ModuloDesktopEntities ct = new ModuloDesktopEntities();
        public telaConvidados parent { get; set; }
        public novoConvidado()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ct.Usuarios.FirstOrDefault(u => u.Email == textBox1.Text) == null)
            {
                var user = new Usuarios()
                {
                    Email = textBox1.Text,
                    DataConvite = DateTime.Now,
                    idIndicado = dados.atual.IdUsuario,
                };

                ct.Usuarios.Add(user);
                ct.SaveChanges();

                "Email cadastrado com sucesso".info();
                parent.recaregar();
                this.Close();

            }
            else
            {
                "Email ja cadastrado".Alerta();
            }
        }
    }
}
