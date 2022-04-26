using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Keys = OpenQA.Selenium.Keys;
using System.Timers;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        void submit() 
        {
            using (IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver())
            {
                driver.Manage().Window.Maximize();//窗口最大化
                string yt = "http://ehall.hytc.edu.cn/xsfw/sys/xsyqxxsjapp/*default/index.do?amp_sec_version_=1&gid_=VGhxREN2cFZwd1J6NkUzYmVCY2ZiNVlzRnVmV0pFRU03Z2MyaU03aC9VU0Zub3JueXRURXlnNk85QU80UFIxNXV4dXp0UHF6bUNlL0ZGbEJ5VkJnMlE9PQ&EMAP_LANG=zh&THEME=cherry#/mrbpa";
                driver.Navigate().GoToUrl("http://ehall.hytc.edu.cn/new/index.html");
                //driver.Url = "http://www.baidu.com"是一样的
                //
                //显示等待不能实现
                //new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id("ampHasNoLogin"))));
                //隐式等待
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                //操作
                driver.FindElement(By.Id("ampHasNoLogin")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.Id("username")).SendKeys(textBox1.Text);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("password")).SendKeys(textBox2.Text);
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//div//form//div//input[@value=\"立即登录\"]")).Click();
                Thread.Sleep(1000);

                driver.Navigate().GoToUrl(yt);
                Thread.Sleep(1000);
                //如果已经填报的测试
                try
                {
                    string urltest = "//div/table/tbody/tr/td/a[@data-action=\"编辑\"]";
                    driver.FindElement(By.XPath(urltest)).Click();
                }
                catch (Exception)
                {

                }
                //休眠等待
                Thread.Sleep(2000);
                string jkzt = "//div[@data-name=\"BRJKZT\"]/div/div";
                string jtjkqk = "//div[@data-name=\"JTCYJKZK\"]/div/div";
                string xlzk = "//div[@data-name=\"XLZK\"]/div/div";
                string zc = "//div[@role=\"listbox\"]//span[contains(text(),\"正常\")]";
                string sfjz = "//div[@data-name=\"SFJZ\"]/div/div";
                string zc2 = "//div[@role=\"listbox\"]//span[contains(text(),\"否\")]";
                string tw = "//div//input[@data-name=\"TW\"]";
                driver.FindElements(By.XPath(zc));
                Thread.Sleep(600);
                //健康状况
                driver.FindElement(By.XPath(jkzt)).Click();
                Thread.Sleep(1000);
                driver.FindElements(By.XPath(zc))[0].Click();
                Thread.Sleep(600);
                //家人健康情况
                driver.FindElement(By.XPath(jtjkqk)).Click();
                Thread.Sleep(1000);
                driver.FindElements(By.XPath(zc))[1].Click();
                Thread.Sleep(600);
                //心理状况
                driver.FindElement(By.XPath(xlzk)).Click();
                Thread.Sleep(1000);
                driver.FindElements(By.XPath(zc))[2].Click();
                Thread.Sleep(600);
                //是否就诊
                driver.FindElement(By.XPath(sfjz)).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath(zc2)).Click();
                Thread.Sleep(600);
                //体温
                driver.FindElement(By.XPath(tw)).SendKeys(Keys.PageDown);
                Thread.Sleep(1000);

                driver.FindElement(By.XPath(tw)).SendKeys(Keys.Enter);
                Thread.Sleep(1000);
                driver.FindElement(By.XPath(tw)).SendKeys("36");
                Thread.Sleep(600);
                //保存
                driver.FindElement(By.Id("save")).Click();
                Thread.Sleep(1000);
                driver.Quit();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\SnakeLogin.txt"))
            {
                int i = 0;
                using (StreamReader sr = new StreamReader(@"C:\SnakeLogin.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (i == 0)
                        {
                            textBox1.Text = line;
                            i++;
                        }
                        else if (i == 1)
                        {
                            textBox2.Text = line;
                            i++;
                        }
                    }
                }
            }
            else
            {
                FileStream fs = new FileStream(@"C:\SnakeLogin.txt", FileMode.CreateNew);
                fs.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.ToLongTimeString() == "8:00:00")
            {
                submit();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string[] names = new string[] { textBox1.Text, textBox2.Text};
            using (StreamWriter sw = new StreamWriter(@"C:\SnakeLogin.txt"))
            {
                foreach (string s in names)
                {
                    sw.WriteLine(s);
                }
                sw.Close();
                MessageBox.Show("写入成功，无需重复写入！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            submit();
        }
    }
}
