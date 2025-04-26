using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net;
using System.Windows.Forms;
using TestSoft;

public partial class MainForm : Form1
{
    string localVersion = "1.0"; // Текущая версия программы
    string versionUrl = "https://raw.githubusercontent.com/Kharkov21ua/TestSoft/main/Update.txt"; // Где лежит версия на сервере

    public MainForm()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        throw new NotImplementedException();
    }

    private void buttonUpdate_Click(object sender, EventArgs e)
    {
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