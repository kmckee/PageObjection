using OpenQA.Selenium.Chrome;

namespace nPageObject
{
    public abstract class PageObject
    {
        public abstract string Url { get; }
        public ChromeDriver Browser { get { return BrowserSingleton.Instance; } }

        public bool IsLoaded {  get { return Browser.Url == Url; } }
    }
}
