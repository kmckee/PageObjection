using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SFAndSelenium
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

        [When(@"I enter my name as ""(.*)""")]
        public void WhenIEnterMyNameAs(string name)
        {
            On<HomePage>().Name = name;
        }

        [Then(@"I see a contact form")]
        public void ThenISeeAContactForm()
        {
            Assert.True(On<ContactPage>().IsLoaded);
        }

        [Then(@"my name is ""(.*)""")]
        public void ThenMyNameIs(string expected)
        {
            Assert.That(On<HomePage>().Name, Is.EqualTo(expected));
        }

    }
}
