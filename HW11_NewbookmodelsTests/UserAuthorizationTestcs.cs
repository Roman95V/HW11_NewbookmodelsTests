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
    class UserAuthorizationTestcs
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
        public void CheckSuccessfulUserAuthorization()
        {
            //email    sosixo6385@quossum.com
            //password @123Will@

            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");

            _webDriver.FindElement(By.CssSelector("[name = email]")).SendKeys("sosixo6385@quossum.com");

            _webDriver.FindElement(By.CssSelector("[name = password]")).SendKeys("@123Will@");

            _webDriver.FindElement(By.CssSelector(".SignInForm__submitButton--cUdOV")).Click();

            var result = _webDriver.Url;

            Thread.Sleep(3000);

            Assert.AreEqual("https://newbookmodels.com/explore", result);

        }
        [Test]
        public void CheckUserAccountBlockMessage()
        {
            //email  WillSmith@gmail.com  Oksana89pys@gmail.com
            //password 123Qwe@321  Oks@n@89

            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");

            _webDriver.FindElement(By.CssSelector("[name = email]")).SendKeys("WillSmith@gmail.com");

            _webDriver.FindElement(By.CssSelector("[name = password]")).SendKeys("123Qwe@321");

            _webDriver.FindElement(By.CssSelector(".SignInForm__submitButton--cUdOV")).Click();

            var actualMessage = By.CssSelector("div.FormErrorText__error---nzyq:nth-child(1) > div:nth-child(1)");
            Thread.Sleep(3000);

            Assert.AreEqual("User account is blocked.", actualMessage);

        }

    }
}
    