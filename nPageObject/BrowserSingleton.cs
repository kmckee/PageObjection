using OpenQA.Selenium.Chrome;

namespace nPageObject
{
    public static class BrowserSingleton
    {
        private static readonly Destructor Finalise = new Destructor();
        private sealed class Destructor
        {
            ~Destructor()
            {
                // One time only destructor.
                _instance.Close();
            }
        }

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
