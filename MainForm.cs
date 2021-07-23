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
    public partial class MainForm : Form
    {
        BusinessLogic businessLogic = new BusinessLogic();
        public static string projectDate;
        
        public MainForm()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Equals("") || txtFamily.Text.Equals("") || txtCost.Text.Equals(""))
            {
                errorProvider1.SetError(btnDailyRegister,"لطفا مقادیر را وارد کنید");
            }
            else
            {
                daily daily = new daily();
                daily.name = txtName.Text;
                daily.family = txtFamily.Text;
                daily.cost = Int32.Parse(txtCost.Text);
                daily.date = txtShowDate.Text;
                daily.timeIn = txtShowTime.Text;
                daily.timeOut = "نا مشخص";
                var q = businessLogic.daily(daily, projectDate);
                var qq = from i in q select new  { i.id, i.name, i.family, i.timeIn, i.timeOut };
                dataGridViewX1.DataSource = qq.ToList();
                errorProvider1.Dispose();
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            watch.Enabled = true;
            showDate();
            showExpireList(projectDate);
            showDailyList(projectDate);

        }

        private void watch_Tick(object sender, EventArgs e)
        {
            
            txtShowTime.Text = DateTime.Now.ToString("HH:mm:ss");
            

        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space 
                || e.KeyChar == (char)Keys.Right || e.KeyChar == (char)Keys.Left))
            {
                e.Handled = true;
                                
            }

        }

        private void txtFamily_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled == (char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Space ||
                e.KeyChar == (char)Keys.Right || e.KeyChar == (char)Keys.Left))
            {
                e.Handled = true;
            }
        }

        private void txtCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled == (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

       
        void showDate()
        {
            
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            
            string todayDate = p.GetYear(DateTime.Now)+"/"+ p.GetMonth(DateTime.Now) + "/"+p.GetDayOfMonth(DateTime.Now);
            DateTime dt = Convert.ToDateTime(todayDate);
            string dtNewForm = dt.ToString("yyyy/MM/dd");

            projectDate = dtNewForm;
            txtShowDate.Text = projectDate;
        }


        private void buttonX1_Click(object sender, EventArgs e)
        {
            buttonX1.Location = new Point(986, 461);

            groupPanel1.Size = new Size(8,8);
            groupPanel1.Location = new Point(8, 8);

            buttonX1.Symbol = "\uf053";


        }

        

        private void buttonX1_MouseHover(object sender, EventArgs e)
        {
            buttonX1.Location = new Point(915, 461);
            

            groupPanel1.Size = new Size(255, 177);
            groupPanel1.Location = new Point(770, 73);
            buttonX1.Symbol = "\uf054";

            
        }

        

        private void btnRegister_Click(object sender, EventArgs e)
        {
            CreditForm form2 = new CreditForm(projectDate,dataGridViewX2);
            
            form2.ShowDialog();
            
        }
        public void showExpireList(string date)
        {
            var q = businessLogic.Read(projectDate);
            var qq = from i in q select new { i.id, i.beAddAthlete.name, i.beAddAthlete.family, i.beAddAthlete.phone , i.expireDay};

            dataGridViewX2.DataSource = qq.ToList();
            dataGridViewX2.Columns[0].HeaderText = "ردیف";
            dataGridViewX2.Columns[1].HeaderText = "نام";
            dataGridViewX2.Columns[2].HeaderText = "نام خانوادگی";
            dataGridViewX2.Columns[3].HeaderText = "همراه";
            dataGridViewX2.Columns[4].HeaderText = "اتمام اشتراک";
        }

        void showDailyList(string todayDate)
        {
            var q = businessLogic.daily(todayDate);
            var qq = from i in q select new { i.id, i.name, i.family, i.timeIn, i.timeOut };

            dataGridViewX1.DataSource = qq.ToList();
            dataGridViewX1.Columns[0].HeaderText = "ردیف";
            dataGridViewX1.Columns[1].HeaderText = "اسم";
            dataGridViewX1.Columns[2].HeaderText = "فامیل";
            dataGridViewX1.Columns[3].HeaderText = "زمان ورود";
            dataGridViewX1.Columns[4].HeaderText = "زمان خروج";
            
        }

        private void ارسالپیاموانتقالبهلیستمعوقهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridViewX2.Rows[dataGridViewX2.CurrentRow.Index].Cells[0].Value);
            businessLogic.updateIsCredit(id);
            showExpireList(projectDate);
        }

        private void ثبتخروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells[0].Value);
            businessLogic.daily(id,txtShowTime.Text);
            showDailyList(projectDate);

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search s = new Search();
            s.ShowDialog();
        }

        private void btnMoney_Click(object sender, EventArgs e)
        {

        }
    }
}
