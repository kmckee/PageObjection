using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SFAndSelenium
{
    public class HomePage : PageObject
    {
        public override string Url => "http://awful-valentine.com/";
        public HomePage(ChromeDriver webDriver) : base(webDriver)
        { }

        public void ContactUs()
        {
            Browser.FindElementByLinkText("Contact Us").Click();
        }

        public string Name
        {
            get { return Browser.FindElementByName("your-name").Text; }
            set { Browser.FindElementByName("your-name").SendKeys(value); }
        }
    }
}
