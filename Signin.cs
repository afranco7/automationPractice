using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace automationpractice
{
    [TestClass]
    public class Register
    {
        IWebDriver driver;
        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
        }
        [TestMethod]
        public void TestMethod2()
        {
            driver.Url = "http://www.automationpractice.com";
            driver.FindElement(By.XPath("//*[@id=\"header\"]/div[2]/div/div/nav/div[1]/a")).Click();
            driver.FindElement(By.Id("email")).SendKeys("testtest12@mailinator.com");
            driver.FindElement(By.Id("passwd")).SendKeys("123456");
            driver.FindElement(By.XPath("//*[@id=\"SubmitLogin\"]/span")).Click();
            string sucess = driver.FindElement(By.XPath("//*[@id=\"center_column\"]/p")).Text;
            Assert.AreEqual("Welcome to your account. Here you can manage all of your personal information and orders.", sucess);
            
        }
        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}