using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using threed.DataManage;

namespace threed
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormImport frm = new FormImport();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormQuery f = new FormQuery();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormGap f = new FormGap();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormSum f = new FormSum();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormProduceNumber f = new FormProduceNumber();
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormCustomGroup f = new FormCustomGroup();
            f.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormCustomGroupByMe f = new FormCustomGroupByMe();
            f.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FormAnalyseNumber f = new FormAnalyseNumber(); f.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FormCompoundAnalyse f = new FormCompoundAnalyse();
            f.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            大中小 f = new 大中小();
            f.Show();
        }
    }
}
