using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eşleştirme_oyunu1
{
    public partial class Form1 : Form
    {
        Label resim_1 = null;
        Label resim_2 = null;
        Random rastgele = new Random();
        List<string> resimler = new List<string>()
        {
            "A","A","B","B","C","C","D","D","E","E","F","F","G","G","H","H","I","I","İ","İ","J","J","K","K","L","L","M","M","N","N","O","O","Ö","Ö","P","P"
        };
        private void resim_goster()
        {
            foreach (Control etiket in tableLayoutPanel1.Controls)
            {
                Label resimetiket = etiket as Label;
                if (resimetiket != null)
                {
                    int rs = rastgele.Next(resimler.Count);
                    resimetiket.Text = resimler[rs];
                    resimetiket.ForeColor = resimetiket.BackColor;
                    resimler.RemoveAt(rs);
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            resim_goster();
        }

        private void label_tıklama(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                return;
            }
            Label secılen_resim = sender as Label;
            if (secılen_resim != null)
            {
                if (secılen_resim.ForeColor == Color.Black)
                {
                    return;
                }
                if (resim_1 == null)
                {
                    resim_1 = secılen_resim;
                    resim_1.ForeColor = Color.Black;
                    return;
                }
                resim_2 = secılen_resim;
                resim_2.ForeColor = Color.Black;
                oyun_bittimi();
                if (resim_1.Text == resim_2.Text)
                {
                    resim_1 = null;
                    resim_2 = null;
                    return;
                }
                timer1.Start();

            }
        }
        private void oyun_bittimi()
        {
            foreach (Control etk in tableLayoutPanel1.Controls)
            {
                Label resetk = etk as Label;
                if (resetk != null)
                {
                    if (resetk.ForeColor == resetk.BackColor)
                    {
                        return;
                    }
                }
            }
            MessageBox.Show("Oyun Bitti");
            Close();
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            timer1.Stop();
            resim_1.ForeColor = resim_1.BackColor;
            resim_2.ForeColor = resim_2.BackColor;
            resim_1 = null;
            resim_2 = null;
        }
    }
}
