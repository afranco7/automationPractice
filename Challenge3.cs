using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace automationpractice
{
    [TestClass]
    public class Challenge3
    {
        IWebDriver dri;

        [TestInitialize]
        public void TestInitialize()
        {
            dri = new ChromeDriver();
        }
        [TestMethod]
        public void TestMethod1()
        {
            dri.Url = "http://automationpractice.com/index.php?";
            dri.FindElement(By.ClassName("header_user_info")).Click();
            dri.FindElement(By.Id("email")).SendKeys("Harry_mail@Maily.com");
            dri.FindElement(By.Id("passwd")).SendKeys("Showmewhatyougot");
            dri.FindElement(By.XPath("//*[@id=\"SubmitLogin\"]/span")).Click();
            dri.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            string verificacion = dri.FindElement(By.ClassName("info-account")).Text;
            Assert.AreEqual("Welcome to your account. Here you can manage all of your personal information and orders.", verificacion);


        }

        [TestCleanup]
        public void TestCleanup()
        {
            dri.Quit();

        }
    }

}
