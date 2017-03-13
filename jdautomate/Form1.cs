using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
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

using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.InputMessageContents;
using Telegram.Bot.Types.ReplyMarkups;

namespace jdautomate
{
    public partial class Form1 : Form
    {
        BackgroundWorker work;
        long chatID;
        private static readonly Telegram.Bot.TelegramBotClient Bot = new Telegram.Bot.TelegramBotClient("366916344:AAE6Sh5-AVk9Qb1f1MvTjq31zbnkpB6TaPc");
        public Form1()
        {
            InitializeComponent();
            work = new BackgroundWorker();
            work.WorkerReportsProgress = true;
            work.WorkerSupportsCancellation = true;
            work.ProgressChanged += workProgress;  
            work.RunWorkerCompleted += delegate { workProgress(null, null); };
            Automate.onLog += this.LogConsole;
            Automate.onStatus += this.ChangeStatus;

            Bot.OnCallbackQuery += BotOnCallbackQueryReceived;
            Bot.OnMessage += BotOnMessageReceived;
            Bot.OnMessageEdited += BotOnMessageReceived;
            Bot.OnInlineQuery += BotOnInlineQueryReceived;
            Bot.OnInlineResultChosen += BotOnChosenInlineResultReceived;
            Bot.OnReceiveError += BotOnReceiveError;
            Bot.StartReceiving();
        }

        async void send(string s)
        {
            await Bot.SendTextMessageAsync(chatID, s);
        }
        private void botLog(string s, bool newLine)
        {
            send(s);
        }
        private static void BotOnReceiveError(object sender, ReceiveErrorEventArgs receiveErrorEventArgs)
        {
            Debugger.Break();
        }

        private static void BotOnChosenInlineResultReceived(object sender, ChosenInlineResultEventArgs chosenInlineResultEventArgs)
        {
            Console.WriteLine($"Received choosen inline result: {chosenInlineResultEventArgs.ChosenInlineResult.ResultId}");
        }

        private static async void BotOnInlineQueryReceived(object sender, InlineQueryEventArgs inlineQueryEventArgs)
        {
            InlineQueryResult[] results = {
                new InlineQueryResultLocation
                {
                    Id = "1",
                    Latitude = 40.7058316f, // displayed result
                    Longitude = -74.2581888f,
                    Title = "New York",
                    InputMessageContent = new InputLocationMessageContent // message if result is selected
                    {
                        Latitude = 40.7058316f,
                        Longitude = -74.2581888f,
                    }
                },

                new InlineQueryResultLocation
                {
                    Id = "2",
                    Longitude = 52.507629f, // displayed result
                    Latitude = 13.1449577f,
                    Title = "Berlin",
                    InputMessageContent = new InputLocationMessageContent // message if result is selected
                    {
                        Longitude = 52.507629f,
                        Latitude = 13.1449577f
                    }
                }
            };

            await Bot.AnswerInlineQueryAsync(inlineQueryEventArgs.InlineQuery.Id, results, isPersonal: true, cacheTime: 0);
        }

        private async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;

            if (message == null || message.Type != MessageType.TextMessage) return;

            if (message.Text.StartsWith("/start")) // send inline keyboard
            {
                await Bot.SendTextMessageAsync(message.Chat.Id, "Go!");
               // upgradeInputFile.Text = @"C:\Projects\jdautomate\jdautomate\bin\Debug\rudenkov.xml";
                upgradeOutputFile.Text = "bot.txt";
                chatID = message.Chat.Id;
                Automate.onLog += this.botLog;
                IWebDriver driver = new ChromeDriver(@"C:\1");
                var login = Logins.LoadFromFile(upgradeInputFile.Text);
                work.DoWork += delegate { Automate.UpgradeAll(driver, login, (int)numericUpgrades.Value, (int)numericLaps.Value, (int)limitWaitUpFown.Value); };
                work.RunWorkerAsync();
                work.ReportProgress(1);
            }
        }

