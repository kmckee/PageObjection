using OpenQA.Selenium.Chrome;
using System;

namespace PageObjection
{
    public class PageFactory
    {
        private ChromeDriver Browser
        {
            get { return BrowserSingleton.Instance; }
        }

        public T Visit<T>()
            where T : PageObject, new()
        {
            var instance = new T();
            Browser.Url = instance.Url;
            return instance;
        }

        public void Visit<T>(Action<T> action)
            where T : PageObject, new()
        {
            var instance = new T();
            Browser.Url = instance.Url;
            action(instance);
        }

        public T On<T>()
            where T : PageObject, new()
        {
            return new T();
        }

        public void On<T>(Action<T> action)
            where T : PageObject, new()
        {
            var instance = new T();
            action(instance);
        }

        private int WaitTimeoutMs = 10000;
        private int WaitTestInterval = 50;
        public void WaitUntil(Func<bool> test)
        {
            var totalWait = 0;
            while (totalWait < WaitTimeoutMs)
            {
                var result = test();
                if (result) { break; }
                System.Threading.Thread.Sleep(WaitTestInterval);
            }
            if(test() == false)
            {
                throw new OpenQA.Selenium.WebDriverTimeoutException("WaitUntil waited the maximum amount of time, but the condition never passed.");
            }
        }
    }
}