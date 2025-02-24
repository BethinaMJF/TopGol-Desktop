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
    public partial class telaDetalhesNotificacao : FormsParent
    {
        public telaDetalhesNotificacao(Notificacao notificacao)
        {
            InitializeComponent();
            label1.Text = notificacao.dataHora.ToLongDateString();
            label2.Text = notificacao.notificacao1;
        }
    }
}
