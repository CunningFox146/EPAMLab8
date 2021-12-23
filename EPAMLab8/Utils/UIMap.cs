using OpenQA.Selenium;

namespace EPAMLab8.Utils
{
    public static class UIMap
    {
        public static By EmailField => By.Id("email");
        public static By PasswordField => By.Id("password");
        public static By LogInButton => By.CssSelector("button[type='submit']");
        public static By Logo => By.CssSelector("a[href='/app/']");

        public static By LimitTab => By.CssSelector(".ordTypes > li[data-tab-index='0']");
        public static By MarketTab => By.CssSelector(".ordTypes > li[data-tab-index='1']");
        public static By MarketStopTab => By.CssSelector(".ordTypes > li[data-tab-index='2']");

        public static By MarketValueField => By.CssSelector("input#notionalValue");
        public static By Notification => By.CssSelector(".notifications .notification");
        public static By SuccessSellButton => By.CssSelector(".btn-success");
    }
}