        private static async void BotOnCallbackQueryReceived(object sender, CallbackQueryEventArgs callbackQueryEventArgs)
        {
            await Bot.AnswerCallbackQueryAsync(callbackQueryEventArgs.CallbackQuery.Id,
                $"Received {callbackQueryEventArgs.CallbackQuery.Data}");
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

        //screenshot
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

        //save captcha to random .png
        public static void TakeCaptcha(IWebDriver parDriver, int parXPosCaptcha, int parYPosCaptcha, Size size)
            {
                Random r = new Random();
                string saveLocation = Logins.GetPass(r, 15);
                Image myScreenhot = TakeScreenshot(parDriver);
                Rectangle parSection = new Rectangle(parXPosCaptcha, parYPosCaptcha, size.Width, size.Height);
                Bitmap bmpCaptcha = new Bitmap(parSection.Width, parSection.Height);
                Graphics g = Graphics.FromImage(bmpCaptcha);
                g.DrawImage(myScreenhot, 0, 0, parSection, GraphicsUnit.Pixel);
                g.Dispose();
                bmpCaptcha.Save(Logins.GetPass(r, 15));
            }

        //register list of accounts
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

        //gmail session
        private static void oSession_Connected()
        { }
        private static void oSession_ErrorPOP3(int number, string description)
        {

        }
        private static  void oSession_StatusChanged(string Status, Session.StatusTypeConstants StatusType)
        {
 

     
        }

        //look for confirmation links in gmail account
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
            System.IO.File.AppendAllLines(fileName, s);
            onLog("Saved to file " + fileName, true);

        }

        //upgrade one time
        async static Task<string> Upgrade(IWebDriver driver, int limitWait)
        {
            try
            {
                driver.Navigate().GoToUrl(System.IO.File.ReadAllText("promourl.txt"));
               while (driver.FindElement(By.Id("usedCodeCount")).Text == driver.FindElement(By.Id("freeCodeCount")).Text)
                {
                    onLog("Limit reached...wait "+limitWait+" minute(s)", true);
                    await Task.Delay(60000*limitWait);
                    driver.Navigate().Refresh();
                }
                IWebElement button = driver.FindElement(By.Id("buyCodeButton"));
                button.Click();
                IWebElement button2 = driver.FindElement(By.ClassName("buttonYes"));
                button2.Click();
                IWebElement code = driver.FindElement(By.ClassName("codeValue"));
                return code.Text;                
            }
            catch
            {
                return "";
            }
 
        }

        //login and upgrade all entries in limit
        public static void UpgradeAll(IWebDriver driver, List<Logins.LoginEntry> loginEntry, int maxUpgrades, int maxLaps, int limitWait)
        {
            var nextLapEntries = new List<Logins.LoginEntry>(); //list for negative entries
            int currentLap = 1;
            int positive = 0;
            int numAttempts = 2; //number of attempts with same login
            string logMsg;
            do
            {
                if (currentLap > 1)
                {
                    loginEntry = nextLapEntries;//working with negatives
                    nextLapEntries.Clear();
                }
                Logins.LoginEntry currentLoginEntry;                    
                for (int curr = 0; curr < loginEntry.Count && positive < maxUpgrades; curr++) //next login entry
                {
                    currentLoginEntry = loginEntry[curr];                    
                    //log to status
                    e.Message = String.Format("Update email {4}: {0}. Lap: {3}. Positive: {1}, Negative: {2}",
                                            currentLoginEntry.email, positive, nextLapEntries.Count, currentLap, curr + 1);
                    e.Percent = 100 / maxUpgrades * positive;
                    onStatus(null, e);//set current status
                    if (Automate.Login(driver, currentLoginEntry)==true) //login succesfull
                    {
                        int attempt = 1;
                        logMsg = String.Format("Lap {2}, Entry {0}, Login {1} success", (curr + 1).ToString(), currentLoginEntry.email, currentLap);
                        onLog(logMsg, true);
                        for (attempt = 1; attempt <= numAttempts; attempt++)
                        {
                            string res = Automate.Upgrade(driver, limitWait).Result;//upgrade current entry attempt                            
                            if (res=="")
                            {
                                logMsg = "nothing";
                                nextLapEntries.Add(currentLoginEntry);
                            }
                            else
                            {
                                positive++;//success
                                logMsg = "code " + res;
                            }
                            logMsg = String.Format("Lap {3}, Entry {0}, Attempt {1}: Get {2}", (curr + 1).ToString(), attempt.ToString(), logMsg, currentLap);                                
                            onLog(logMsg, true);                            
                        }
                    }
                    else
                    {
                        logMsg = String.Format("Lap {2}, Entry {0}, Login {1} failed", (curr + 1).ToString(), currentLoginEntry.email, currentLap);
                        onLog(logMsg, true);//login failed 
                    }                                                    
                }
                currentLap++;//go to next lap
            }
            while (nextLapEntries.Count>0 && currentLap<maxLaps && nextLapEntries.Count< maxUpgrades);
            e.Message = "Done.";
            e.Percent = 0;
            onStatus(null, e);
            driver.Dispose();
        }

        //public static string[] H24check()
        //{

        //}

