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
using TopGol.PAGES.autenticacao;
using TopGol.PAGES;

namespace TopGol
{
    public partial class telaAutenticacao : FormsParent
    {
        ModuloDesktopEntities ct = new ModuloDesktopEntities();
        public telaAutenticacao()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var user = ct.Usuarios.FirstOrDefault(u => u.Email == textBox1.Text);
            if (user != null)
            {
                if (user.DataCadastro != null)
                {
                    dados.atual = ct.Usuarios.FirstOrDefault(u => u.Email == textBox1.Text);
                    new PAGES.autenticacao.login().Show();
                    Hide();
                }
                else
                {
                    if ((DateTime.Now - user.DataConvite).TotalDays < 30)
                    {
                        new PAGES.autenticacao.cadastro(textBox1.Text).Show();
                        Hide();
                    }
                    else
                    {
                        "Data de convite vencida".Alerta();
                        var notificacao = new Notificacao();
                        notificacao.dataHora = DateTime.Now;
                        notificacao.notificacao1 = $"Usuário {user.Email} está com data expirada. Favor revalidar";
                        notificacao.idusuario = (int)user.idIndicado; // id estava errado 
                        notificacao.status = "p";                   // nao salvava no banco pq nao adicionei o campo status                                 
                        ct.Notificacao.Add(notificacao);
                        ct.SaveChanges();
                        "Pedido de renovacao foi enviado ao usuario responsavel pelo convite".info();
                    }
                }
            }
            else
            {
                "Email não cadastrado".Alerta();
            }
        }
    }
}
