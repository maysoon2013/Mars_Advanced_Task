using AventStack.ExtentReports;
using Competition_Task.Utilities;
using Mars_Project.Drivers;
using MarsQaProject.Pages;
using NUnit.Framework;
using System;
using System.Diagnostics.Metrics;
using TechTalk.SpecFlow;

namespace Mars_Project.StepDefinitions
{
    [Binding]
    public class EducationStepDefinitions : CommonDriver
    {
        Educationpage educationPageObj;

        public EducationStepDefinitions()
        {
            educationPageObj = new Educationpage();

        }

        [When(@"I navigate to Education page and Add education like '([^']*)', '([^']*)', '([^']*)','([^']*)' and '([^']*)' to the profile Page\.")]
        public void WhenINavigateToEducationPageAndAddEducationLikeAndToTheProfilePage_(string University, string Country, string Title, string Degree, string GraduationYear)
        {
            educationPageObj.AddEducationSteps(driver, University, Country, Title, Degree, GraduationYear);
        }

        [Then(@"'([^']*)', '([^']*)', '([^']*)','([^']*)' and '([^']*)' should be added to the profile Page successfully\.")]
        public void ThenAndShouldBeAddedToTheProfilePageSuccessfully_(string University, string Country, string Title, string Degree, string GraduationYear)
        {
            try
            {
                test = extentreportobj.CreateTest("Add Education", "Testing add Education");
                string countryName = educationPageObj.GetCountry(driver);
                string uniName = educationPageObj.GetUniversity(driver);
                string titleName = educationPageObj.GetTitle(driver);
                //string degreeName = educationPageObj.GetDegree(driver);
                string grationYear = educationPageObj.GetYear(driver);

                Assert.That(countryName=="Bangladesh", "New education added successfully", "Addited country name and expected country name do not match");
                Assert.That(uniName=="DIU", "Addited University name and expected University name do not match");
                Assert.That(titleName=="B.Sc", "Addited Title name and expected title do not match");
                Assert.That(grationYear=="2007", "Addited Gration year and expected gradution year do not match");
                ClickScreenshots.TakeScreenshot(driver);
                test.Log(Status.Info, "Education Add successfully");
                test.Log(Status.Pass, "Test passed");
            }
            catch (Exception ex)
            {
                ClickScreenshots.TakeScreenshot(driver);
                test.Log(Status.Fail, "Test failed");
                throw;

            }
        }

        [When(@"I navigate to the Education tab and edit education like '([^']*)',and '([^']*)'")]
        public void WhenINavigateToTheEducationTabAndEditEducationLikeAnd(string University, string Degree)
        {
            educationPageObj.EditEducationSteps(driver, University, Degree);
        }

        [Then(@"University and degree should be edited successfully")]
        public void ThenUniversityAndDegreeShouldBeEditedSuccessfully()
        {
            try 
            {
            test = extentreportobj.CreateTest("Edit Education", "Testing Edit Education");
            string updateUniName = educationPageObj.GetUpdateUniname(driver);
            string updateDegreename = educationPageObj.GetUpdateDegreeName(driver);

            Assert.That(updateUniName=="MIT", "Edited University name and expected University name do not match");
            Assert.That(updateDegreename=="BIS", "Edited University name and expected University name do not match");
            ClickScreenshots.TakeScreenshot(driver);
            test.Log(Status.Info, "Education Edited successfully");
            test.Log(Status.Pass, "Test passed");
            }
            catch (Exception ex)
            {
                ClickScreenshots.TakeScreenshot(driver);
                test.Log(Status.Fail, "Test failed");
                throw;

            }
        }

        [When(@"I navigte to Education Tab and delete education record")]
        public void WhenINavigteToEducationTabAndDeleteEducationRecord()
        {
            educationPageObj.DeleteEducationStep();
        }

        [Then(@"Education record should be deleted successfully")]
        public void ThenEducationRecordShouldBeDeletedSuccessfully()
        {
            try
            {
            test = extentreportobj.CreateTest("Delete Education", "Testing Delete Education");
            educationPageObj.GetDeletedEducation(driver);
            ClickScreenshots.TakeScreenshot(driver);
            test.Log(Status.Info, "Education deleted successfully");
            test.Log(Status.Pass, "Test passed");

            }
         catch (Exception ex)
            {
                ClickScreenshots.TakeScreenshot(driver);
                test.Log(Status.Fail, "Test failed");
                throw;

            }
}


    }

}
