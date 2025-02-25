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

namespace TopGol.PAGES.autenticacao
{
    public partial class esqueciSenha : FormsParent
    {

        dbTopGolEntities ct = new dbTopGolEntities();
        List<Pergunta> listaPerguntas = new List<Pergunta>();
        public TextBox textBox { get; set; }
        public DateTimePicker dateTimePicker { get; set; } = new DateTimePicker() { Format = DateTimePickerFormat.Short };
        public int indexPergunta { get; set; } = 0;
        public Pergunta perguntaAtual { get; set; }

        public esqueciSenha()
        {
            InitializeComponent();
            textBox = new TextBox() { Width = panel1.Width};
            foreach (var item in ct.Pergunta)
            {
                listaPerguntas.Add(item);
            }
            carregarPergunta();
        }

        private void carregarPergunta()
        {
            panel1.Controls.Clear();

            if (indexPergunta < listaPerguntas.Count)
            {
                perguntaAtual = listaPerguntas[indexPergunta];
                label1.Text = perguntaAtual.pergunta1;
                if (perguntaAtual.tipo == "data")
                {
                    panel1.Controls.Add(dateTimePicker);
                }
                else
                {
                    panel1.Controls.Add(textBox);
                }

            }
            else
            {
                MessageBox.Show("Respostas incorretas!", "Recuperar Senha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                new login().Show();
                Hide();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            indexPergunta++;

            if (perguntaAtual.tipo == "data" )
            {
                if (dateTimePicker.Value.ToShortDateString() == dados.atual.nascimento.Value.ToShortDateString())
                {
                    new novaSenha().Show();
                    Hide(); 
                }
                else
                {
                    MessageBox.Show("Resposta incorreta!", "Recuperar Senha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    carregarPergunta();
                }
            }
            else
            {
                var resposta = typeof(Usuarios).GetProperty(perguntaAtual.campo)?.GetValue(dados.atual); // Resgata valor da Propriedade (Tabela/Atributo) definido no GerProperty
                if ( textBox.Text.ToLower().Trim() == resposta.ToString().ToLower().Trim())
                {
                    new novaSenha().Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Resposta incorreta!", "Recuperar Senha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    carregarPergunta();
                }
            }

        }
    }
}
