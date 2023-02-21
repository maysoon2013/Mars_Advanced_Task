using Competition_Task.Utilities;
using Mars_Project.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Project_Advanced_Task.Pages
{
    public class Profile_Availability : CommonDriver
    {
        private IWebElement availabilityIcon => driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[2]/div[1]/span[1]/i[1]"));
        private IWebElement availabilityDropdown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select"));
        private IWebElement addedavailavility => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select/option[3]"));
  


        public void addAvailability(IWebDriver driver)
        {
            try
            {
                availabilityIcon.Click();
                availabilityDropdown.Click();
                SelectElement selectavailability = new SelectElement(availabilityDropdown);
                selectavailability.SelectByText("Full Time");
                Thread.Sleep(5000);
           


            }
            catch (Exception ex)
            {
               
                Assert.Fail("Unable to add abailability", ex.Message);
                ClickScreenshots.TakeScreenshot(driver);

            }
        }


        public string GetAvailavility(IWebDriver driver)

        {
          
            return addedavailavility.Text;

        }
 
    }
}
