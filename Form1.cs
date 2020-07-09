using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ColaTimer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Queue<String> telephoneNumber = new Queue<string>();
        Queue<int> time = new Queue<int>();

        int conteo = 0;
        int a = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            conteo++;
            label2.Text = "Tiempo: " + conteo.ToString() + "s";
            label3.Text = "Costo: $" + (0.5 * conteo).ToString();
        }

        private void label2_TextChanged(object sender, EventArgs e)
        {
            if (time.Count > 0 && conteo == time.Peek())
            {
                //timer1.Enabled = false;
                listBox1.Items.RemoveAt(0);
                listBox2.Items.Add(telephoneNumber.Dequeue() + "   Tiempo: " + time.Dequeue().ToString() + "   Costo: $" + (0.5 * conteo).ToString());
                conteo = 0;
            }
            else if (listBox1.Items.Count == 0)
            {
                timer1.Enabled = false;
                label2.Text = "Tiempo: ";
            }
        }

        private void label3_TextChanged(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                label3.Text = "Costo: ";
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && textBox1.Text != "")
            {
                string element = textBox1.Text;
                listBox1.Items.Add(element);
                telephoneNumber.Enqueue(element);

                Random random = new Random();
                a = random.Next(3, 6);
                time.Enqueue(a);
                timer1.Enabled = true;

                textBox1.Clear();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
