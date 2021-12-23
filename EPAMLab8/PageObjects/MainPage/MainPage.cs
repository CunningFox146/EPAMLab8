using EpamLab8.Tests;
using EPAMLab8.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.ObjectModel;

namespace EPAMLab8.PageObjects
{
    public class MainPage : BasePageObject
    {
        public IWebElement SuccessSellButton => Driver.FindElement(UIMap.SuccessSellButton);

        public OrderElement OrderElement { get; private set; }

        public bool IsSuccessSellButtonDisabled => !string.IsNullOrEmpty(SuccessSellButton.GetDomProperty("disabled"));

        public MainPage(IWebDriver driver) : base(driver)
        {
            OrderElement = new OrderElement(driver);
        }

    }
}
