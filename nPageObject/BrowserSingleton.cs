using OpenQA.Selenium.Chrome;

namespace nPageObject
{
    public static class BrowserSingleton
    {
        private static ChromeDriver _instance;
        public static ChromeDriver Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ChromeDriver();
                }
                return _instance;
            }
            set { _instance = value; }
        }
    }
}
