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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace TopGol.PAGES.autenticacao
{
    public partial class cadastro : FormsParent
    {

        dbTopGolEntities ct = new dbTopGolEntities();
        public MemoryStream ms { get; set; } = new MemoryStream();
        public string cor { get; set; }
        public string time { get; set; }
        public cadastro(string email)
        {
            InitializeComponent();
            textBox1.Text = email;
            textBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileName != null)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (verificacao() == "ok")
            {
                var user = ct.Usuarios.FirstOrDefault(u => u.Email == textBox1.Text);
                user.Senha = textBox2.Text;
                user.apelido = textBox3.Text;
                user.corFavorita = textBox4.Text;
                user.timeFavorito = textBox5.Text;
                user.nascimento = dateTimePicker1.Value;
                user.Foto = pictureBox1.Image != null ? ms.ToArray() : null;
                user.DataCadastro = DateTime.Now;
                user.RecebeNotificacao = false;
                ct.SaveChanges();

                "Dados cadastrados com sucesso".info();
                dados.atual = user;
                new telaBase().Show();
            }
            else
            {
                verificacao().Alerta();
            }
        }

        public string verificacao()
        {
            if (string.IsNullOrEmpty(textBox2.Text) && string.IsNullOrEmpty(textBox3.Text) &&
                    !string.IsNullOrEmpty(textBox4.Text) && string.IsNullOrEmpty(textBox5.Text))
                return "Preencha todos os campos";

            if (dateTimePicker1.Value == DateTime.Now)
                return "Preencha corretamente o ano do seu nascimento";

            if (ct.Usuarios.FirstOrDefault(u => u.apelido == textBox3.Text) != null)
                return "Este apelido já está em uso. Escolha outro.";

            return "ok";
        }
    }
}
