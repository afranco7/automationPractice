using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace Automation02
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
            int id = (new Random()).Next(1000);
            string email = $"myemailforus{id}@server.com";
            driver.Url = "http://www.automationpractice.com";
            driver.FindElement(By.XPath("//*[@id=\"header\"]/div[2]/div/div/nav/div[1]/a")).Click();
            driver.FindElement(By.Id("email_create")).SendKeys(email);
            driver.FindElement(By.Id("SubmitCreate")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("customer_firstname")).SendKeys("Test One");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("Test Two");
            driver.FindElement(By.Id("passwd")).SendKeys("123456");
            new SelectElement(driver.FindElement(By.Id("days"))).SelectByValue("1");
            new SelectElement(driver.FindElement(By.Id("months"))).SelectByValue("8");
            new SelectElement(driver.FindElement(By.Id("years"))).SelectByValue("1969");
            driver.FindElement(By.Id("newsletter")).Click();
            driver.FindElement(By.Id("optin")).Click();
            driver.FindElement(By.Id("firstname")).SendKeys("Test One");
            driver.FindElement(By.Id("lastname")).SendKeys("Test Two");
            driver.FindElement(By.Id("company")).SendKeys("Testing");
            driver.FindElement(By.Id("address1")).SendKeys("141 Large Avenue");
            driver.FindElement(By.Id("city")).SendKeys("Miami");
            new SelectElement(driver.FindElement(By.Id("id_state"))).SelectByValue("9");
            driver.FindElement(By.Id("postcode")).SendKeys("14111");
            new SelectElement(driver.FindElement(By.Id("id_country"))).SelectByValue("21");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("3569874563");
            driver.FindElement(By.XPath("//*[@id=\"submitAccount\"]/span")).Click();
            Thread.Sleep(6000);
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
