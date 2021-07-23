using Be;
using Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gym
{
    public partial class CreditForm : Form
    {
        
        System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
        BusinessLogic bll = new BusinessLogic();
        beAddAthlete addAthlete = new beAddAthlete();
        periodRegister pR = new periodRegister();
        debtList debtList = new debtList();
        
        DataGridView dGV;

        int dayForDate;
        int monthForDate;
        string projectDate;

        public CreditForm(string projectDate,DataGridView dGV)
        {
            this.projectDate = projectDate;
            this.dGV = dGV;
            InitializeComponent();
            eshterak();
            
        }

        private void addCredit_Load(object sender, EventArgs e)
        {
            txtDebt.Enabled = false;
            
            
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled == (char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back) || e.KeyChar == (char)Keys.Delete ||
                e.KeyChar == (char)Keys.Left || e.KeyChar == (char)Keys.Right || e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }
        }

        private void txtFamily_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled == (char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back) || e.KeyChar == (char)Keys.Delete ||
                e.KeyChar == (char)Keys.Left || e.KeyChar == (char)Keys.Right || e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }
        }

        private void txtFatherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled == (char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back) || e.KeyChar == (char)Keys.Delete ||
                e.KeyChar == (char)Keys.Left || e.KeyChar == (char)Keys.Right || e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled == (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back) || e.KeyChar == (char)Keys.Delete ||
                e.KeyChar == (char)Keys.Left || e.KeyChar == (char)Keys.Right)
            {
                e.Handled = true;
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled == (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back) || e.KeyChar == (char)Keys.Delete ||
                e.KeyChar == (char)Keys.Left || e.KeyChar == (char)Keys.Right)
            {
                e.Handled = true;
            }
        }

        private void txtCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled == (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back) || e.KeyChar == (char)Keys.Delete ||
                e.KeyChar == (char)Keys.Left || e.KeyChar == (char)Keys.Right)
            {
                e.Handled = true;
            }
        }

        private void txtDebt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled == (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete))
            {
                e.Handled = true;
            }
        }

        private void txtCredit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled == (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back) || e.KeyChar == (char)Keys.Delete ||
                e.KeyChar == (char)Keys.Left || e.KeyChar == (char)Keys.Right)
            {
                e.Handled = true;
            }
        }


        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled == (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back) || e.KeyChar == (char)Keys.Delete ||
                e.KeyChar == (char)Keys.Left || e.KeyChar == (char)Keys.Right)
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (checkBox1.Checked == false)
            {
                if (txtName.Text.Equals("") || txtFamily.Text.Equals("") || txtFatherName.Text.Equals("") || txtCode.Text.Equals("")
                || txtPhone.Text.Equals("") || txtDays.Text.Equals("") || txtAge.Text.Equals(""))
                    MessageBox.Show("فیلد ها نمیتوانند خالی باشند");
                else
                {


                    addAthlete.name = txtName.Text;
                    addAthlete.family = txtFamily.Text;
                    addAthlete.age = Int32.Parse(txtAge.Text);
                    addAthlete.codeMelli = txtCode.Text;
                    addAthlete.fatherName = txtFatherName.Text;
                    addAthlete.date = projectDate;
                    addAthlete.phone = txtPhone.Text;
                    addAthlete.time = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;

                    pR.date = projectDate;
                    pR.time = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
                    pR.isCredit = true;
                    pR.person = addAthlete.id;
                    pR.expireDay = rbExpire();
                    pR.detail = txtDetail.Text;

                    debtList.person = addAthlete.id;


                    if (txtCash.Enabled == true)
                    {
                        pR.cash = Int32.Parse(txtCash.Text);
                        pR.debt = null;
                    }
                    else
                    {
                        pR.cash = null;
                        pR.debt = Int32.Parse(txtDebt.Text);
                        debtList.debt = pR.debt;
                    }

                    bool answer = bll.creat(addAthlete, pR);
                    if (answer == true)
                    {

                        MessageBox.Show("شما قبلا ثبت نام کرده اید");
                    }
                    else
                    {

                        MessageBox.Show("ثبت شد");
                    }
                }
            }
            else
            {
                if (txtCode.Text !=null)
                {
                    periodRegister period = new periodRegister();
                    period.date = projectDate;
                    period.detail = txtDetail.Text;
                    period.expireDay = rbExpire();

                    if (txtCash.Enabled == true)
                    {
                        period.cash = Int32.Parse(txtCash.Text);
                        period.debt = null;
                        txtDebt.Text = "";
                    }
                    else
                    {
                        txtCash.Text = "";
                        period.cash = null;
                        period.debt = Int32.Parse(txtDebt.Text);
                        
                    }
                    period.isCredit = true;
                    period.time= DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
                    
                    var q = from i in bll.readAll() where i.codeMelli == txtCode.Text select i;
                    foreach (var item in q)
                    {
                        period.person = item.id;
                    }
                    bool ans = bll.updateCredit(txtCode.Text,period);
                    if (ans == true)
                    {
                        MessageBox.Show("تمدید شد");
                    }
                }
            }
            
              

            
        }

        private void checkDebt_CheckedChanged(object sender, EventArgs e)
        {
            periodRegister periodRegister = new periodRegister();
            if (checkDebt.Checked == true)
            {
                
                
                txtDebt.Enabled = true;
                txtCash.Enabled = false;
                txtCash.Text = "";
            }
            else
            {
                
                txtCash.Enabled = true;
                
                txtDebt.Enabled = false;
                txtDebt.Text = "";
            }
        }

        private string rbExpire()
        {
            if (rbDaily.Checked && !txtDays.Text.Equals(""))
            {
                dayForDate = Int32.Parse(txtDays.Text);

                var year = DateTime.Now.Date.AddDays(dayForDate).ToString("yyyy");
                var month = DateTime.Now.Date.AddDays(dayForDate).ToString("MM");
                var day = DateTime.Now.Date.AddDays(dayForDate).ToString("dd");
                DateTime date = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
                var calendar = new System.Globalization.PersianCalendar();
                var persianDate = new DateTime(calendar.GetYear(date), calendar.GetMonth(date), calendar.GetDayOfMonth(date));
                var result = persianDate.ToString("yyyy/MM/dd");

                return result.ToString();

                // MessageBox.Show(result.ToString());
            }
            else if (rbMonth.Checked && !txtDays.Text.Equals(""))
            {
                monthForDate = Int32.Parse(txtDays.Text);
                
                var year = DateTime.Now.Date.AddMonths(monthForDate).ToString("yyyy");
                var month = DateTime.Now.Date.AddMonths(monthForDate).ToString("MM");
                var day = DateTime.Now.Date.AddMonths(monthForDate).ToString("dd");
                DateTime date = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
                var calendar = new System.Globalization.PersianCalendar();
                var persianDate = new DateTime(calendar.GetYear(date), calendar.GetMonth(date), calendar.GetDayOfMonth(date));
                var result = persianDate.ToString("yyyy/MM/dd");

                return result.ToString();

                //MessageBox.Show(result.ToString());
            }
            return null;
            
        }
        private string costOption()
        {
            if (checkDebt.Checked)
            {
                return txtDebt.Text;
            }
            return txtCash.Text;
        }

        private void CreditForm_Leave(object sender, EventArgs e)
        {
            
            
        }

        private void CreditForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            var q = from i in bll.Read(projectDate) select new {i.id, i.beAddAthlete.name , i.beAddAthlete.family , i.beAddAthlete.phone , i.expireDay};
            
            dGV.DataSource = q.ToList();
            dGV.Columns[0].HeaderText = "ردیف";
            dGV.Columns[1].HeaderText = "نام";
            dGV.Columns[2].HeaderText = "نام خانوادگی";
            dGV.Columns[3].HeaderText = "همراه";
            dGV.Columns[4].HeaderText = "اتمام اشتراک";


        }


        private void txtSearchContent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled == (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Right || e.KeyChar == (char)Keys.Left))
            {
                e.Handled = true;
            }
        }

        

        private void مشاهدهلیستاشتراکیهاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllOfCredits allOfCredits = new AllOfCredits();
            allOfCredits.ShowDialog();
        }
        public void eshterak()
        {
            button1.Enabled = false;
            txtCodeMelliContent.Enabled = false;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            var answer = bll.read(txtCodeMelliContent.Text);
            if (answer == null)
            {
                MessageBox.Show("حساب کاربری فعال دارید");
            }
            else
            {
                var answer1 = bll.readRej(txtCodeMelliContent.Text);
                foreach (var item in answer1)
                {
                    txtCode.Text = item.codeMelli;
                    txtName.Text = item.name;
                    txtFamily.Text = item.family;
                    txtFatherName.Text = item.fatherName;
                    txtAge.Text = item.age.ToString();
                    txtPhone.Text = item.phone;
                }
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

            if (checkBox1.Checked == false)
            {
                button1.Enabled = false;
                txtCodeMelliContent.Enabled = false;
                txtCodeMelliContent.Text = "";

                CreditFormTitle.Text = "فرم ثبت نام";

                txtName.Enabled = true;
                
                txtFamily.Enabled = true;
                
                txtFatherName.Enabled = true;
                txtAge.Enabled = true;
                txtPhone.Enabled = true;
                txtCode.Enabled = true;
                txtCash.Text = "";
                txtDebt.Text = "";

            }
            else if (checkBox1.Checked == true)
            {
                button1.Enabled = true;
                txtCodeMelliContent.Enabled = true;
                txtCode.Enabled = false;
                txtCode.Text = "";
                CreditFormTitle.Text = "فرم تمدید";

                txtName.Enabled = false;
                txtName.Text = "";
                txtFamily.Enabled = false;
                txtFamily.Text = "";
                txtFatherName.Enabled = false;
                txtFatherName.Text = "";
                txtAge.Enabled = false;
                txtAge.Text = "";
                txtPhone.Enabled = false;
                txtPhone.Text = "";
                txtCash.Text = "";
                txtDebt.Text = "";
                txtDetail.Text = "";
            }
        }
        
    }
}
