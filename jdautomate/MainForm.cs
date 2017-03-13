using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.IO;

namespace jdautomate
{
    public partial class MainForm : Form
    {
        BackgroundWorker work;
  
        public MainForm()
        {
            InitializeComponent();
            work = new BackgroundWorker();
            work.WorkerReportsProgress = true;
            work.WorkerSupportsCancellation = true;
            work.ProgressChanged += workProgress;  
            work.RunWorkerCompleted += delegate { workProgress(null, null); };
            Automate.onLog += this.LogConsole;
            Automate.onStatus += this.ChangeStatus;

        }
    

        void ChangeStatus(object sender, Automate.AutomateEventArgs e)
        {
            statusText.Text = e.Message;
            toolStripProgressBar1.Value = e.Percent;
        }

        void workProgress(object sender, ProgressChangedEventArgs e)
        {
            statusText.Text = work.IsBusy.ToString();

            readGmailButton.Enabled =
            upgradeButton.Enabled =
            confirmButton.Enabled =
            registerButton.Enabled = work.IsBusy ? false : true;
        }

        private void LogConsole(string s, bool newLine)
        {
            if ((!newLine) &&(consoleBox.Items.Count>0) ) consoleBox.Items.RemoveAt(consoleBox.Items.Count - 1);
            consoleBox.Items.Add(s);
            consoleBox.SelectedIndex = consoleBox.Items.Count - 1;
            string timeStamp = DateTime.Now.ToString("dd.MM HH:mm:ss ");
            System.IO.File.AppendAllText("log.txt", timeStamp + s + Environment.NewLine);
        }

        private void randomCheck_CheckedChanged(object sender, EventArgs e)
        {
            passwordText.Enabled = (randomCheck.Checked) ? false : true;
        }

        private void makeButton_Click(object sender, EventArgs e)
        {
            string email = emailText.Text;
            int count = (int)countText.Value;
            bool rand = randomCheck.Checked;
            string pass = passwordText.Text;
            Logins logins;
            if (fromTXT.Checked)
            {
                string[] lines = System.IO.File.ReadAllLines(inputTXTBox.Text);
                logins = Logins.GetLogins(new List<string>(lines), rand, pass);
            }
            else
            {
                logins = Logins.GetLogins(email, count, rand, pass);
            }
            string path = fileNameText.Text;
            Logins.SaveToFile(logins.loginsList, path);
            int num = 1;
            foreach (var i in logins.loginsList)
            {
                string[] row = { num++.ToString(), i.email, i.password, i.isRegistered };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }
        }

        private void fileBrowseButton_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog();
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            dlg.Filter = "XML Files | *.xml";
            dlg.DefaultExt = "xml";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fileNameText.Text = dlg.FileName;
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "XML Files | *.xml";
            dlg.DefaultExt = "xml";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Logins.instance = new Logins(dlg.FileName);
            }
            int num = 1;
            foreach (var i in Logins.instance.loginsList)
            {
                string[] row = { num++.ToString(), i.email, i.password, i.isRegistered };
                var listViewItem = new ListViewItem(row);
                listViewRegister.Items.Add(listViewItem);
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            work.DoWork += delegate { Automate.RegisterAll((int)numericUpDown1.Value); };
            work.RunWorkerAsync();
            work.ReportProgress(1);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void goGmailConnect_Click(object sender, EventArgs e)
        {
            Automate.GmailRead(gmailEmailTextBox.Text, gmailPassTextBox.Text, urlToFindTextBox.Text, confirmPathTextBox.Text);
        }

        private void goConfirmButton_Click(object sender, EventArgs e)
        {            
            work.DoWork += delegate { Automate.ConfirmAll(inputFileConfirmTextBox.Text); };
            work.RunWorkerAsync();
            work.ReportProgress(1);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            IWebDriver driver = new ChromeDriver(@"C:\1");
            var login = Logins.LoadFromFile(upgradeInputFile.Text);   
            work.DoWork += delegate { Automate.UpgradeAll(driver, login, (int)numericUpgrades.Value,(int)numericLaps.Value, (int)limitWaitUpFown.Value); };
            work.RunWorkerAsync();
            work.ReportProgress(1);
        }

        private void fromTXT_CheckedChanged(object sender, EventArgs e)
        {
            emailText.Enabled = (fromTXT.Checked) ? false : true;
            countText.Enabled = (fromTXT.Checked) ? false : true;
            inputTXTBox.Enabled = (fromTXT.Checked) ? true : false;
            browseInputTXT.Enabled = (fromTXT.Checked) ? true : false;
        }

        private void browseInputTXT_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            dlg.Filter = "Text Files | *.txt";
            dlg.DefaultExt = "txt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                inputTXTBox.Text = dlg.FileName;
            }
        }

        private void upgradeInputButton_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            dlg.Filter = "XML Files | *.xml";
            dlg.DefaultExt = "xml";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                upgradeInputFile.Text = dlg.FileName;
            }
        }

        private void upgradeOutputButton_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            dlg.Filter = "Text Files | *.txt";
            dlg.DefaultExt = "txt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                upgradeOutputFile.Text = dlg.FileName;
            }
        }

        private void gmailGenerator_Click(object sender, EventArgs e)
        {
            Automate.newGmailAccount("sdfjdfksjdhfkdjhfds", "ccfvnhjy1");
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            string timeStamp = DateTime.Now.ToString("dd.MM HH:mm:ss ");
            string text = "Operation cancelled." + Environment.NewLine + timeStamp + statusText.Text + Environment.NewLine;
            System.IO.File.AppendAllText("log.txt", text);
            work.CancelAsync();
        }
    }

    
}


 

   
 
       






      
    