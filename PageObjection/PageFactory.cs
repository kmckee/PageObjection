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
    }
}