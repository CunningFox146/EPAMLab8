using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text;
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

        private By _logo = By.CssSelector("a[href='/app/']");
        private By _marketTab = By.CssSelector(".ordTypes > li[data-tab-index='1']");
        private By _valueField = By.CssSelector("div.market input#notionalValue");
        private By _buyMarketButton = By.CssSelector(".col-xs-6 .btnWrapper button.buy");
        private By _buyConfirmButton = By.ClassName("dialogConfirm");
        private By _notification = By.CssSelector(".notifications .notification");
        private By _positions = By.CssSelector(".basicOrdersAndPositionsWrapper .active  .innerTitle");

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

        [Test, Order(1)]
        public void LogInTest()
        {
            var email = Driver.FindElement(_emailField);
            email.SendKeys("makar.papca@gmail.com");

            var password = Driver.FindElement(_passwordField);
            password.SendKeys("Cunning84");

            var login = Driver.FindElement(_ligInButton);
            login.Click();
            Assert.DoesNotThrow(() => Driver.FindElement(_logo));
        }

        [Test, Order(2)]
        public void BuyWithInvalidValueTest()
        {
            var marketTab = WaitForElement(_marketTab);

            marketTab.Click();

            var valueField = WaitForElement(_valueField);

            int notificationsCount = Driver.FindElements(_notification).Count;

            valueField.Clear();
            valueField.SendKeys("5");

            Driver.FindElement(_logo).Click();

            Assert.AreNotEqual(notificationsCount, Driver.FindElements(_notification).Count);
        }

        [Test, Order(3)]
        public void BuyWithValidValueTest()
        {
            string text = Driver.FindElement(_positions).Text;
            int countIndex = text.IndexOf('[') + 1;
            int count = (int)char.GetNumericValue(text[countIndex]);
            var textBuilder = new StringBuilder(text);
            textBuilder[countIndex] = $"{count + 1}"[0];
            string targetText = textBuilder.ToString();

            var valueField = WaitForElement(_valueField);
            valueField.Clear();
            valueField.SendKeys("100");

            var buyButton = Driver.FindElement(_buyMarketButton);
            buyButton.Click();

            var confirmButton = WaitForElement(_buyConfirmButton);
            confirmButton.Click();

            var xpathSelector = $"//span[text()='{targetText}']";
            Assert.DoesNotThrow(() => WaitForElement(By.XPath(xpathSelector)));
        }

        private static IWebElement WaitForElement(By element)
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(Driver => Driver.FindElement(element));
        }
    }
}