using EPAMLab8.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;

namespace EpamLab8.Tests
{
    [TestFixture]
    public class Test : TestsBase
    {
        public Test() : base("https://testnet.bitmex.com/login") { }

        [Test, Order(1)]
        public void LogInTest()
        {
            var loginPage = new LoginPage(Driver)
                .WriteEmail("makar.papca@gmail.com")
                .WritePassword("Cunning84")
                .LogIn();

            Assert.DoesNotThrow(() => loginPage.GetLogo());
        }

        [Test, Order(2)]
        public void BuyWithInvalidValueTest()
        {
            var mainPage = new MainPage(Driver);

            mainPage.OrderElement.OpenTab(OrderType.Market)
                .WriteValueField("0");

            Assert.True(mainPage.IsSuccessSellButtonDisabled);
        }
    }
}