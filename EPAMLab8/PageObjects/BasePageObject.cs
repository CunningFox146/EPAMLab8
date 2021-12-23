using OpenQA.Selenium;

namespace EPAMLab8.PageObjects
{
    public class BasePageObject
    {
        protected IWebDriver _driver;
        public IWebDriver Driver => _driver;

        public BasePageObject(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
