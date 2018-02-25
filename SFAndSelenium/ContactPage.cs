using nPageObject;

namespace SFAndSelenium
{
    public class ContactPage : PageObject
    {
        public override string Url => "http://awful-valentine.com/contact-us/";

        public string Name
        {
            get { return Browser.FindElementByName("your-name").GetAttribute("value"); }
            set { Browser.FindElementByName("your-name").SendKeys(value); }
        }

        public string Email
        {
            get { return Browser.FindElementByName("your-email").GetAttribute("value"); }
            set { Browser.FindElementByName("your-email").SendKeys(value); }
        }

        public string Subject
        {
            get { return Browser.FindElementByName("your-subject").GetAttribute("value"); }
            set { Browser.FindElementByName("your-subject").SendKeys(value); }
        }

        public string Message
        {
            get { return Browser.FindElementByName("your-message").GetAttribute("value"); }
            set { Browser.FindElementByName("your-message").SendKeys(value); }
        }
    }
}
