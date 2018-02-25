using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace nPageObject
{
    public class PageFactory
    {
        public static ChromeDriver Browser { get; set; }

        static PageFactory()
        {
            Browser = new ChromeDriver();
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