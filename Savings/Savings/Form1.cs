using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace Savings
{
    public partial class Form1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double mult = 0;
            var monthlyIncome = double.Parse(textBox1.Text);

            if (monthlyIncome <= 400)
            {
                mult = 0.5;
            }
            else if (monthlyIncome <= 500 && monthlyIncome > 400)
            {
                mult = 0.4;
            }
            else if (monthlyIncome <= 600 && monthlyIncome > 500)
            {
                mult = 0.4159;
            }
            else if (monthlyIncome <= 700 && monthlyIncome > 600)
            {
                mult = 0.4286;
            }
            else if (monthlyIncome <= 800 && monthlyIncome > 700)
            {
                mult = 0.3749;
            }
            else if (monthlyIncome <= 900 && monthlyIncome > 800)
            {
                mult = 0.3333;
            }
            else if (monthlyIncome <= 900 && monthlyIncome > 800)
            {
                mult = 0.3333;
            }
            else if (monthlyIncome <= 1000 && monthlyIncome > 900)
            {
                mult = 0.3;
            }
            else if (monthlyIncome <= 1100 && monthlyIncome > 1000)
            {
                mult = 0.2727;
            }
            else if (monthlyIncome <= 1200 && monthlyIncome > 1100)
            {
                mult = 0.25;
            }
            else
            {
                mult = 0.2222;
            }


            double foodAndDining = monthlyIncome * mult;
            const double internet = 25;
            const double bus = 25;
            var water = double.Parse(textBox6.Text);
            var other = double.Parse(textBox7.Text);

            var totalCost = foodAndDining + internet + bus + water + other;
            var savings = monthlyIncome - totalCost;

            label12.Text = foodAndDining.ToString();
            label9.Text = totalCost.ToString();
            label11.Text = savings.ToString();

        }

        private void label14_MouseEnter(object sender, EventArgs e)
        {
            label14.ForeColor = Color.White;
            label14.Cursor = Cursors.Hand;
        }

        private void label14_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            Application.Exit();
        }

        private void label14_MouseLeave(object sender, EventArgs e)
        {
            label14.ForeColor = Color.LightGreen;
            label14.Cursor = Cursors.Default;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void label15_MouseEnter(object sender, EventArgs e)
        {
            label15.ForeColor = Color.LightGreen;
            label15.Cursor = Cursors.Hand;
        }

        private void label15_MouseLeave(object sender, EventArgs e)
        {
            label15.ForeColor = Color.White;
            label15.Cursor = Cursors.Default;
        }

        private void label15_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to save current Review?", "Save Review", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                var content = new StringBuilder();

                content.AppendLine("Savings Review" + " - "
                    + DateTime.Now.ToString() + ".");
                content.AppendLine();
                content.AppendLine("---------- R ----------");
                content.AppendLine(label1.Text + " - "
                    + textBox1.Text + ";");
                content.AppendLine(label3.Text + " - "
                    + label12.Text + ";");
                content.AppendLine(label5.Text + " - "
                    + label13.Text + ";");
                content.AppendLine(label6.Text + " - "
                    + label4.Text + ";");
                content.AppendLine(label7.Text + " - "
                    + textBox6.Text + ";");
                content.AppendLine(label2.Text + " - "
                    + textBox7.Text + ";");
                content.AppendLine(label8.Text + " Amount" + " - "
                    + label9.Text + ";");
                content.AppendLine(label10.Text + " - "
                    + label11.Text + ";");
                content.AppendLine("---------- R ----------");
                content.AppendLine();
                var path = @".\Savings.txt";
                File.AppendAllText(path, content.ToString());
            }
            
            label15.ForeColor = Color.DarkSeaGreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
