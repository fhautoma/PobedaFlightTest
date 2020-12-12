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
    class FlightSearchPage: Hook
    {
        IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
        //IWebDriver driver = Hook.driver;
        IWebElement mainBannerClass => driver.FindElement(By.ClassName("main-banner_item align-left ng-star-inserted"));
        IWebElement searchButton => driver.FindElement(By.Id("searchButton"));
        IWebElement languageSelector => driver.FindElement(By.Id("idLanguageSelector"));
        IWebElement languageDropDownItemOptionOne =>
            driver.FindElement(By.Id("idLanguageSelector-0"));
        IWebElement languageDropDownItemOptionTwo =>
            driver.FindElement(By.Id("idLanguageSelector-1"));
        IWebElement languageDropDownItemOptionThree =>
            driver.FindElement(By.Id("idLanguageSelector-2"));
        IWebElement currencySelector => driver.FindElement(By.Id("idCurrencySelector"));
        IWebElement currencyDropDownItemOptionOne =>
            driver.FindElement(By.Id("idCurrencySelector-0"));
        IWebElement currencyDropDownItemOptionTwo =>
            driver.FindElement(By.Id("idCurrencySelector-1"));
        IWebElement currencyDropDownItemOptionThree =>
            driver.FindElement(By.Id("idCurrencySelector-2"));


        //ESTO DEBE IR EN LA PAGE DE RESULTADOS
        IWebElement contentWrap => driver.FindElement(By.ClassName("content-wrap"));

        //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

        public void NavigateToWebSite()
        {
            driver.Navigate().GoToUrl("https://www.pobeda.aero/en");
        }

        public void ClickSearchButton()
        {
        
            searchButton.Click();
        }

        public void WaitUntilSearchPageLoad()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementToBeClickable(searchButton));
            //Thread.Sleep(60000000);
        }

        //ESTO DEBE IR EN LA PAGE DE RESULTADOS
        public void WaitUntilPageResultLoad()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.ClassName("content-wrap")));
            //Thread.Sleep(60000000);
        }

        
        public void SearchPageLoadValidation()
        {
            Assert.IsTrue(javaScriptExecutor.ExecuteScript("return document.readyState").ToString() == "complete");
        }

    }
}
