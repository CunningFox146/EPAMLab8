using EPAMLab8.Utils;
using OpenQA.Selenium;

namespace EPAMLab8.PageObjects
{
    public partial class OrderElement : BasePageElement
    {
        private OrderType _orderType = OrderType.Market;

        public IWebElement LimitOrderTab => WaitUtil.WaitForElement(UIMap.LimitTab);
        public IWebElement MarketOrderTab => WaitUtil.WaitForElement(UIMap.MarketTab);
        public IWebElement MarketStopOrderTab => WaitUtil.WaitForElement(UIMap.MarketStopTab);

        public IWebElement MarketValueField => WaitUtil.WaitForElement(UIMap.MarketValueField);

        public OrderType CurrentOrderType => _orderType;

        public OrderElement(IWebDriver driver) : base(driver) { }

        public OrderElement OpenTab(OrderType type)
        {
            if (type == _orderType) return this;

            _orderType = type;

            IWebElement tabButton;
            switch (_orderType)
            {
                case OrderType.Limit:
                    tabButton = LimitOrderTab;
                    break;
                case OrderType.Market:
                    tabButton = MarketOrderTab;
                    break;
                default:
                    tabButton = MarketStopOrderTab;
                    break;
            }

            tabButton.Click();

            return this;
        }

        public OrderElement WriteValueField(string value)
        {
            MarketValueField.SendKeys(value);
            return this;
        }
    }
}
