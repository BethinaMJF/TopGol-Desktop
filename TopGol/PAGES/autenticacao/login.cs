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
using System.Timers;

namespace TopGol.PAGES.autenticacao
{
    public partial class login : FormsParent
    {
        ModuloDesktopEntities ct = new ModuloDesktopEntities();
        public string senha { get; set; }

        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (senha != null)
            {
                if (textBox2.Text == senha)
                {
                    timer1.Stop();
                    new redefinir().Show();
                    Hide();
                }
                else
                {
                    "Senha incorreta".Alerta();

                }
            }
            else
            {
                var user = ct.Usuarios.FirstOrDefault(u => u.Email == textBox1.Text && u.Senha == textBox2.Text);
                if (user != null)
                {
                    "Bem vindo".info();

                    if (checkBox1.Checked)
                        new Settings() { lembrar = textBox1.Text }.Save();

                    dados.atual = user;
                    new telaBase().Show();
                    Hide();
                }
                else
                {
                    "Senha incorreta".Alerta();
                }

            }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new esqueciSenha().Show();
            Hide();
        }
        public int segundos { get; set; } = 10;
        private void login_Load(object sender, EventArgs e)
        {
            if (senha != null)
            {
                timer1.Start();
                linkLabel1.Visible = false;
                button2.Visible = true;
                panel1.Visible = true;
            }
          
            textBox1.Text = dados.atual.Email;
            textBox1.Enabled = false;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (segundos > 0)
            {
                segundos--;
                label4.Text = $"A senha expira em {segundos} segundos";
                if (label5.Text.Length > 0)
                {
                    label5.Text = label5.Text.Remove(label5.Text.Length - 2, 2);  
                }

            }
            else
            {
                timer1.Stop();
                "Senha de recuperação expirou".Alerta();
                new login().Show();
                Hide() ;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = Clipboard.GetText();
            if (senha == textBox2.Text)
            {

            }
            else
            {
                timer1.Stop();
                linkLabel1 .Visible = true;
                panel1.Visible = false ;
                button2.Visible = false ;
            }

        }
    }
}