        //login one entry
        public static bool Login(IWebDriver driver, Logins.LoginEntry entry)
            {
            try
            {
                onLog("Starting login " + entry.email, true);
                driver.Manage().Cookies.DeleteAllCookies();
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
                driver.Navigate().GoToUrl("http://slivki.by");
                driver.FindElement(By.ClassName("enter")).Click();
                IWebElement email = driver.FindElement(By.XPath(@"//div[@class='login']/form/div[@class='form-fields']/div[@class='field']/input[@name='email']"));
                IWebElement pwd = driver.FindElement(By.XPath(@"//div[@class='login']/form/div[@class='form-fields']/div[@class='field']/input[@name='password']"));
                IWebElement regist = driver.FindElement(By.XPath(@"//div[@class='login']/form/div[@class='form-fields']/input[@type='submit']"));
                email.SendKeys(entry.email);
                pwd.SendKeys(entry.password);
                regist.Click();
                IWebElement into = driver.FindElement(By.ClassName("profile-data"));
            }
            catch
            {
                return false;
            }
            return true;
        }

        //register one account
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
                onLog("OK " + entry.email, true);
            }

        //confirm with all links from textfile
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
                        System.IO.File.AppendAllText("confirmed.txt", mail + Environment.NewLine);
                        good++;
                    }
                    else
                    {
                        System.IO.File.AppendAllText("nonconfirmed.txt", lines[i]+ Environment.NewLine);
                        bad++;
                    }
                    onLog("Confirmed: " + good.ToString() + " Uncofirmed: " + bad.ToString(), false);
                    Application.DoEvents();

                }
            }

        //experimental
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

        //confirm account with link
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

        }   


    [Serializable]
    public class Logins
    {
        //instance to work
        public static Logins instance;
        public List<LoginEntry> loginsList;

        //empty init
        public Logins()
        {
            this.loginsList = new List<LoginEntry>();
        }

        //init from XML
        public Logins(string path)
        {
            this.loginsList = Logins.LoadFromFile(path);
        }

        //one account
        public class LoginEntry
        {
            public string email, password, isRegistered;
        }

        //make pairs email-pass from different emails list
        public static Logins GetLogins(List<String> inputEmails, bool randomPass, string pass = "defaultPass1")
        {
            Random rand = new Random();
            Logins list = new Logins();
            foreach (var email in inputEmails )
            {
                var entry = new Logins.LoginEntry();
                entry.email = email;
                entry.password = (randomPass) ? GetPass(rand) : pass; //random pass or same to each entry
                entry.isRegistered = "false";//not registered yet
                list.loginsList.Add(entry);
            }

            return list;
        }

        //make pairs login-pass from one gmail account
        public static Logins GetLogins(String inputEmail, int num, bool randomPass, string pass = "defaultPass1")
        {
            Logins list = new Logins();
            var baseEmail = inputEmail.Remove(inputEmail.LastIndexOf('@'));//remove domain
            var mask = new BitArray(new bool[baseEmail.Length - 1]);//bitmask
            var entry = new List<string>();
            int curr = 1;
            while (entry.Count < num)
            {
                string resString = baseEmail;
                var b = new BitArray(new int[] { curr });//bitmask from int
                for (int nu = 0; nu < mask.Count; nu++)
                {
                    mask[nu] = b[nu];

                }

                for (int i = mask.Length; i >= 1; i--)
                {
                    if (mask.Get(i - 1)) resString = resString.Insert(i, ".");//insert '.' with bitmask
                }
                
                entry.Add (resString + inputEmail.Substring(inputEmail.LastIndexOf('@')));//return domain
                curr++;
            }
            return GetLogins(entry, randomPass, pass);
            }

        //save accounts list to XML
        public static void SaveToFile(List<LoginEntry> logins, string path)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<LoginEntry>));
            using (FileStream fs = new FileStream(path, FileMode.Create)) formatter.Serialize(fs, logins);
        }

        //get accounts list from XML
        public static List<LoginEntry> LoadFromFile(string path)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<LoginEntry>));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                List<LoginEntry> logins = (List<LoginEntry>)formatter.Deserialize(fs);
                return logins;
            }
        }

        //make random pass with variable length
        public static string GetPass(Random r, int x = 8)
        {
            string pass = "";
            while (pass.Length < x)
            {
                Char c = (char)r.Next(33, 125);//letters and digits only
                if (Char.IsLetterOrDigit(c))
                    pass += c;
            }
            foreach (char c in pass)
            {
                if (Char.IsDigit(c)) return pass;//at least one digit
            }
            var cc = (char)r.Next(48, 57);//digit
            pass = pass.Remove(r.Next(0, pass.Length - 1), 1).Insert(r.Next(0, pass.Length - 1), cc.ToString());//if no digits - replace one symbol
            return pass;
        }


    }

    
}


 

   
 
       






      
    