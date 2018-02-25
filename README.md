# PageObjection

A few methods to make Cucumber testing with SpecFlow and Selenium easier.

## Setup

Make your steps inherit from `PageFactory`:
```csharp
using PageObjection;
using NUnit.Framework;
using TechTalk.SpecFlow;

using SFAndSelenium.Pages;

namespace SFAndSelenium.Steps
{
    [Binding]
    public class BasicSteps : PageFactory
    {
        // ...
    }
}
```

Make your page objects inherit from `PageObject`:
```csharp
using PageObjection;

namespace SFAndSelenium.Pages
{
    public class ContactPage : PageObject
    {
        public override string Url => "http://awful-valentine.com/contact-us/";
        
        // ...
        
    }
}
```

### Navigation Helpers

In your step files, you'll have a few helper methods available to you including `On<YourPage>` and `Visit<YourPage>`.  

These methods can be used to create instances of your page objects, which you can then use to automate the page:
```csharp
using PageObjection;
using NUnit.Framework;
using TechTalk.SpecFlow;

using SFAndSelenium.Pages;

namespace SFAndSelenium.Steps
{
    [Binding]
    public class BasicSteps : PageFactory
    {
        [Given(@"I am browsing for an awful valentine")]
        public void GivenIAmBrowsingForAnAwfulValentine()
        {
            Visit<HomePage>();
        }

        [When(@"I choose to contact someone")]
        public void WhenIChooseToContactSomeone()
        {
            On<HomePage>().ContactUs();
        }

        [Then(@"I see a contact form")]
        public void ThenISeeAContactForm()
        {
            Assert.True(On<ContactPage>().IsLoaded);
        }

        [When(@"I enter my name as ""(.*)""")]
        public void WhenIEnterMyNameAs(string name)
        {
            On<ContactPage>().Name = name;
        }

        [Then(@"my name is ""(.*)""")]
        public void ThenMyNameIs(string expected)
        {
            Assert.That(On<ContactPage>().Name, Is.EqualTo(expected));
        }
        
        // ...
        
    }
}
```

As you can see, `On` and `Visit` return an instance of the specified PageObject that's ready to use.

If you need to do multiple things with the page, rather than a single action, you can pass an Action function into both `On` and `Visit` like so:

```csharp
[When(@"I enter my information:")]
public void WhenIEnterMyInformation(Table table)
{
    var details = table.Rows[0];
    On<ContactPage>((page) =>
    {
        page.Name = details["Name"];
        page.Email = details["Email"];
        page.Subject = details["Subject"];
        page.Message = details["Message"];
    });
}
```

Waiting for something to happen can be achieved using the `WaitUntil` function like so:
```csharp
// Step Definition:
[When(@"I submit the following contact request:")]
public void WhenISubmitTheFollowingContactRequest(Table table)
{
    var details = table.Rows[0];
    Visit<ContactPage>((page) =>
    {
        page.Name = details["Name"];
        page.Email = details["Email"];
        page.Subject = details["Subject"];
        page.Message = details["Message"];
        page.Send();
        WaitUntil(() => { return page.IsWorking() == false; });
    });
}

// Page Object:
public class ContactPage : PageObject
{
    // ...
    public bool IsWorking()
    {
        return Browser.FindElementByClassName("ajax-loader").Displayed;
    }
}
```


