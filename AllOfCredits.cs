using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bll;
using Be;

namespace gym
{
    
    public partial class AllOfCredits : Form
    {
        BusinessLogic bll = new BusinessLogic();
        public AllOfCredits()
        {
            InitializeComponent();
            getAddCredit();
        }
        void getAddCredit()
        {
            var q = from i in bll.readAll() select new { i.id, i.name, i.family, i.codeMelli, i.fatherName, i.age, i.date, i.time, i.phone };

            dataGridViewX1.DataSource = q.ToList();
            
            dataGridViewX1.Columns[0].HeaderText = "ردیف";
            dataGridViewX1.Columns[1].HeaderText = "نام";
            dataGridViewX1.Columns[2].HeaderText = "نام خانوادگی";
            dataGridViewX1.Columns[3].HeaderText = "کد ملی";
            dataGridViewX1.Columns[4].HeaderText = "نام پدر";
            dataGridViewX1.Columns[5].HeaderText = "سن";
            dataGridViewX1.Columns[6].HeaderText = "تاریخ ثبت نام";
            dataGridViewX1.Columns[7].HeaderText = "زمان ثبت نام";
            dataGridViewX1.Columns[8].HeaderText = "شماره تماس";
            
        }
    }
}
