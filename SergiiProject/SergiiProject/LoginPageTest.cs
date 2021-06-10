using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SergiiProject
{
    public class LoginPageTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Verify_real_user_credential()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Url = "http://localhost:64177/Login";
            webDriver.FindElement(By.Id("login")).SendKeys("test");
            webDriver.FindElement(By.Id("password")).SendKeys("newyork1");
            webDriver.FindElements(By.Id("login"))[1].Click();
            string actualUrl = webDriver.Url;
            Assert.AreEqual("http://localhost:64177/Deposit", actualUrl);
            webDriver.Quit();
        }

        [Test]
        public void Verify_if_password_accepted_empty()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Url = "http://localhost:64177/Login";
            webDriver.FindElement(By.Id("login")).SendKeys("test");
            webDriver.FindElements(By.Id("login"))[1].Click();
            string actualError = webDriver.FindElement(By.Id("errorMessage")).Text;
            Assert.AreEqual("User name and password cannot be empty!", actualError);
            webDriver.Quit();
        }
    }
}