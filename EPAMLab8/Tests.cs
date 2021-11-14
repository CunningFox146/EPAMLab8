using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace EpamLab8
{
    [TestFixture]
    public class Test
    {
        public static IWebDriver Driver;

        private By _emailField = By.Id("email");
        private By _passwordField = By.Id("password");
        private By _ligInButton = By.CssSelector("button[type='submit']");

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--ignore-certificate-errors");
            options.AddArguments("--ignore-ssl-errors");

            Driver = new ChromeDriver(options);
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            Driver.Navigate().GoToUrl("https://testnet.bitmex.com/login");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Driver.Quit();
        }

        [SetUp] // вызывается перед каждым тестом
        public void SetUp()
        {
            // ТУТ КОД
        }

        [TearDown] // вызывается после каждого теста
        public void TearDown()
        {
            // ТУТ КОД
        }

        [Test]
        public void LogInTest()
        {
            var email = Driver.FindElement(_emailField);
            email.SendKeys("makar.papca@gmail.com");

            var password = Driver.FindElement(_passwordField);
            password.SendKeys("Cunning84");

            var login = Driver.FindElement(_ligInButton);
            login.Click();

            Thread.Sleep(5000);
        }

        [Test]
        public void TEST_2()
        {
            // ТУТ КОД
        }
    }
}