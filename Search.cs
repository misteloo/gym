using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Be;
using Bll;

namespace gym
{
    public partial class Search : Form
    {
        BusinessLogic bll = new BusinessLogic();
        public Search()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var q = bll.readd(textBox1.Text);
            //var qq = from i in q  select new { i.beAddAthlete.name,i.beAddAthlete.family , i.id, i.cash, i.debt, i.expireDay, i.time };
            dataGridViewX1.DataSource = q;
            
            dataGridViewX1.Columns[0].HeaderText = "اسم";
            dataGridViewX1.Columns[1].HeaderText = "فامیل";
            dataGridViewX1.Columns[2].HeaderText = "نقد";
            dataGridViewX1.Columns[3].HeaderText = "بدهی";
            dataGridViewX1.Columns[4].HeaderText = "تاریخ";
            dataGridViewX1.Columns[5].HeaderText = "تاریخ اتمام اشتراک";
            dataGridViewX1.Columns[6].HeaderText = "زمان";
            dataGridViewX1.Columns[7].HeaderText = "جزئیات";


        }
    }
}
