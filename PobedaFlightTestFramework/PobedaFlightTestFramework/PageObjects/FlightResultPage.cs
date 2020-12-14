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
        public string CurrencySelected { get; set; }

        IWebDriver driver;
        public FlightResultPage()
        {
            this.driver = Hook.driver;
        }

        IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)Hook.driver;
        IWebElement headerLogo => driver.FindElement(By.ClassName("header_logo"));
        IList<IWebElement> daySelectorList =>
            driver.FindElements(By.XPath("//*[@id=\"dayselectorListOuter\"]/ul/li"));

        public bool BookingCurrencyChangeisPresent()
        {
            if (CurrencySelected != "EUR (€)" && CurrencySelected != null)
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

        public void ValidateTripAvailabilityAndSelectFre()
        {

            for (int i = 1; i <= 15; i++)
            {
                IWebElement flightOption = driver.FindElement(By.XPath($"/html/body/div[1]/main/div/div[2]/div/div/journey-availability-select-container/div[2]/price-journey-select-custom/div[1]/date-navigator-control/div/day-price-control/div/div/div[1]/ul/li[{i}]/div/day-control/button"));
    
                if (driver.PageSource.Contains("journey_price_fare-select_label-text")){
                    
                    IWebElement selectFareLink = driver.FindElement(By.XPath("/html/body/div[1]/main/div/div[2]/div/div/journey-availability-select-container/div[2]/price-journey-select-custom/div[2]/div/div/journey-control-custom/div/div/div[1]/div[2]/button/div[2]/div"));
                    selectFareLink.Click();


                    IWebElement selectFareButton = driver.FindElement(By.XPath("/html/body/div[1]/main/div/div[2]/div/div/journey-availability-select-container/div[2]/price-journey-select-custom/div[2]/div/div/journey-control-custom/div/div/div[2]/div[1]/div/div[1]/fare-control/div/div[3]/button/div[2]"));
                    
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                    wait.Until(ExpectedConditions.ElementToBeClickable(selectFareButton));

                    selectFareButton.Click();

                    i = 16;
                }
                else
                {
                    flightOption.Click();
                    if (driver.PageSource.Contains("journey_price_fare-select_label-text"))
                    {
                        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                        IWebElement selectFareLink = driver.FindElement(By.XPath("/html/body/div[1]/main/div/div[2]/div/div/journey-availability-select-container/div[2]/price-journey-select-custom/div[2]/div/div/journey-control-custom/div/div/div[1]/div[2]/button/div[2]/div"));
                        wait.Until(ExpectedConditions.ElementToBeClickable(selectFareLink));
                        selectFareLink.Click();

                        IWebElement selectFareButton = driver.FindElement(By.XPath("/html/body/div[1]/main/div/div[2]/div/div/journey-availability-select-container/div[2]/price-journey-select-custom/div[2]/div/div/journey-control-custom/div/div/div[2]/div[1]/div/div[1]/fare-control/div/div[3]/button/div[2]"));
                        wait.Until(ExpectedConditions.ElementToBeClickable(selectFareButton));
                        selectFareButton.Click();

                        i = 16;
                    }
                    
                }
                
            }
            
        }


    }
}
