using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;

namespace EpamLab8
{
    [TestFixture]
    public class Test
    {
        public static IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--ignore-certificate-errors");
            options.AddArguments("--ignore-ssl-errors");

            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
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
        public void TEST_1()
        {
            // ТУТ КОД
        }

        [Test]
        public void TEST_2()
        {
            // ТУТ КОД
        }
    }
}