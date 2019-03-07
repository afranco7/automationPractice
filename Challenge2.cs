using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace automationpractice
{
    [TestClass]
    public class Challenge2
    {
        IWebDriver dri;
        WebDriverWait dri1;

        [TestInitialize]
        public void TestInitialize()
        {
            dri = new ChromeDriver();
            dri1 = new WebDriverWait(dri, new TimeSpan(1));
        }

        [TestMethod]
        public void TestMethod1()
        {
            dri.Url = "http://automationpractice.com/index.php?";                
            dri.FindElement(By.ClassName("header_user_info")).Click();
            dri.FindElement(By.Id("email_create")).SendKeys("Harry_mail@Maily.com");
            dri.FindElement(By.XPath("//*[@id=\"SubmitCreate\"]")).Click();
            dri.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            dri.FindElement(By.Id("id_gender1")).Click();
            dri.FindElement(By.Id("customer_firstname")).SendKeys("Poopy");
            dri.FindElement(By.Id("customer_lastname")).SendKeys("Butthole");
            dri.FindElement(By.Id("passwd")).SendKeys("Showmewhatyougot");
            dri.FindElement(By.Id("address1")).SendKeys("123 fake St.");
            dri.FindElement(By.Id("city")).SendKeys("Houston");
            new SelectElement(dri.FindElement(By.Id("id_state"))).SelectByValue("43");
            dri.FindElement(By.Id("postcode")).SendKeys("73301");
            dri.FindElement(By.Id("phone_mobile")).SendKeys("3057999700");
            dri.FindElement(By.Id("submitAccount")).Click();
            String verificacion=dri.FindElement(By.ClassName("info-account")).Text;
            Assert.AreEqual("Welcome to your account. Here you can manage all of your personal information and orders.", verificacion);
            dri.FindElement(By.ClassName("logout")).Click();


            


        }

        [TestCleanup]
        public void TestCleanup()
        {
            dri.Quit();
            
        }
    }
}
