using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TopGol.Models;

namespace TopGol.PAGES
{
    public partial class telaRanking : FormsParent
    {
        private ModuloDesktopEntities ct = new ModuloDesktopEntities();

        public telaRanking()
        {
            InitializeComponent();
            comboBox1.DataSource = ct.Competicao.Select(x => x.Ano).ToList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            int anoSelecionado = int.Parse(comboBox1.SelectedItem.ToString());
            var jogos = ct.Jogos.Where(j => j.Competicao.Ano == anoSelecionado).ToList();
            CalcularResultados(jogos);
        }

        public void CalcularResultados(List<Jogos> jogos)
        {
            List<SelecaoResultado> selecoes = new List<SelecaoResultado>();

            foreach (var jogo in jogos)
            {
                // Para a Seleção 1
                AdicionarResultado(selecoes, jogo.Selecao1.Value, jogo.Placar1.Value, jogo.Placar2.Value);
                // Para a Seleção 2
                AdicionarResultado(selecoes, jogo.Selecao2.Value, jogo.Placar2.Value, jogo.Placar1.Value);
            }
           
            foreach (var item in selecoes.OrderByDescending(s => s.Pontos))
            {
                dataGridView1.Rows.Add(item.Nome, item.bandeira , item.Pontos, item.PartidasJogadas, item.Vitorias, item.Empates, item.Derrotas, item.GolsFeitos, item.GolsSofridos);
            }

        }

        public void AdicionarResultado(List<SelecaoResultado> selecoes, int idSelecao, int golsFeitos, int golsSofridos)
        {
            var selecao = selecoes.FirstOrDefault(s => s.IdSelecao == idSelecao);

            if (selecao == null)
            {
                var bandeira = (ct.Selecao.FirstOrDefault(u => u.IdSelecao == idSelecao));
                Image imagem = bandeira.Bandeira != null ? Image.FromStream(new MemoryStream(bandeira.Bandeira)) :  Properties.Resources.SemFoto;
                selecao = new SelecaoResultado { IdSelecao = idSelecao, Nome = ct.Selecao.FirstOrDefault(u=> u.IdSelecao == idSelecao).Nome, bandeira = (imagem)  };
                selecoes.Add(selecao);
            }

            // Atualiza os dados
            selecao.GolsFeitos += golsFeitos;
            selecao.GolsSofridos += golsSofridos;

            if (golsFeitos > golsSofridos)
            {
                selecao.Pontos += 3; // Vitória
                selecao.Vitorias += 1;
            }
            else if (golsFeitos == golsSofridos)
            {
                selecao.Pontos += 1; // Empate
                selecao.Empates += 1;
            }
            else
            {
                selecao.Derrotas += 1; // Derrota
            }

            selecao.PartidasJogadas += 1;

            selecao.bandeira = selecao.bandeira != null ? selecao.bandeira : Properties.Resources.SemFoto;
        }


        public class SelecaoResultado
        {
            public int IdSelecao { get; set; }
            public Image bandeira { get; set; }
            public string Nome { get; set; }
            public int GolsFeitos { get; set; }
            public int GolsSofridos { get; set; }
            public int Pontos { get; set; }
            public int Vitorias { get; set; }
            public int Empates { get; set; }
            public int Derrotas { get; set; }
            public int PartidasJogadas { get; set; }
        }
    }
}
