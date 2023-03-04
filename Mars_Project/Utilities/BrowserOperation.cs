using Mars_Project.Drivers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Mars_Project.Input;

namespace Mars_Project_Advanced_Task.Utilities
{
    public class BrowserOperation : CommonDriver
    {
        public static void SelectingBrowser()
        {
            if (Browserinput.browser == "chrome")
            {
                driver = new ChromeDriver();
            }
            else
            {
                driver = new FirefoxDriver();
            }

        }
    }
}
