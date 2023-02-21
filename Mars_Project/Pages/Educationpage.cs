using Competition_Task.Utilities;
using Mars_Project.Drivers;
using Mars_Project_Advanced_Task.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MarsQaProject.Pages
{
    public class Educationpage: CommonDriver
    {
        //Finding Elements By Xpath
        public IWebElement educationLink => driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[1]/a[3]"));
        public IWebElement addNew => driver.FindElement(By.XPath("//thead/tr[1]/th[6]/div[1]"));
        public IWebElement universityName => driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[4]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/input[1]"));
        public IWebElement countryOfUni => driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[4]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/select[1]"));
        public IWebElement selectCountryOfUni => driver.FindElement(By.XPath("//option[contains(text(),'Bangladesh')]"));
        public IWebElement title => driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[4]/div[1]/div[2]/div[1]/div[1]/div[2]/div[1]/select[1]"));
        public IWebElement selectTitle => driver.FindElement(By.XPath("//option[contains(text(),'B.Sc')]"));
        public IWebElement degree => driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[4]/div[1]/div[2]/div[1]/div[1]/div[2]/div[2]/input[1]"));
        public IWebElement yearOfGraduation => driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[4]/div[1]/div[2]/div[1]/div[1]/div[2]/div[3]/select[1]"));
        public IWebElement selectYear => driver.FindElement(By.XPath("//option[contains(text(),'2007')]"));
        public IWebElement clickadd => driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[4]/div[1]/div[2]/div[1]/div[1]/div[3]/div[1]/input[1]"));
        public IWebElement getCountryName => driver.FindElement(By.XPath("//tbody/tr/td[1]"));
        public IWebElement getUniversityName => driver.FindElement(By.XPath("//tbody/tr/td[2]"));
        public IWebElement gettiTleName => driver.FindElement(By.XPath("//tbody/tr/td[3]"));
        public IWebElement getDegreeName => driver.FindElement(By.XPath("//tbody/tr/td[4]"));
        public IWebElement getGrdYear => driver.FindElement(By.XPath("//tbody/tr/td[5]"));
        public IWebElement eidtbtn => driver.FindElement(By.XPath("//tbody/tr[1]/td[6]/span[1]/i[1]"));
        public IWebElement editUni => driver.FindElement(By.XPath("//*[@name='instituteName']"));
        public IWebElement editDegree => driver.FindElement(By.XPath("//*[@name='degree']"));
        public IWebElement updatebtn => driver.FindElement(By.XPath("//tbody/tr[1]/td[1]/div[3]/input[1]"));
        public IWebElement getupdateuni => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[2]"));
        public IWebElement getUpdateDegree => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[4]"));
        public IWebElement deleteIcon => driver.FindElement(By.XPath("//tbody/tr[1]/td[6]/span[2]/i[1]"));
        public IWebElement deleteEducationRecord => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[1]"));


        public void AddEducationSteps(IWebDriver driver, string University, string Country, string Title, string Degree, string GraduationYear)
        {
            try
            {
                educationLink.Click();
                addNew.Click();
                universityName.SendKeys(University);
                countryOfUni.Click();
                selectCountryOfUni.Click();
                title.Click();
                selectTitle.Click();
                degree.SendKeys(Degree);
                yearOfGraduation.Click();
                selectYear.Click();
                clickadd.Click();
                //Explicit Wait
                Wait.WaitToExist(driver, "XPath", "//td[contains(text(),'Bangladesh')]", 20);
            }
            catch (Exception ex)
            {
                ClickScreenshots.TakeScreenshot(driver);
                Assert.Fail("Unable to Add Education", ex.Message);

            }
        }

          public string GetCountry(IWebDriver driver)
            {
        
           return getCountryName.Text;
            }

           public string GetUniversity(IWebDriver driver)
            {   
            return getUniversityName.Text;
            }

        public string GetTitle(IWebDriver driver) 
        {
           
            return gettiTleName.Text;
        }

        public string GetDegree(IWebDriver driver)
        {
          
            return getDegreeName.Text;
        }

        public string GetYear(IWebDriver driver)
        {
            
            return getGrdYear.Text;
        }

        public void EditEducationSteps(IWebDriver driver, string University, string Degree)
        {
            try
            {
                educationLink.Click();
                eidtbtn.Click();
                editUni.Clear();
                editUni.SendKeys(University);
                editDegree.Clear();
                editDegree.SendKeys(Degree);
                updatebtn.Click();
                

            }
            catch (Exception ex)
            {
                ClickScreenshots.TakeScreenshot(driver);
                Assert.Fail("Unable to Edit education", ex.Message);

            }
        }

            public string GetUpdateUniname(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return getupdateuni.Text;
        }

        public string GetUpdateDegreeName(IWebDriver driver)
        {

            return getUpdateDegree.Text;
        }

        public void DeleteEducationStep()
        {
            try
            {
                educationLink.Click();
                deleteIcon.Click();
                Thread.Sleep(10000);
            }
            catch (Exception ex)
            {
                ClickScreenshots.TakeScreenshot(driver);
                Assert.Fail("Unable to delete education", ex.Message);

            }
        }

            public void GetDeletedEducation(IWebDriver driver)
        {


            IList<IWebElement> EducationList = driver.FindElements(By.TagName("td"));
            foreach (IWebElement currentEducation in EducationList)
            {
                string edu = currentEducation.GetAttribute("innerText").ToString();
                if (edu != "MIT")
                {
                    Assert.Pass("The langusage is deleted");

                }
                else
                    Assert.Fail("The Language is not Deleted");

            }

        }

    }
    }


