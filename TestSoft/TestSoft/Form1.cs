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
            string localVersion = "1.6"; // текущая версия твоего софта
            string url_exe = "https://raw.githubusercontent.com/Kharkov21ua/TestSoft/main/TestSoft/TestSoft/bin/Release/TestSoft.exe";
            string url_txt = "https://raw.githubusercontent.com/Kharkov21ua/TestSoft/main/TestSoft/TestSoft/bin/Release/Update.txt";
            string tempUpdateFile = Path.Combine(Path.GetTempPath(), "Update.txt");
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "TestSoft.exe");

            using (WebClient client = new WebClient())
            {
                try
                {
                    // Скачиваем файл Update.txt во временную папку
                    client.DownloadFile(url_txt, tempUpdateFile);

                    // Читаем версию с сервера
                    string serverVersion = File.ReadAllText(tempUpdateFile).Trim();

                    if (serverVersion == localVersion)
                    {
                        MessageBox.Show("У вас уже последняя версия программы.", "Обновление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Версия отличается — обновляем
                        DialogResult result = MessageBox.Show(
                            $"Доступна новая версия {serverVersion}. Обновить сейчас?",
                            "Обновление доступно",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            // Скачиваем новый exe и новый Update.txt
                            client.DownloadFile(url_exe, filePath);
                            client.DownloadFile(url_txt, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Update.txt"));

                            MessageBox.Show("Обновление успешно установлено! Перезапуск программы...", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Запускаем новое приложение
                            Process.Start(filePath);
                            Application.Exit();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка обновления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
