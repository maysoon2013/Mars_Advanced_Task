using Competition_Task.Utilities;
using Mars_Project.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MarsQaProject.Pages
{
    public class CertificationPage : CommonDriver

    {
        //Finding Element By XPath
        private IWebElement clickcertification => driver.FindElement(By.XPath("//a[contains(text(),'Certifications')]"));
        private IWebElement clickAddNew => driver.FindElement(By.XPath("//thead/tr[1]/th[4]/div[1]"));
        private IWebElement certificateName => driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[5]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/input[1]"));
        private IWebElement instituteName => driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[5]/div[1]/div[2]/div[1]/div[1]/div[2]/div[1]/input[1]"));
        private IWebElement completionYear => driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[5]/div[1]/div[2]/div[1]/div[1]/div[2]/div[2]/select[1]"));
        private IWebElement selectComYear => driver.FindElement(By.XPath("//option[contains(text(),'2022')]"));
        private IWebElement clickOnAddBtn => driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[5]/div[1]/div[2]/div[1]/div[1]/div[3]/input[1]"));
        private IWebElement getCertificateName => driver.FindElement(By.XPath("//tbody/tr/td[1]"));
        private IWebElement getInstituteName => driver.FindElement(By.XPath("//tbody/tr/td[2]"));
        private IWebElement getComYear => driver.FindElement(By.XPath("//tbody/tr/td[3]"));
        private IWebElement editIcon => driver.FindElement(By.XPath("//tbody/tr[1]/td[4]/span[1]/i[1]"));
        private IWebElement certificateTextfield => driver.FindElement(By.XPath("//tbody/tr[1]/td[1]/div[1]/div[1]/div[1]/input[1]"));
        private IWebElement fromTextfield => driver.FindElement(By.XPath("//tbody/tr[1]/td[1]/div[1]/div[1]/div[2]/input[1]"));
        private IWebElement updateYear => driver.FindElement(By.XPath("//td[contains(text(),'2020')]"));
        public IWebElement updateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        private IWebElement updatecertificate => driver.FindElement(By.XPath("//td[contains(text(),'selenium')]"));
        private IWebElement updatefrom => driver.FindElement(By.XPath("//td[contains(text(),'Udemy')]"));
        public IWebElement deleteButton => driver.FindElement(By.XPath("//tbody/tr[1]/td[4]/span[2]/i[1]"));
        public IWebElement deletedTitle => driver.FindElement(By.XPath("//td[contains(text(),'selenium')]"));




        public void AddCertificateSteps(IWebDriver driver, string Certificate, string CertifiedFrom)
        {
            try
            {
                clickcertification.Click();
                clickAddNew.Click();
                certificateName.SendKeys(Certificate);
                instituteName.SendKeys(CertifiedFrom);
                completionYear.Click();
                selectComYear.Click();
                clickOnAddBtn.Click();
            }
            catch (Exception ex)
            {
                ClickScreenshots.TakeScreenshot(driver);
                Assert.Fail("Unabl to add Certificate", ex.Message);
            }
        }

                public string GetCertificate(IWebDriver driver)
        {
            //Implicit Wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return getCertificateName.Text;
        }

        public string GetCertificateFrom(IWebDriver driver)
        {

            return getInstituteName.Text;
        }

        public string GetCompletionYear(IWebDriver driver)
        {

            return getComYear.Text;
        }

        public void EditCertification(IWebDriver driver, string Certificate, string CertifiedFrom, string year)

        {
            try
            {
                clickcertification.Click();
                editIcon.Click();
                certificateTextfield.Click();
                certificateTextfield.Clear();
                certificateTextfield.SendKeys(Certificate);
                fromTextfield.Click();
                fromTextfield.Clear();
                fromTextfield.SendKeys(CertifiedFrom);
                SelectElement yearDropdown = new SelectElement(driver.FindElement(By.XPath("//tbody/tr[1]/td[1]/div[1]/div[1]/div[3]/select[1]")));
                yearDropdown.SelectByValue(year);
                updateButton.Click();
            }
            catch (Exception ex)
            {
                ClickScreenshots.TakeScreenshot(driver);
                Assert.Fail("Unable to edit certification", ex.Message);
            }
        }

            public string GetEditCertificate(IWebDriver driver)
        {
            //Implicit Wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return updatecertificate.Text;
        }

        public string GetEditCertificateFrom(IWebDriver driver)
        {

            return updatefrom.Text;
        }

        public string GetEditYear(IWebDriver driver)
        {

            return updateYear.Text;
        }

        public void DeleteCertification()
        {
            try
            {

                clickcertification.Click();
                deleteButton.Click();
                Thread.Sleep(10000);
               
            }
            catch (Exception ex)
            {
                ClickScreenshots.TakeScreenshot(driver);
                Assert.Fail("Unable to delete certification", ex.Message);
            }
        }

          public void GetDeletedCertificate(IWebDriver driver)
            {

            IList<IWebElement> certificateList = driver.FindElements(By.TagName("td"));
            foreach (IWebElement currentCertificate in certificateList)
            {
                string cert = currentCertificate.GetAttribute("innerText").ToString();
                if (cert !="selenium")
                {
                    Assert.Pass("The langusage is deleted");

                }
                else
                    Assert.Fail("The Language is not Deleted");
            }


        }
    }
}
