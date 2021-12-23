using OpenQA.Selenium;

namespace EPAMLab8.PageObjects
{
    public class BasePageElement
    {
        protected IWebDriver _driver;
        public IWebDriver Driver => _driver;

        public BasePageElement(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
