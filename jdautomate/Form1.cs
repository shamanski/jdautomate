using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Interactions;
using System.Drawing.Imaging;
using System.IO;
using System.Xml.Serialization;
using System.Net.Mail;
using OSPOP3_Plus;

namespace jdautomate
{
    public partial class Form1 : Form
    {
        BackgroundWorker work;
        public Form1()
        {
            InitializeComponent();
            work = new BackgroundWorker();
            work.WorkerReportsProgress = true;          
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
                string[] lines = File.ReadAllLines(inputTXTBox.Text);
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

        private void button2_Click(object sender, EventArgs e)
        {
            int num = 0;
            ThreadPool.SetMaxThreads(1, 1);
            List<String> tabs = new List<String>();
            IWebDriver driver = new ChromeDriver(@"C:\1");
            tabs.Add(driver.CurrentWindowHandle);
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            // ReadOnlyCollection<string> handles = driver.WindowHandles;
            foreach (var i in Logins.instance.loginsList)
            {
                //var data = new Automate.Data();
                Automate.Game(driver, Logins.instance.loginsList[num++]);
                // js.ExecuteScript("var win = window.open('', '_blank');win.focus();");
                // tabs.Add(driver.CurrentWindowHandle);
                // driver.SwitchTo().Window(driver.WindowHandles.Last());
                //ThreadPool.QueueUserWorkItem(new WaitCallback(Automate.DoRegister), data);
            }
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
            work.DoWork += delegate { Automate.UpgradeAll(driver, login, (int)numericUpgrades.Value,(int)numericLaps.Value); };
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
    }
    public static class Automate
    {
        public delegate void LogConsole(string message, bool newLine);
        public static event LogConsole onLog;
        public delegate void AutomateHandler (object sender, AutomateEventArgs e);
        public static event AutomateHandler onStatus;
        private static Session oSession = new Session();
        public static AutomateEventArgs e = new AutomateEventArgs();

        public class AutomateEventArgs : EventArgs
        {
            private string message;
            private int percent;
            public String Message
            {
                get { return message; }
                set { message = value; }
            }
            public int Percent
            {
                get { return percent; }
                set { percent = value; }
            }
        }

        public static Image TakeScreenshot(IWebDriver parDriver)
            {
                string saveLocation = "screen.png";
                ITakesScreenshot screenshotDriver = parDriver as ITakesScreenshot;
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                screenshot.SaveAsFile(saveLocation, ImageFormat.Bmp);
                System.IO.FileStream fs = new System.IO.FileStream(saveLocation, System.IO.FileMode.Open);
                Image myScreenhot = Image.FromStream(fs);
                fs.Close();

                return myScreenhot;
            }

        public static void TakeCaptcha(IWebDriver parDriver, int parXPosCaptcha, int parYPosCaptcha, Size size)
            {
                Random r = new Random();
                string saveLocation = Logins.GetPass(r, 15);
                Image myScreenhot = TakeScreenshot(parDriver);

                // Устанавливаем координаты капчи и ее размер
                Rectangle parSection = new Rectangle(parXPosCaptcha, parYPosCaptcha, size.Width, size.Height);

                // Создаем изображение с заданым размером
                Bitmap bmpCaptcha = new Bitmap(parSection.Width, parSection.Height);
                // Вырезаем область изображения
                Graphics g = Graphics.FromImage(bmpCaptcha);
                g.DrawImage(myScreenhot, 0, 0, parSection, GraphicsUnit.Pixel);
                g.Dispose();
                bmpCaptcha.Save(Logins.GetPass(r, 15));
                //return bmpCaptcha;
            }

        public static void RegisterAll(int startPosition)
            {
                var logins = Logins.instance;
                IWebDriver driver = new ChromeDriver(@"C:\1");
            int pos = 0;
            int percent = 0;
            int step = 100/(logins.loginsList.Count-startPosition);
                for (int n = startPosition; n < logins.loginsList.Count; n++)
                {
                percent += step;
                    var i = logins.loginsList[n];
                    driver.Manage().Cookies.DeleteAllCookies();
                e.Message = String.Format("Register email: {0}. Total: {1}, Sucess{2}", i.email, logins.loginsList.Count, pos);
                e.Percent = percent;
                onStatus(null, e);
                    if (i.isRegistered == "false")
                        try
                        {
                            Automate.Register(driver, i);
                        pos++;
                        }
                        catch
                        {
                            onLog("Skip...", true);
                            continue;
                        }
                    logins.loginsList[n].isRegistered = "true";
                    Logins.SaveToFile(logins.loginsList, "temp.xml");

                    Application.DoEvents();
                }
            }

        private static void oSession_Connected()
        { }
        private static void oSession_ErrorPOP3(int number, string description)
        {

        }

        private static  void oSession_StatusChanged(string Status, Session.StatusTypeConstants StatusType)
        {
 

     
        }

        public static void GmailRead(string email, string password, string url, string fileName)
            {
                onLog("Start connecting " + email, true);
                oSession = new OSPOP3_Plus.Session();
            oSession.ErrorPOP3 += new Session.ErrorPOP3Handler(oSession_ErrorPOP3);
            oSession.StatusChanged += new Session.StatusChangedHandler(oSession_StatusChanged);
            oSession.Closed += new Session.ClosedHandler(oSession_Connected);
            oSession.Connected += new Session.ConnectedHandler(oSession_Connected);
            oSession.UseSSL = true;
                oSession.OpenPOP3("pop.gmail.com", 995, email, password, false);
                onLog("Status: " + oSession.Status, true);
                int count = oSession.GetMessageCount();
                onLog("Total mails: " + count.ToString(), true);
                List<string> s = new List<string>();
                for (int n = 0; n < count; n++)
                {
                    try
                    {
                        var m = oSession.GetMessage(n);
                        string ss = m.HTMLBody;
                        int start = ss.IndexOf(url); //@"www.slivki.by/confirm"
                        int num2 = ss.IndexOf('"', start);
                        s.Add(ss.Substring(start, num2 - start));
                    }
                    catch { }
                }
                oSession.ClosePOP3();
                onLog("Found links: " + s.Count.ToString(), true);
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(fileName, true))
            {
                foreach (string line in s)
                {
                    file.WriteLine(@"https://" + line);
                }

            }
            onLog("Save to file " + fileName, true);

        }

        public static string Upgrade(IWebDriver driver)
        {
            onLog("Prepare click... ", true);
            driver.Navigate().GoToUrl("https://www.slivki.by/kamni-ohlazhdenie-napitok-minsk-skidka");
            IWebElement button = driver.FindElement(By.Id("buyCodeButton"));
            button.Click();
            IWebElement button2 = driver.FindElement(By.ClassName("buttonYes"));
            button2.Click();
           
            IWebElement code = driver.FindElement(By.ClassName("codeValue"));
            File.AppendAllText("result.txt", code.Text + Environment.NewLine);
            driver.Navigate().GoToUrl("https://www.slivki.by/kamni-ohlazhdenie-napitok-minsk-skidka");
            button = driver.FindElement(By.Id("buyCodeButton"));
            button.Click();
            button2 = driver.FindElement(By.ClassName("buttonYes"));
            button2.Click();
            IWebElement code2 = driver.FindElement(By.ClassName("codeValue"));
            onLog("Click OK.", true);
            return code2.Text; 
        }

        public static void UpgradeAll(IWebDriver driver, List<Logins.LoginEntry> loginEntry, int maxUpgrades, int maxLaps)
        {
            var nextLapEntries = new List<Logins.LoginEntry>();
            int currentLap = 1;
            int positive = 0;
            do
            {
                if (currentLap > 1)
                {
                    loginEntry = nextLapEntries;
                    nextLapEntries.Clear();
                }
                Logins.LoginEntry currentLoginEntry;                    
                for (int curr = 0; curr < loginEntry.Count && positive < maxUpgrades; curr++)
                {
                    currentLoginEntry = loginEntry[curr];
                    e.Message = String.Format("Update email {4}: {0}. Lap: {3}. Positive: {1}, Negative: {2}",
                                            currentLoginEntry.email, positive, nextLapEntries.Count, currentLap, curr + 1);
                    e.Percent = 100 / maxUpgrades * positive;
                    onStatus(null, e);
                    try
                    {
                        Automate.Login(driver, currentLoginEntry);
                        string res = Automate.Upgrade(driver);
                        File.AppendAllText("result.txt", res + Environment.NewLine + currentLoginEntry.email + " " + "finish" + Environment.NewLine);
                        positive++;
                    }
                    catch
                    {
                        File.AppendAllText("result.txt", "problem with " + currentLoginEntry.email + Environment.NewLine);
                        nextLapEntries.Add(currentLoginEntry);
                    }
                }
                currentLap++;
            }
            while (nextLapEntries.Count>0 && currentLap<maxLaps && nextLapEntries.Count< maxUpgrades);
            
        }

        public static void Login(IWebDriver driver, Logins.LoginEntry entry)
            {
            onLog("Starting login " + entry.email, true);
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.Navigate().GoToUrl("http://slivki.by");
            IWebElement enter = driver.FindElement(By.ClassName("enter"));
            enter.Click();
            IWebElement email = driver.FindElement(By.XPath(@"//div[@class='login']/form/div[@class='form-fields']/div[@class='field']/input[@name='email']"));
            IWebElement pwd = driver.FindElement(By.XPath(@"//div[@class='login']/form/div[@class='form-fields']/div[@class='field']/input[@name='password']"));
            IWebElement regist = driver.FindElement(By.XPath(@"//div[@class='login']/form/div[@class='form-fields']/input[@type='submit']"));
                                                                
            email.SendKeys(entry.email);
            pwd.SendKeys(entry.password);
            regist.Click();
            IWebElement into = driver.FindElement(By.ClassName("profile-data"));
            onLog("OK" + entry.email, true);
        }

        public static void Register(IWebDriver driver, Logins.LoginEntry entry)
            {
                onLog("Starting register " + entry.email, true);
                driver.Manage().Cookies.DeleteAllCookies();
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
                driver.Navigate().GoToUrl("http://slivki.by");
                IWebElement enter = driver.FindElement(By.ClassName("enter"));
                enter.Click();
                IWebElement email = driver.FindElement(By.XPath("//div[@class='register']/form/div[@class='form-fields']/div[@class='field']/input[@name='email']"));
                IWebElement pwd = driver.FindElement(By.XPath("//div[@class='register']/form/div[@class='form-fields']/div[@class='field']/input[@name='password']"));
                IWebElement pwd2 = driver.FindElement(By.XPath("//div[@class='register']/form/div[@class='form-fields']/div[@class='field']/input[@name='confirmPassword']"));
                IWebElement city = driver.FindElement(By.Name("city"));
                SelectElement select = new SelectElement(city);
                System.Collections.Generic.IList<OpenQA.Selenium.IWebElement> options = select.Options;
                select.SelectByText("Минск");
                IWebElement regist = driver.FindElement(By.XPath("//div[@class='register']/form/input[@class='button button--green button--block']"));
                email.SendKeys(entry.email);
                pwd.SendKeys(entry.password);
                pwd2.SendKeys(entry.password);
                regist.Click();
                IWebElement into = driver.FindElement(By.Id("modal-register-complete"));
                onLog("OK" + entry.email, true);
            }

        public static void ConfirmAll(string inputFile)
            {
                List<string> lines = new List<string>(System.IO.File.ReadAllLines(inputFile));
            IWebDriver driver = new ChromeDriver(@"C:\1");         
                int good = 0;
                int bad = 0;
                for (int i = 0; i < lines.Count; i++)
                {
                e.Message = string.Format("Confirm email {0}", i + 1);
                e.Percent = 100 / lines.Count * i;
                onStatus(null, e);
                string mail = Confirm(driver, lines[i]);
                    if (mail != "")
                    {
                        File.AppendAllText("confirmed.txt", mail + Environment.NewLine);
                        good++;
                    }
                    else
                    {
                        File.AppendAllText("nonconfirmed.txt", lines[i]+ Environment.NewLine);
                        bad++;
                    }
                    onLog("Confirmed: " + good.ToString() + " Uncofirmed: " + bad.ToString(), false);
                    Application.DoEvents();

                }
            }

        public static void newGmailAccount(string login, string pass)
        {
            IWebDriver driver = new ChromeDriver(@"C:\1");
            driver.Navigate().GoToUrl("https://accounts.google.com/SignUp?");
            driver.FindElement(By.Name("FirstName")).SendKeys("Vasya");
            driver.FindElement(By.Name("LastName")).SendKeys("Chito");
            driver.FindElement(By.Name("GmailAddress")).SendKeys(login);
            driver.FindElement(By.Name("Passwd")).SendKeys(pass);
            driver.FindElement(By.Name("PasswdAgain")).SendKeys(pass);
            driver.FindElement(By.XPath("//span[@id='BirthMonth']/div[@role='listbox']")).Click();
            driver.FindElement(By.Id(":1")).Click();
            driver.FindElement(By.XPath("//div[@id='Gender']/div[@role='listbox']")).Click();
            driver.FindElement(By.Id(":f")).Click();
            driver.FindElement(By.Name("BirthDay")).SendKeys("10");
            driver.FindElement(By.Name("BirthYear")).SendKeys("1980");
            driver.FindElement(By.Name("submitbutton")).Click();
            driver.FindElement(By.Id("tos-scroll-button")).Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(dr => !driver.FindElement(By.Id("iagreebutton")).Displayed);
            driver.FindElement(By.Id("iagreebutton")).Click();
        }

        private static string Confirm(IWebDriver driver, string url)
            {

                driver.Manage().Cookies.DeleteAllCookies();
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
                driver.Navigate().GoToUrl(url);
                try
                {
                    IWebElement email = driver.FindElement(By.Id("info_dialog_content"));
                    return "value";
                }
                catch
                {
                    return "";
                }
            }

        public static bool Game(IWebDriver driver, Logins.LoginEntry entry)
            {
                driver.Manage().Cookies.DeleteAllCookies();
                driver.Navigate().GoToUrl("http://signin.jd.ru/new/facade.html");
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("emailId")));
                IWebElement email = driver.FindElement(By.Id("emailId"));
                IWebElement pwd = driver.FindElement(By.Id("pwdId"));
                IWebElement log = driver.FindElement(By.Id("login-btn"));
                email.SendKeys(entry.email);
                pwd.SendKeys(entry.password);
                log.Click();
                try
                {
                    wait.Until(ExpectedConditions.TitleContains("JD"));
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                driver.Navigate().GoToUrl("http://sale.jd.ru/act/cDUrj6Bakwy4oJI.html");
                wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("btn-go-bg")));
                IWebElement start = driver.FindElement(By.ClassName("btn-go-bg"));
                start.Click();
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                IWebElement win = driver.FindElement(By.ClassName("dialog-content"));
                switch (win.Text)
                {
                    case "Ничего, повезёт в следующий раз!":
                        return false;

                    case "Все попытки израсходованы":
                        return false;

                    default:
                        return false;

                }
            }
        }   

        public class windows
        {
        public List<Thread> threads;
        public List<IWebDriver> drivers;
        public void Add(IWebDriver driver)
        {
            this.drivers.Add(driver); 
        }
        public windows()
        {
            this.drivers = new List<IWebDriver>();
        }

    }

    [Serializable]
    public class Logins
    {
        public static Logins instance;
        public List<LoginEntry> loginsList;
        public Logins()
        {
            this.loginsList = new List<LoginEntry>();
        }
        public Logins(string path)
        {
            this.loginsList = Logins.LoadFromFile(path);
        }
        public class LoginEntry
        {
            public string email, password, isRegistered;
        }

        public static Logins GetLogins(List<String> inputEmails, bool randomPass, string pass = "defaultPass1")
        {
            Random rand = new Random();
            Logins list = new Logins();
            foreach (var email in inputEmails )
            {
                var entry = new Logins.LoginEntry();
                entry.email = email;
                entry.password = (randomPass) ? GetPass(rand) : pass;
                entry.isRegistered = "false";
                list.loginsList.Add(entry);
            }

            return list;
        }

        public static Logins GetLogins(String inputEmail, int num, bool randomPass, string pass = "defaultPass1")
        {
            Logins list = new Logins();
            var baseEmail = inputEmail.Remove(inputEmail.LastIndexOf('@'));
            var mask = new BitArray(new bool[baseEmail.Length - 1]);
            var entry = new List<string>();
            int curr = 1;
            while (entry.Count < num)
            {
                string resString = baseEmail;
                var b = new BitArray(new int[] { curr });
                for (int nu = 0; nu < mask.Count; nu++)
                {
                    mask[nu] = b[nu];

                }

                for (int i = mask.Length; i >= 1; i--)
                {
                    if (mask.Get(i - 1)) resString = resString.Insert(i, ".");
                }
                
                entry.Add (resString + inputEmail.Substring(inputEmail.LastIndexOf('@')));
                curr++;
            }
            return GetLogins(entry, randomPass, pass);
            }
        public static void SaveToFile(List<LoginEntry> logins, string path)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<LoginEntry>));
            using (FileStream fs = new FileStream(path, FileMode.Create)) formatter.Serialize(fs, logins);
        }
        public static List<LoginEntry> LoadFromFile(string path)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<LoginEntry>));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                List<LoginEntry> logins = (List<LoginEntry>)formatter.Deserialize(fs);
                return logins;
            }
        }
        public static string GetPass(Random r, int x = 8)
        {
            string pass = "";
            while (pass.Length < x)
            {
                Char c = (char)r.Next(33, 125);
                if (Char.IsLetterOrDigit(c))
                    pass += c;
            }
            foreach (char c in pass)
            {
                if (Char.IsDigit(c)) return pass;
            }
            var cc = (char)r.Next(48, 57);
            pass = pass.Remove(r.Next(0, pass.Length - 1), 1).Insert(r.Next(0, pass.Length - 1), cc.ToString());
            return pass;
        }


    }

    
}


 

   
 
       






      
    