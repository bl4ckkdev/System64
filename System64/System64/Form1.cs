using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System64
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		public int time;

		private void Form1_Load(object sender, EventArgs e)
		{
			DialogResult firstwarning = MessageBox.Show("This virus is no joke, do you want to run?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (firstwarning == DialogResult.Yes)
			{
				DialogResult secondwarning = MessageBox.Show("THIS IS THE LAST WARNING, IT WILL DESTROY THE BOOTLOADER WE ARE NOT RESPONSIBLE FOR ANY DAMAGES THIS IS JUST FOR FUN, ARE YOU SURE YOU WANT TO RUN IT?", "LAST WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
				if (secondwarning == DialogResult.Yes)
				{
					this.FormBorderStyle = FormBorderStyle.None;
					this.WindowState = FormWindowState.Maximized;
					timer1.Start();
				}
				else if (secondwarning == DialogResult.No)
				{
					this.Close();
					Application.Exit();
				}
			}
			else if (firstwarning == DialogResult.No)
			{
				this.Close();
				Application.Exit();
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (time != 100)
			{
				label2.Text = $"{time}% complete";
				time++;
			} else
			{
				MessageBox.Show("Virus!!");
				timer1.Stop();
			}
		}
	}
}
