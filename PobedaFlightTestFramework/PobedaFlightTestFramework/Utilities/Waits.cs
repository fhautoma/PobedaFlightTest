using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace PobedaFlightTestFramework.Utilities
{
    class Waits
    {
        public IWebElement WaitForElement(IWebDriver driver, IWebElement element)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);

            fluentWait.Timeout = TimeSpan.FromSeconds(60);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(2000);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            //fluentWait.Until(x => element.Displayed) &&
            if (fluentWait.Until(x => element.Displayed)) 
            {
                return element;
            } else
            {
                return null;
            }

        }


    }
}
