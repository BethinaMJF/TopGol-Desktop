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
    public partial class telaNotificacoes : FormsParent
    {
        ModuloDesktopEntities ct = new ModuloDesktopEntities();
        public telaNotificacoes()
        {
            InitializeComponent();
            carregar();
        }

        private void carregar()
        {
            dataGridView1.Rows.Clear();
            var notificacoes = ct.Notificacao.Where(u => u.idusuario == dados.atual.IdUsuario).ToList();
            foreach (var item in notificacoes)
            {
                var row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                row.Cells[0].Value = item.id;
                row.Cells[1].Value = item.dataHora.ToShortDateString();
                row.Cells[2].Value = item.dataHora.ToShortTimeString();
                row.Cells[3].Value = item.notificacao1;
                row.Cells[4].Value = item.notificacao1;
                row.Cells[5].Value = item.status;

                dataGridView1.Rows.Add(row);
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id = dataGridView1[0, e.RowIndex];
            var notificacao = ct.Notificacao.FirstOrDefault(u=> u.id == (int)(id.Value));
            if (notificacao.status == "p")
            {
                notificacao.status = "l";
                ct.SaveChanges();
            }
            carregar();

            
        }

    }
}
