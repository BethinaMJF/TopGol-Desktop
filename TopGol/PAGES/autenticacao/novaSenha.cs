using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopGol.PAGES.autenticacao
{
    public partial class novaSenha : FormsParent
    {
        public novaSenha()
        {
            InitializeComponent();


            var random = new Random();
            var parte1 = "QWERTYUIOPASDFGHJKLZXCVBNM"[random.Next(26)].ToString() + "QWERTYUIOPASDFGHJKLZXCVBNM"[random.Next(26)].ToString();
            var parte2 = "qwertyuiopasdfghjklzxcvbnm"[random.Next(26)].ToString() + "qwertyuiopasdfghjklzxcvbnm"[random.Next(26)].ToString() ;
            var parte3 = "1234657890"[random.Next(10)].ToString() + "1234657890"[random.Next(10)].ToString();

            textBox1.Text = parte1 + parte2 + parte3;
            textBox1.Enabled = false;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
            new login() { senha = textBox1.Text}.Show();
            Hide();
        }

        private void novaSenha_Load(object sender, EventArgs e)
        {

        }
    }
}
