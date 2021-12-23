using EpamLab8.Tests;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace EPAMLab8.Utils
{
    public static class WaitUtil
    {
        public static IWebElement WaitForElement(By element, double seconds = 10)
        {
            return new WebDriverWait(TestsBase.Driver, TimeSpan.FromSeconds(seconds))
                .Until(Driver => Driver.FindElement(element));
        }
    }
}
