﻿using PageObjection;
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

        [When(@"I enter my name as ""(.*)""")]
        public void WhenIEnterMyNameAs(string name)
        {
            On<ContactPage>().Name = name;
        }

        [Then(@"I see a contact form")]
        public void ThenISeeAContactForm()
        {
            Assert.True(On<ContactPage>().IsLoaded);
        }

        [Then(@"my name is ""(.*)""")]
        public void ThenMyNameIs(string expected)
        {
            Assert.That(On<ContactPage>().Name, Is.EqualTo(expected));
        }

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

        [Then(@"I see an error: ""(.*)""")]
        public void ThenISeeAnError(string expectedError)
        {
            var actual = On<ContactPage>().ErrorMessage;
            Assert.True(On<ContactPage>().ErrorMessage.Contains(expectedError));
        }

        [When(@"I enter my information succinctly:")]
        public void WhenIEnterMyInformationSuccinctly(Table table)
        {
            // TODO
            //On<ContactPage>().PopulatePageWith(table.AsPageObjectionTable());
        }
    }
}
