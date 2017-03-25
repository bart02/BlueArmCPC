using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace BlueArmCPC
{
    public partial class Form1 : Form
    {

        //mySerial a = new mySerial();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (mySerial.opened == false)
            {
                comboBox1.Items.Clear();
                string[] portnames = SerialPort.GetPortNames();
                for (int i = 0; i < portnames.Length; i++)
                {
                    comboBox1.Items.Add(portnames[i]);
                }
            } else
            {
                mySerial.close();
                makeEnabled(false);
            }
            
        }

        private void makeEnabled(bool enable)
        {
            if (enable == true) button4.Text = "Закрыть";
            else button4.Text = "Обновить";
            numericUpDown1.Enabled = enable;
            textBox1.Enabled = enable;
            textBox2.Enabled = enable;
            textBox3.Enabled = enable;
            textBox4.Enabled = enable;
            textBox5.Enabled = enable;
            button3.Enabled = enable;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mySerial.open(comboBox1.SelectedItem.ToString());
            makeEnabled(true);
            //mySerial.write("s");
            //Form1_Load(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "" || Convert.ToInt32(textBox5.Text) > 180 || Convert.ToInt32(textBox5.Text) < 0) textBox5.Text = "0";
            if (textBox4.Text == "" || Convert.ToInt32(textBox4.Text) > 180 || Convert.ToInt32(textBox4.Text) < 0) textBox4.Text = "0";
            if (textBox3.Text == "" || Convert.ToInt32(textBox3.Text) > 180 || Convert.ToInt32(textBox3.Text) < 0) textBox3.Text = "0";
            if (textBox2.Text == "" || Convert.ToInt32(textBox2.Text) > 180 || Convert.ToInt32(textBox2.Text) < 0) textBox2.Text = "0";
            if (textBox1.Text == "" || Convert.ToInt32(textBox1.Text) > 180 || Convert.ToInt32(textBox1.Text) < 0) textBox1.Text = "0";
            MessageBox.Show(textBox5.Text + ";" + textBox4.Text + ";" + textBox3.Text + ";" + textBox2.Text + ";" + textBox1.Text + ";");
            mySerial.write(textBox5.Text + ";" + textBox4.Text + ";" + textBox3.Text + ";" + textBox2.Text + ";" + textBox1.Text + ";");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            mySerial.close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            mySerial.write("x" + numericUpDown1.Value.ToString());
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Это приложение было создано для манипулятора \"BlueArmCPC\"\r\n\r\n" +
                "Авторы:\r\n" +
                "Баталов Артем\r\n" +
                "Абросимов Владислав\r\n\r\n" +
                "Для просмотра исходного кода, нажмите на ссылку GitHub в окне программы.", "Об авторах");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://github.com/bart02");
        }
    }
}
