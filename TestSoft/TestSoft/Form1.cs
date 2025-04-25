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
            string localVersion = "1.2"; // Текущая версия программы
            string versionUrl = "https://github.com/Kharkov21ua/TestSoft/blob/main/TestSoft/TestSoft/bin/Debug/Update.txt";
            string updateUrl = "https://github.com/Kharkov21ua/TestSoft/blob/main/TestSoft/TestSoft/bin/Debug/TestSoft.exe"; // Ссылка на новый exe
            string newFileName = "ProgramNew.exe";

            using (var client = new WebClient())
            {
                try
                {
                    string remoteVersion = client.DownloadString(versionUrl).Trim();

                    if (remoteVersion != localVersion)
                    {
                        Console.WriteLine("Найдено обновление! Скачиваем...");

                        client.DownloadFile(updateUrl, newFileName);

                        Console.WriteLine("Обновление скачано. Запускаем новую версию...");

                        Process.Start(newFileName); // Запустить новое приложение
                        Environment.Exit(0); // Закрыть старую программу
                    }
                    else
                    {
                        Console.WriteLine("Вы используете последнюю версию.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка обновления: {ex.Message}");
                }
            }
        }
    }
}
