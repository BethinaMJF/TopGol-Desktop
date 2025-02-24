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
    public partial class telaJogos : FormsParent
    {
        public ModuloDesktopEntities ct = new ModuloDesktopEntities();

        public telaJogos()
        {
            InitializeComponent();

            comboBox1.Items.AddRange(ct.Competicao.Select(x => x.Ano.ToString()).ToArray());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            var jogos = ct.Jogos.Where(u => u.Data.Value.Year.ToString() == comboBox1.Text).ToList();
            foreach (var jogo in jogos)
            {
                var competicao = ct.Competicao.FirstOrDefault(u => u.IdCompeticao == jogo.idCompeticao);
                label1.Text = $"{competicao.Ano} / {competicao.Local}";

                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);

                row.Cells[0].Value = jogo.Data.Value.ToString("dd/mm/yyyy");
                row.Cells[1].Value = jogo.Data.Value.ToString("hh:mm");
                row.Cells[2].Value = ct.Selecao.FirstOrDefault(U => U.IdSelecao == jogo.Selecao1).Nome;
                row.Cells[3].Value = jogo.Placar1.Value;
                row.Cells[5].Value = jogo.Placar2.Value;
                row.Cells[6].Value = ct.Selecao.FirstOrDefault(U => U.IdSelecao == jogo.Selecao2).Nome;

                dataGridView1.Rows.Add(row);
                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);

                if (jogo.Placar1 > jogo.Placar2)
                {
                    row.Cells[2].Style.ForeColor = Color.Green;
                }
                else if (jogo.Placar1 < jogo.Placar2)
                {
                    row.Cells[6].Style.ForeColor = Color.Green;
                }
                else if (jogo.Placar1 == jogo.Placar2)
                {
                    row.Cells[2].Style.BackColor = Color.LightYellow;
                    row.Cells[6].Style.BackColor = Color.LightYellow;

                }
            }
        }

        private void telaJogos_Load(object sender, EventArgs e)
        {


        }
    }
}
