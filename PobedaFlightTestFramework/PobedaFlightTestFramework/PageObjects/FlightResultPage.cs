﻿using System;
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
        public string CurrencySelected { get; set; }

        IWebDriver driver;
        public FlightResultPage()
        {
            this.driver = Hook.driver;
        }

        IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)Hook.driver;
        IWebElement headerLogo => driver.FindElement(By.ClassName("header_logo"));

        
        public bool BookingCurrencyChangeisPresent()
        {
            if (CurrencySelected != "EUR (€)")
            {

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                IWebElement modalContentClass = driver.FindElement(By.ClassName("modal-content"));
                
                wait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(By.XPath("/html/body/ngb-modal-window/div/div/ng-component/div/div[3]/button"))));
                IWebElement bookingCurrencyChangeAgreeButton
                    = driver.FindElement(By.XPath("/html/body/ngb-modal-window/div/div/ng-component/div/div[3]/button"));

                bool isElementDisplayed = modalContentClass.Displayed;

                if (isElementDisplayed)
                {
                    bookingCurrencyChangeAgreeButton.Click();
                }

                CurrencySelected = "EUR (€)";
            }
            return true;

        }

        public void WaitUntilResulPagetLoad()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.ClassName("content-wrap")));
            
        }

        public void ReturnToSearchPage()
        {
            headerLogo.Click();
        }


    }
}
