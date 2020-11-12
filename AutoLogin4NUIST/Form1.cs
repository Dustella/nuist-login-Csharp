using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoLogin4NUIST
{
    public partial class Form1 : Form
    {
        public Form1()           
           
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("中国移动");
            comboBox1.Items.Add("中国电信");
            comboBox1.Items.Add("中国联通");
        }
        public void ComboBoxForm_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string username = UsernameInput.Text;
            string password = PasswordInput.Text;
            string domain = null;
            string temp = comboBox1.Text;
            switch(temp)
            {
                case "中国移动":
                    domain = "CMCC";

                    break;
                case "中国电信":
                    domain = "ChinaNet";
                    break;
                case "中国联通":
                    domain = "Unicom";
                    break;

            }
            POST p = new POST();
            p.Post(username, password,domain);


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
