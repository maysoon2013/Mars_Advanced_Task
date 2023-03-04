using AventStack.ExtentReports;
using Competition_Task.Utilities;
using Mars_Project.Drivers;
using MarsQaProject.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Mars_Project.StepDefinitions
{
    [Binding]
    public class CertificationStepDefinitions : CommonDriver
    {

        CertificationPage certificationPageObj;
        public CertificationStepDefinitions()
        {

            certificationPageObj = new CertificationPage();

        }

        [When(@"I navigate to Certification Page and click on Add new and enter '([^']*)', '([^']*)' select year and click on add")]
        public void WhenINavigateToCertificationPageAndClickOnAddNewAndEnterSelectYearAndClickOnAdd(string Certificate, string CertifiedFrom)
        {
            certificationPageObj.AddCertificateSteps(driver, Certificate, CertifiedFrom);
        }

        [Then(@"The certication should be added successfully")]
        public void ThenTheCerticationShouldBeAddedSuccessfully()
        {
            try
            {
            test = extentreportobj.CreateTest("Add Certification", "Testing Add Certification");
            string certificateName = certificationPageObj.GetCertificate(driver);
            string certificateFrom = certificationPageObj.GetCertificateFrom(driver);
            string year = certificationPageObj.GetCompletionYear(driver);

            Assert.That(certificateName=="Tester", "Certificate name added successfully", "Addited certificate do not match with expected certificate");
            Assert.That(certificateFrom=="IndustryConnect", "Certificate from added successfully", "Addited certificate from do not match with expected certificate from");
            Assert.That(year=="2022", "Completion year added successfully", "Addited Year do not match with expected year");
            ClickScreenshots.TakeScreenshot(driver);
            test.Log(Status.Info, "Certification Added successfully");
            test.Log(Status.Pass, "Test passed");
            }
            catch (Exception ex)
            {
                ClickScreenshots.TakeScreenshot(driver);
                test.Log(Status.Fail, "Test failed");
                throw;

            }
        }

        [When(@"I navigate to the Certification tab and Edit '([^']*)' and '([^']*)' and '([^']*)'in the profile")]
        public void WhenINavigateToTheCertificationTabAndEditAndAndInTheProfile(string Certificate, string CertifiedFrom, string year)
        {
            certificationPageObj.EditCertification(driver, Certificate, CertifiedFrom, year);

        }


        [Then(@"The '([^']*)' and '([^']*)' and '([^']*)'should be updated successfully")]
        public void ThenTheAndAndShouldBeUpdatedSuccessfully(string Certificate, string CertifiedFrom, string year)
        {
            try
            {
            test = extentreportobj.CreateTest("Edit Certification", "Testing Edit Certification");
            string certificateName = certificationPageObj.GetEditCertificate(driver);
            string certificateFrom = certificationPageObj.GetEditCertificateFrom(driver);
            string editedyear = certificationPageObj.GetEditYear(driver);

            Assert.That(certificateName==Certificate, "Certificate name added successfully", "Addited certificate do not match with expected certificate");
            Assert.That(certificateFrom==CertifiedFrom, "Certificate from added successfully", "Addited certificate from do not match with expected certificate from");
            Assert.That(editedyear==year, "Completion year added successfully", "Addited Year do not match with expected year");
            ClickScreenshots.TakeScreenshot(driver);
            test.Log(Status.Info, "Certification Edited successfully");
            test.Log(Status.Pass, "Test passed");
            }
            catch (Exception ex)
            {
                ClickScreenshots.TakeScreenshot(driver);
                test.Log(Status.Fail, "Test failed");
                throw;

            }
        }
    


        [When(@"I delete Certification from the profile")]
        public void WhenIDeleteCertificationFromTheProfile()
        {

            certificationPageObj.DeleteCertification();

        }

        [Then(@"The Certification should be deleted from the profile successfully")]
        public void ThenTheCertificationShouldBeDeletedFromTheProfileSuccessfully()
        {
            try
            {
            test = extentreportobj.CreateTest("Delete Certification", "Testing delete Certification");
            certificationPageObj.GetDeletedCertificate(driver);
            ClickScreenshots.TakeScreenshot(driver);
            test.Log(Status.Info, "Certification deleted successfully");
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






    


