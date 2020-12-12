using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace PobedaFlightTestFramework.Hooks
{
    [Binding]
    public class Hook
    {
        public static IWebDriver driver;
 
        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = new ChromeDriver(".");
            driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
           driver.Quit();
        }
    }
}
