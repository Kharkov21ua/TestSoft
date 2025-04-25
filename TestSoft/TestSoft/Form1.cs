using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace TestSoft
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (WebClient client = new WebClient())
            {
                

                if (client.DownloadString("https://pastebin.com/BAsiyqdE").Contains("1.3"))
                {
                    MessageBox.Show("Новейшая версия", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Обновите софт", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    client.DownloadFile("https://github.com/Kharkov21ua/TestSoft/blob/main/TestSoft/TestSoft/bin/Debug/TestSoft.exe", "TestSoft.exe");
                    Application.Exit();
                }
            }
            
        }
    }
}
