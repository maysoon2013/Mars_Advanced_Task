using Competition_Task.Utilities;
using Mars_Project.Drivers;
using Mars_Project_Advanced_Task.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Mars_Project.StepDefinitions
{
    [Binding]
    public class ProfileAvailabilityStepDefinitions:CommonDriver
    {
        Profile_Availability profileAviabilityObj;
        public ProfileAvailabilityStepDefinitions()
        {
            profileAviabilityObj = new Profile_Availability();
        }
        [When(@"I add profile availability in my profile")]
        public void WhenIAddProfileAvailabilityInMyProfile()
        {
            profileAviabilityObj.addAvailability(driver);
        }

        [Then(@"The Aviability should be added successfully")]
        public void ThenTheAviabilityShouldBeAddedSuccessfully()
        {
            string availability = profileAviabilityObj.GetAvailavility(driver);
            Assert.That(availability=="Full Time", "added availability is not match");
            ClickScreenshots.TakeScreenshot(driver);



        }
    }
}
