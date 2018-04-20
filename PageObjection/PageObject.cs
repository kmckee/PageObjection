using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace PageObjection
{
    public abstract class PageObject
    {
        public abstract string Url { get; }
        public ChromeDriver Browser { get { return BrowserSingleton.Instance; } }

        public bool IsLoaded {  get { return Browser.Url == Url; } }

        public IWebElement QuerySelector(string querySelector)
        {
            return Browser.FindElementByCssSelector(querySelector);
        }

        public ReadOnlyCollection<IWebElement> QuerySelectorAll(string querySelector)
        {
            return Browser.FindElementsByCssSelector(querySelector);
        }
    }
}
