using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TopGol.Models;
using TopGol.PAGES.autenticacao;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace TopGol.PAGES
{
    public partial class editarPerfil : FormsParent
    {

        dbTopGolEntities ct = new dbTopGolEntities();
        public string cor { get; set; }
        public string time { get; set; }
        public MemoryStream ms { get; set; } = new MemoryStream();
        public telaBase parent { get; set; }

        public editarPerfil()
        {
            InitializeComponent();

            textBox1.ReadOnly = true;
            textBox1.Text = dados.atual.Email;
            textBox2.Text = dados.atual.Senha;
            textBox3.Text = dados.atual.apelido;
            textBox4.Text = dados.atual.corFavorita;
            textBox5.Text = dados.atual.timeFavorito;
            dateTimePicker1.Value = (DateTime)dados.atual.nascimento;

            if (dados.atual.Foto != null)
            {
                pictureBox1.Image = Image.FromStream(new MemoryStream(dados.atual.Foto));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var user = ct.Usuarios.FirstOrDefault(u => u.Email == textBox1.Text);
            user.Senha = textBox2.Text;
            user.apelido = textBox3.Text;
            user.corFavorita = textBox4.Text;
            user.timeFavorito = textBox5.Text;
            user.nascimento = dateTimePicker1.Value;

            if (pictureBox1.Image != null)
            {
                var novaImagem = ms.ToArray();
                if (!novaImagem.SequenceEqual(user.Foto ?? new byte[0])) // Verifica se a imagem mudou
                {
                    user.Foto = novaImagem;
                }
            }
            else
            {
                user.Foto = null;
            }


            ct.SaveChanges();
            dados.atual = user;
            parent.recarregar();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileName != null)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                ms =  new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            var lista = ct.Usuarios.Where(u => u.corFavorita.ToLower().Contains(textBox4.Text.ToLower()));
            var corEncontrada = ct.Usuarios
                            .Where(u => u.corFavorita.ToLower().Contains(textBox4.Text.ToLower()))
                            .Select(u => u.corFavorita)
                            .FirstOrDefault();

            label8.Visible = textBox4.Text.Length >= 2 && corEncontrada != null;
            label8.Text = cor = corEncontrada ?? "";

        }
        private void label8_Click(object sender, EventArgs e)
        {
            textBox4.Text = cor;
            label8.Visible = false;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            var timeEncontrado = ct.Selecao
                               .Where(u => u.Nome.ToLower().Contains(textBox5.Text.ToLower()))
                               .Select(u => u.Nome)
                               .FirstOrDefault();

            label9.Visible = textBox5.Text.Length >= 2 && timeEncontrado != null;
            label9.Text = time = timeEncontrado ?? "";
        }
        private void label9_Click(object sender, EventArgs e)
        {
            textBox5.Text = time;
            label9.Visible = false;
        }


    }
}
