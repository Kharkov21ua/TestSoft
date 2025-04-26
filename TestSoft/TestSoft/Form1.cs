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
                if (client.DownloadString("https://pastebin.com/G8X1Ve5c").Contains("1.4"))
                {
                    MessageBox.Show("Новейшая версия", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Обновите софт", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btmUpdate_Click(object sender, EventArgs e)
        {
            // Removed invalid nested class definition  
            string localVersion = "1.2"; // Текущая версия программы  
            string versionUrl = "https://github.com/Kharkov21ua/TestSoft/blob/main/TestSoft/TestSoft/bin/Debug/Update.txt"; // Где лежит версия на сервере  

            using (var client = new WebClient())
            {
                try
                {
                    string serverVersion = client.DownloadString(versionUrl).Trim();

                    if (serverVersion == localVersion)
                    {
                        MessageBox.Show("У вас уже последняя версия программы.", "Обновление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show(
                            $"Доступна новая версия {serverVersion}. Хотите обновить?",
                            "Обновление",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            // Здесь можно вызвать процесс обновления  
                            StartUpdateProcess();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка проверки обновления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void StartUpdateProcess()
        {
            // Здесь будет код для скачивания новой версии  
            MessageBox.Show("Запускаем обновление!", "Обновление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
