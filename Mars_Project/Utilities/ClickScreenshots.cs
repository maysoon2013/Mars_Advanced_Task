using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Competition_Task.Utilities
{
    public class ClickScreenshots
    {

        public static void TakeScreenshot(IWebDriver driver)
        {


            Screenshot screenShot = ((ITakesScreenshot)driver).GetScreenshot();
            screenShot.SaveAsFile(@"D:\Project Mars\AdvancedTask1\Mars_Project\Mars_Project\Screenshoots" + DateTime.Now.ToString("dd-MM-yyyy HH mm ss") + ".PNG", ScreenshotImageFormat.Png);
            
    
               
         


        }




    }


}

