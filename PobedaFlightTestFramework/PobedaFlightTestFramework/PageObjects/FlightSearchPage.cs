using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using PobedaFlightTestFramework.Hooks;

namespace PobedaFlightTestFramework.PageObjects
{
    class FlightSearchPage: Hook
    {

        IWebElement searchButton => driver.FindElement(By.Id("searchButton"));

        public void NavigateToWebSite()
        {
            driver.Navigate().GoToUrl("https://www.pobeda.aero");
        }

        public void ClickSearchButton()
        {
            searchButton.Click();
        }

    }
}
