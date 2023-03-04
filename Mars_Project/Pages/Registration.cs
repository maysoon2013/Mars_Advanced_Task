using Mars_Project.Drivers;
using Mars_Project.Input;
using OpenQA.Selenium;

namespace Mars_Project_Advanced_Task.Pages
{
    public class Registration: CommonDriver
    {
        private IWebElement clickJoinButton => driver.FindElement(By.XPath("//button[contains(text(),'Join')]"));
        private IWebElement firstNamebox => driver.FindElement(By.XPath("//body/div[2]/div[1]/div[1]/form[1]/div[1]/input[1]"));
        private IWebElement lastNamebox => driver.FindElement(By.XPath("input[placeholder='Last name']"));
        private IWebElement emailId => driver.FindElement(By.XPath("//input[@placeholder='Email address']"));
        private IWebElement passwordButton => driver.FindElement(By.XPath("//body/div[2]/div[1]/div[1]/form[1]/div[4]/input[1]"));
        private IWebElement passwordConfirm => driver.FindElement(By.XPath("//body/div[2]/div[1]/div[1]/form[1]/div[5]/input[1]"));
        private IWebElement agreeTerms => driver.FindElement(By.XPath("//body/div[2]/div[1]/div[1]/form[1]/div[6]/div[1]/div[1]/input[1]"));
        private IWebElement submitButton => driver.FindElement(By.XPath("//div[@id='submit-btn']"));

        public void SignUpSteps(IWebDriver driver)
        {
           clickJoinButton.Click();
           firstNamebox.SendKeys(SignupCredential.firstName);
           lastNamebox.SendKeys(SignupCredential.lastName);
           emailId.SendKeys(SignupCredential.email);
           passwordButton.SendKeys(SignupCredential.password);
           passwordConfirm.SendKeys(SignupCredential.confirmPassword);
           agreeTerms.Click();
           submitButton.Click();

        }

    }
}
