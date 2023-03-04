using Mars_Project.Drivers;
using Mars_Project_Advanced_Task.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Mars_Project_Advanced_Task.Hook
{
    [Binding]
    public class Start : CommonDriver
    {
        [BeforeScenario]
        public void Setup()
        {
            LoginAction();

        }
        [AfterScenario]
        public void TearDown()
        {
            CloseBrowser(); 


        }

    }
}

