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

namespace TopGol.PAGES.autenticacao
{
    public partial class telaBase : Form
    {
        ModuloDesktopEntities ct = new ModuloDesktopEntities();
        private Queue<Notificacao> filaNotificacoes = new Queue<Notificacao>();

        public telaBase()
        {
            InitializeComponent();
            pictureBox1.Image = dados.atual.Foto != null ? Image.FromStream(new MemoryStream(dados.atual.Foto)) : Properties.Resources.SemFoto;
        }
        private void telaBase_Load(object sender, EventArgs e)
        {
            showTelas(new telaConvidados());

            notifyIcon1.Icon = SystemIcons.Information;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipTitle = "Você tem notificações";

            if (!dados.atual.RecebeNotificacao.Value) return;

            var notificacoes = ct.Notificacao
                .Where(u => u.idusuario == dados.atual.IdUsuario && u.status == "p")
                .OrderBy(n => n.dataHora)
                .ToList();

            foreach (var item in notificacoes) filaNotificacoes.Enqueue(item);
            MostrarProximaNotificacao();
        }

        private void MostrarProximaNotificacao()
        {
            if (filaNotificacoes.Count == 0)
            {
                notifyIcon1.Visible = false; 
                return;
            }

            var notificacao = filaNotificacoes.Peek();
            notifyIcon1.BalloonTipText = notificacao.notificacao1;
            notifyIcon1.ShowBalloonTip(2000); 
        }
        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            if (filaNotificacoes.Count == 0) return;

            var notificacao = filaNotificacoes.Dequeue();
            using (var context = new ModuloDesktopEntities())
            {
                var notif = context.Notificacao.FirstOrDefault(n => n.id == notificacao.id);
                if (notif != null)
                {
                    notif.status = "l";
                    context.SaveChanges();
                }
            }

            new telaDetalhesNotificacao(notificacao).ShowDialog();
            MostrarProximaNotificacao();
        }
        private void notifyIcon1_BalloonTipClosed(object sender, EventArgs e)
        {
            if (filaNotificacoes.Count == 0) return;

            filaNotificacoes.Dequeue();// Remove a notificação da fila se fechada ou ignorada
            MostrarProximaNotificacao();

        }


        #region Navegação de telas
        private void showTelas(Form tela)
        {
            panel1.Controls.Clear();
            tela.Dock = DockStyle.Fill;
            tela.TopLevel = false;
            tela.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(tela);
            tela.Show();
        }
        private void conToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showTelas(new telaConvidados());

        }

        private void jogosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showTelas(new telaJogos());

        }

        private void rankingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showTelas(new telaRanking());

        }

        private void notificacõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showTelas(new telaNotificacoes());

        }

        private void configuraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showTelas(new configuracao());

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new editarPerfil() { parent = this}.ShowDialog();
            this.Refresh();
        }

        public void recarregar()
        {
            pictureBox1.Image = dados.atual.Foto != null ? Image.FromStream(new MemoryStream(dados.atual.Foto)) : Properties.Resources.SemFoto;

        }


        #endregion


    }
}
