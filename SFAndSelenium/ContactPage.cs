using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;

namespace SFAndSelenium
{
    public class ContactPage : PageObject
    {
        public ContactPage(ChromeDriver webDriver) : base(webDriver)
        { }

        public override string Url => "http://awful-valentine.com/contact-us";
    }
}
