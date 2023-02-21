using Competition_Task.Utilities;
using Mars_Project.Drivers;
using Mars_Project_Advanced_Task.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Reflection.Emit;

namespace MarsQaProject.Pages
{
    public class LanguagePage : CommonDriver
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


        //Finding Elements by Xpath
        private IWebElement language => driver.FindElement(By.XPath("//a[contains(text(),'Languages')]"));
        private IWebElement addNew => driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/thead[1]/tr[1]/th[3]/div[1]"));
        private IWebElement addLanguage => driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/input[1]"));
        private IWebElement clickLanguageLevel => driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[2]/select[1]"));
        private IWebElement chooseLanguageLevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
        private IWebElement clickAddButton => driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[3]/input[1]"));
        private IWebElement getLanguageName => driver.FindElement(By.XPath("//td[contains(text(),'Bengoli')]"));
        private IWebElement getLevelName => driver.FindElement(By.XPath("//td[contains(text(),'Fluent')]"));
        private IWebElement clickDeleticon => driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[1]/tr[1]/td[3]/span[2]/i[1]"));
        private IWebElement clickEditIcon => driver.FindElement(By.XPath("//tbody/tr[1]/td[3]/span[1]/i[1]"));
        private IWebElement clickUpdate => driver.FindElement(By.XPath("//tbody/tr[1]/td[1]/div[1]/span[1]/input[1]"));
        private IWebElement languageTextbox => driver.FindElement(By.XPath("//tbody/tr[1]/td[1]/div[1]/div[1]/input[1]"));
        private IWebElement editLevelDropdown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select"));
        private IWebElement editedlanguageName => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
        private IWebElement editedlanguagelevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[2]"));


        public void Addlanguage(IWebDriver driver, string Language, string level)

        {
            try
            {
                language.Click();
                addNew.Click();
                addLanguage.SendKeys(Language);
                clickLanguageLevel.Click();
                SelectElement LanguageLevel = new SelectElement(chooseLanguageLevel);
                LanguageLevel.SelectByValue(level);
                clickAddButton.Click();
                //Explicit Wait
                Wait.WaitToExist(driver, "XPath", "//td[contains(text(),'Bengoli')]", 10);


            }

            catch (Exception ex)
            {
                ClickScreenshots.TakeScreenshot(driver);
                Assert.Fail("Unable to Add language record", ex.Message);
            }
        }


                public string GetLanguage(IWebDriver driver)
        {

            return getLanguageName.Text;

        }

        public string GetLevel(IWebDriver driver)
        {

            return getLevelName.Text;
        }

        public void Editlanguage(IWebDriver driver, string Language, string Level)
        {
            try
            {
                language.Click();
                clickEditIcon.Click();
                languageTextbox.Click();
                languageTextbox.Clear();
                languageTextbox.SendKeys(Language);
                editLevelDropdown.Click();
                SelectElement selectEditLanguageLevel = new SelectElement(editLevelDropdown);
                selectEditLanguageLevel.SelectByText(Level);
                clickUpdate.Click();
                //Implicit Wait
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                Thread.Sleep(10000);

            }

            catch (Exception ex)
            {
                ClickScreenshots.TakeScreenshot(driver);
                Assert.Fail("Unable to Edit Language record", ex.Message);
            }
        }
                public string GetEditLanguage(IWebDriver driver)
        {
            return editedlanguageName.Text;

        }

        public string GetEditLevel(IWebDriver driver)
        {
           
            return editedlanguagelevel.Text;
        }


        public void Deletelanguage(IWebDriver driver, string Language)
        {
            try
            {

                language.Click();
                clickDeleticon.Click();
                //Implicit Wait
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                Thread.Sleep(10000);

            }

            catch (Exception ex)
            {
                ClickScreenshots.TakeScreenshot(driver);
                Assert.Fail("Unable to delete language record", ex.Message);
            }
        }
        public void GetDeletedLanguage(IWebDriver driver, string Language)
        {

            
            IList<IWebElement> languagesList = driver.FindElements(By.TagName("td"));
            foreach (IWebElement currentLanguage in languagesList)
            {
                string lan = currentLanguage.GetAttribute("innerText").ToString();
                if (lan != Language)
                {
                    Assert.Pass("The langusage is deleted");
                    
                }
                else
                    Assert.Fail("The Language is not Deleted");

            }

        }
    }
}
    
