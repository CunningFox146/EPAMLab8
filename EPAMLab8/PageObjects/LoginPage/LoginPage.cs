using EPAMLab8.Utils;
using OpenQA.Selenium;

namespace EPAMLab8.PageObjects
{
    public class LoginPage : BasePageObject
    {
        public IWebElement EmailField => Driver.FindElement(UIMap.EmailField);
        public IWebElement PasswordField => Driver.FindElement(UIMap.PasswordField);
        public IWebElement LogInButton => Driver.FindElement(UIMap.LogInButton);

        public IWebElement GetLogo() => WaitUtil.WaitForElement(UIMap.Logo);

        public LoginPage(IWebDriver driver) : base(driver) { }

        public LoginPage WriteEmail(string email)
        {
            EmailField.SendKeys(email);
            return this;
        }

        public LoginPage WritePassword(string password)
        {
            PasswordField.SendKeys(password);
            return this;
        }

        public LoginPage LogIn()
        {
            LogInButton.Click();
            return this;
        }
    }
}
