using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using MarsQaProject.Pages;
using Mars_Project_Advanced_Task.Pages;
using Mars_Project.Input;
using Competition_Task.Utilities;

namespace Mars_Project.Drivers
{
    public class CommonDriver
    {
        public static IWebDriver driver;
        //public static FileStream stream;
        public static ExtentReports extentreportobj;
        public static ExtentHtmlReporter htmlReporter;
        public static ExtentTest test;


        [OneTimeSetUp]
        public void LoginAction()
        {
            /*
            string fileName = @"C:\Users\mamun\Desktop\SkillParticulars.xlsx";
            //open file and returns as stream
            stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            ExcelReader.ReadDataTable(stream, "SkillsProfile");

           */


            var htmlreporter = new ExtentHtmlReporter(@"D:\Project Mars\AdvancedTask1\Mars_Project\Mars_Project\ExtentReport");
            extentreportobj = new ExtentReports();
            extentreportobj.AttachReporter(htmlreporter);


            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(LoginCredentials.url);

            driver.Manage().Window.Maximize();

            if (LoginCredentials.username == LoginCredentials.username)
            {
                LoginPage loginPageObj = new LoginPage();
                loginPageObj.loginSteps(driver);
            }
            else
            {
                Registration signupPageObj = new Registration();
                signupPageObj.SignUpSteps(driver);
            }



        }

        [OneTimeTearDown]


        public void CloseBrowser()
        {
            //ClickScreenshots.TakeScreenshot(driver);
            //extentreportobj.Flush();

            //driver.Quit();
        }


    }
}


    

