using OpenQA.Selenium;
using System;

namespace SFAndSelenium
{
    public class PageFactory
    {
        public static IWebDriver Browser { get; set; }

        static PageFactory()
        {
            Browser = new OpenQA.Selenium.Chrome.ChromeDriver();
        }

        public T Visit<T>()
            where T : PageObject
        {
            var instance = Activator.CreateInstance(typeof(T), Browser) as T;
            Browser.Url = instance.Url;
            return instance;
        }

        public T On<T>()
            where T : PageObject
        {
            return Activator.CreateInstance(typeof(T), Browser) as T;
        }
    }
}