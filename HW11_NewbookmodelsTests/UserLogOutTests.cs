using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace HW11_NewbookmodelsTests
{
    class UserLogOutTests
    {
        private IWebDriver _webDriver;
        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new FirefoxConfig());
            _webDriver = new FirefoxDriver();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);

        }
        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }
        [Test]
        public void CheckSuccessfulUserLogOut()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");

            _webDriver.FindElement(By.CssSelector("[name = email]")).SendKeys("sosixo6385@quossum.com");

            _webDriver.FindElement(By.CssSelector("[name = password]")).SendKeys("@123Will@");

            _webDriver.FindElement(By.CssSelector(".SignInForm__submitButton--cUdOV")).Click();

            
            _webDriver.FindElement(By.CssSelector(".AvatarClient__avatar--3TC7_")).Click();

            _webDriver.FindElement(By.CssSelector(".link_type_logout")).Click();

            var result = _webDriver.Url;

            Thread.Sleep(3000);

            Assert.AreEqual("https://newbookmodels.com/auth/signin", result);

        }
    }
}
