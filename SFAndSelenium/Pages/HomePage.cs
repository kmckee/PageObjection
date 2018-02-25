using PageObjection;

namespace SFAndSelenium
{
    public class HomePage : PageObject
    {
        public override string Url => "http://awful-valentine.com/";

        public void ContactUs()
        {
            Browser.FindElementByLinkText("Contact Us").Click();
        }
    }
}
