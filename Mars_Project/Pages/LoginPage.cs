using OpenQA.Selenium;
using Mars_Project_Advanced_Task.Utilities;
using Competition_Task.Utilities;
using NUnit.Framework;
using Mars_Project.Drivers;
using Mars_Project.Input;

namespace MarsQaProject.Pages
{
    public class LoginPage: CommonDriver
    {
       

        //Finding Elements by Xpath

        private IWebElement signInLink =>driver.FindElement(By.XPath("//A[@class='item'][text()='Sign In']"));
        private IWebElement userName => driver.FindElement(By.XPath("(//INPUT[@type='text'])[2]"));
        private IWebElement password => driver.FindElement(By.XPath("//INPUT[@type='password']"));
        private IWebElement login => driver.FindElement(By.XPath("//BUTTON[@class='fluid ui teal button'][text()='Login']"));


        public void loginSteps(IWebDriver driver)
        {

            try
            {

                //click on Sign In link
                signInLink.Click();

                // Enter valid username
                userName.SendKeys(LoginCredentials.username);

                // Enter valid password
                password.SendKeys(LoginCredentials.password);

                // Click on Login Button
                login.Click();

                //Explicit wait
                Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/div/h3/span", 10);

            }
            catch(Exception ex)
            {
                ClickScreenshots.TakeScreenshot(driver);
                Assert.Fail("Unable to Mars login", ex.Message);

            }

        }
    }
}
