using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFAndSelenium
{
    public abstract class PageObject
    {
        public abstract string Url { get; }
        public ChromeDriver Browser { get; }

        public PageObject(ChromeDriver webDriver)
        {
            Browser = webDriver;
        }

        public bool IsLoaded {  get { return Browser.Url == this.Url; } }
    }
}
