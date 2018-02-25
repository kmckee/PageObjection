using nPageObject;

namespace SFAndSelenium
{
    public class HomePage : PageObject
    {
        public override string Url => "http://awful-valentine.com/";

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
