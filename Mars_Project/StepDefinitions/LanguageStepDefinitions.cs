using AventStack.ExtentReports;
using Competition_Task.Utilities;
using Mars_Project.Drivers;
using MarsQaProject.Pages;
using NUnit.Framework;
using RazorEngine;
using System;
using System.Reflection.Emit;
using TechTalk.SpecFlow;

namespace Mars_Project.StepDefinitions
{
    [Binding]
    public class LanguageStepDefinitions : CommonDriver
    {
        LoginPage loginPageObj;
        LanguagePage languagepageObj;

        public LanguageStepDefinitions()
        {
            loginPageObj = new LoginPage();
            languagepageObj = new LanguagePage();
        }

        [When(@"I navigate to the language page and add '([^']*)' and '([^']*)' and click on add button")]
        public void WhenINavigateToTheLanguagePageAndAddAndAndClickOnAddButton(string Language, string level)
        {
            languagepageObj.Addlanguage(driver, Language, level);

        }


        [Then(@"The record of '([^']*)' and '([^']*)' should be added successfully\.")]
        public void ThenTheRecordOfAndShouldBeAddedSuccessfully_(string Language, string level)

        {
            try
            {
                test = extentreportobj.CreateTest("Add Language", "Testing Add Language");
                string languageName = languagepageObj.GetLanguage(driver);
                string levelName = languagepageObj.GetLevel(driver);
                Assert.That(languageName == Language, "Language name added successfully,Test passed", "Addited language name do not match with expected language");
                Assert.That(levelName == level, "Level name added successfully, Test passed", "Addited level name do not match expected level");
                ClickScreenshots.TakeScreenshot(driver);
                test.Log(Status.Info, "Language Added successfully");
                test.Log(Status.Pass, "Test passed");
            }
            catch (Exception ex)
            {
                ClickScreenshots.TakeScreenshot(driver);
                test.Log(Status.Fail, "Test failed");
                throw;

            }
        }

        [When(@"I navigate to the language page and Edit'([^']*)' and '([^']*)'")]
        public void WhenINavigateToTheLanguagePageAndEditAnd(string Language, string level)
        {

            languagepageObj.Editlanguage(driver, Language, level);

        }

        [Then(@"'([^']*)' and '([^']*)' should be edited successfully")]
        public void ThenAndShouldBeEditedSuccessfully(string Language, string level)
        {
            try
            {
            test = extentreportobj.CreateTest("Edit Language", "Testing Edit Language");
            string updateLanguageName = languagepageObj.GetEditLanguage(driver);
            string updateLevelName = languagepageObj.GetEditLevel(driver);
            Assert.That(updateLanguageName == "English", "Language name edited successfully,Test passed", "Edited language name do not match with expected language");
            Assert.That(updateLevelName == "Basic", "Level name edited successfully, Test passed", "Edited level name do not match expected level");
            ClickScreenshots.TakeScreenshot(driver);
            test.Log(Status.Info, "Language Edited successfully");
            test.Log(Status.Pass, "Test passed");
            }
            catch (Exception ex)
            {
                ClickScreenshots.TakeScreenshot(driver);
                test.Log(Status.Fail, "Test failed");
                throw;

            }

        }


        [When(@"I navigate to language page and Delete '([^']*)' from profile page")]
        public void WhenINavigateToLanguagePageAndDeleteFromProfilePage(string Language)
        {
            languagepageObj.Deletelanguage(driver, Language);
        }


        [Then(@"The '([^']*)' should be deleted successfully")]
        public void ThenTheShouldBeDeletedSuccessfully(string language)
        {
            try 
            {
            test = extentreportobj.CreateTest("Delete Language", "Testing Delete Language");
            languagepageObj.GetDeletedLanguage(driver, language);
            ClickScreenshots.TakeScreenshot(driver);
            test.Log(Status.Info, "Language Deleted successfully");
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












    



