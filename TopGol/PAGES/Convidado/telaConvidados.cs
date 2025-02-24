using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TopGol.Controls;
using TopGol.Models;

namespace TopGol.PAGES
{
    public partial class telaConvidados : FormsParent
    {
        ModuloDesktopEntities ct = new ModuloDesktopEntities();

        public telaConvidados()
        {
            InitializeComponent();
            recaregar();
        }
        public void recaregar()
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var item in ct.Usuarios.Where(u => u.idIndicado == dados.atual.IdUsuario).OrderBy(u => u.Email))
            {
                flowLayoutPanel1.Controls.Add(new Controls.controlConvidado(item));
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();

            var lista = string.IsNullOrEmpty(textBox1.Text) == false ?
                ct.Usuarios.Where(u => u.idIndicado == dados.atual.IdUsuario && u.Email.ToLower().Contains(textBox1.Text) || u.apelido.ToLower().Contains(textBox1.Text))
                : ct.Usuarios.Where(u => u.idIndicado == dados.atual.IdUsuario).OrderBy(u => u.Email);

            foreach (var item in lista)
            {
                flowLayoutPanel1.Controls.Add(new controlConvidado(item));
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new novoConvidado() { parent = this}.ShowDialog();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var limiteData = DateTime.Now.AddDays(-30);
            var lista = ct.Usuarios.Where(u => u.idIndicado == dados.atual.IdUsuario && u.DataConvite <= limiteData);
            if (lista.Count() > 0)
            {
                foreach (var item in lista)
                {
                    item.DataConvite = DateTime.Now;
                }
                ct.SaveChanges();
            }
            recaregar();
        }
    }
}
