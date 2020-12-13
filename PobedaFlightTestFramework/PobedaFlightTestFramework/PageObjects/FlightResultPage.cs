using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PobedaFlightTestFramework.Hooks;

namespace PobedaFlightTestFramework.PageObjects
{
    class FlightResultPage
    {
        IWebDriver driver;
        public FlightResultPage()
        {
            this.driver = Hook.driver;
        }

        IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)Hook.driver;

        IWebElement modalContentClass => driver.FindElement(By.ClassName("modal-content"));

        IWebElement bookingCurrencyChangeAgreeButton
            => driver.FindElement(By.XPath("/html/body/ngb-modal-window/div/div/ng-component/div/div[3]/button"));

        public bool BookingCurrencyChangeisPresent()
        {
            try
            {
                bool isElementDisplayed = modalContentClass.Displayed;
                if (isElementDisplayed)
                {
                    bookingCurrencyChangeAgreeButton.Click();
                }
                else
                {
                    isElementDisplayed = false;
                }

                return isElementDisplayed;

            } catch (NoSuchElementException e)

            {
                throw new NoSuchElementException($"elemento no existe: {e}");
            }
           

        }   

        public void WaitUntilResulPagetLoad()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.ClassName("content-wrap")));
            
        }


    }
}
