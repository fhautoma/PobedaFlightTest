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
    class FlightSearchPage
    {
        IWebDriver driver;

        public FlightSearchPage()
        {
            this.driver = Hook.driver;
        }

        IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)Hook.driver;
        IWebElement searchButton => driver.FindElement(By.Id("searchButton"));
        //IWebElement languageSelector => driver.FindElement(By.Id("idLanguageSelector"));
        IWebElement languageSelector => driver.FindElement(By.XPath("//*[@id=\"idLanguageSelector\"]/div/span"));
        IList<IWebElement> languageDropDownItemOptionsCount =>
            driver.FindElements(By.XPath("/html/body/div[1]/div[1]/ibe-main-menu/header/div/div[2]/div[2]/header-secondary-nav-custom/nav/ul/li[3]/ibe-language-selector/div/ibe-select/div/div[2]/ul/li"));
        IList<IWebElement> currencyDropDownItemOptionsCount =>
          driver.FindElements(By.XPath("/html/body/div[1]/div[1]/ibe-main-menu/header/div/div[2]/div[2]/header-secondary-nav-custom/nav/ul/li[4]/div/ibe-currency-selector/div/ibe-select/div/div[2]/ul/li"));
        IWebElement languageDropDownItemOptionOne =>
            driver.FindElement(By.Id("idLanguageSelector-0"));
        IWebElement currencySelector => driver.FindElement(By.Id("idCurrencySelector"));
        IWebElement currencyDropDownItemOptionOne =>
            driver.FindElement(By.Id("idCurrencySelector-0"));
        IWebElement oneWayCheckBox => driver.FindElement(By.Id("journeytypeId_0"));
        IList<IWebElement> stationControlListOrigin => driver.FindElements(By.XPath("//*[@id=\"originStationsListId\"]/div/ul/li"));
        IList<IWebElement> stationControlListDestination => driver.FindElements(By.XPath("//*[@id=\"destinationStationsListId\"]/div/ul/li"));
        IWebElement originStationInputLabel => driver.FindElement(By.Id("originStationSelected"));
        IWebElement originOptionOne => driver.FindElement(By.XPath("//*[@id=\"originStationsListId\"]/div/ul/li[1]"));
        IWebElement tripDate => driver.FindElement(By.XPath("//*[@id=\"searchComponentDiv\"]/div[2]/div[2]/div[2]/date-control-custom/div/div[2]/div/div[2]/date-picker/ngb-datepicker/div[2]/div/ngb-datepicker-month-view/div[6]/div[5]/span"));
        IWebElement addAdultsButton => 
            driver.FindElement(By.XPath("/html/body/div[1]/main/div/div[1]/div/div/ibe-multiple-panel/div/div/div[2]/div[1]/div/div/ibe-multiple-options/div/div/div/ibe-render-component/div/ng-template/search-container/ibe-search-custom/div/div[2]/div[2]/div[3]/pax-control-custom/div/div[2]/div/div[2]/div/ul/li[1]/div[2]/ibe-minus-plus/div/button[2]"));
        IWebElement addTeensButton =>
            driver.FindElement(By.XPath("html/body/div[1]/main/div/div[1]/div/div/ibe-multiple-panel/div/div/div[2]/div[1]/div/div/ibe-multiple-options/div/div/div/ibe-render-component/div/ng-template/search-container/ibe-search-custom/div/div[2]/div[2]/div[3]/pax-control-custom/div/div[2]/div/div[2]/div/ul/li[2]/div[2]/ibe-minus-plus/div/button[2]"));
        IWebElement addChildsButton =>
            driver.FindElement(By.XPath("/html/body/div[1]/main/div/div[1]/div/div/ibe-multiple-panel/div/div/div[2]/div[1]/div/div/ibe-multiple-options/div/div/div/ibe-render-component/div/ng-template/search-container/ibe-search-custom/div/div[2]/div[2]/div[3]/pax-control-custom/div/div[2]/div/div[2]/div/ul/li[3]/div[2]/ibe-minus-plus/div/button[2]"));
        IWebElement addBabysButton =>
            driver.FindElement(By.XPath("/html/body/div[1]/main/div/div[1]/div/div/ibe-multiple-panel/div/div/div[2]/div[1]/div/div/ibe-multiple-options/div/div/div/ibe-render-component/div/ng-template/search-container/ibe-search-custom/div/div[2]/div[2]/div[3]/pax-control-custom/div/div[2]/div/div[2]/div/ul/li[4]/div[2]/ibe-minus-plus/div/button[2]"));
        IWebElement donePassengersButton => driver.FindElement(By.XPath("//*[@id=\"paxControlSearchId\"]/div/div[2]/div/div/button"));

        public void NavigateToWebSite(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void ClickSearchButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchButton));

            
            searchButton.Click();
            Thread.Sleep(2000);
        }

        public void WaitUntilSearchPageLoad()
        {
            Thread.Sleep(3000);

        }
        
        public void SearchPageLoadValidation()
        {
            Assert.IsTrue(javaScriptExecutor.ExecuteScript("return document.readyState").ToString() == "complete");
        }

        public void ChangeLanguageOption(string language)
        {
            
            string _language = TranslateLanguage(language);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(languageSelector));
            languageSelector.Click();
            
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(languageDropDownItemOptionOne));

            foreach (IWebElement languageDropDownItemOption in languageDropDownItemOptionsCount)
            {
                if (languageDropDownItemOption.Text == _language)
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(languageDropDownItemOption));
                    languageDropDownItemOption.Click();
                    break;
                }
            }

        }

        public void ChangeCurrencyOption(FlightResultPage flightResultP, string currency)
        {
            string _currency = TranslateCurrency(currency);
            currencySelector.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(currencyDropDownItemOptionOne));

            foreach (IWebElement currencyDropDownItemOption in currencyDropDownItemOptionsCount)
            {
                if (currencyDropDownItemOption.Text == _currency)
                {
                    currencyDropDownItemOption.Click();
                    flightResultP.CurrencySelected = _currency;
                   
                    break;
                }
            }
            
        }

        public string TranslateLanguage(string language)
        {
            string _language;

            switch (language)
            {
                case "Aleman":
                    _language = "Deutsch";
                    break;

                case "Ingles":
                    _language = "English";
                    break;

                case "Ruso":
                    _language = "Русский";
                    break;

                default:
                    _language = null;
                    break;
            }

            return _language;
        }

        public string TranslateCurrency(string currency)
        {
            string _currency;

            switch (currency)
            {
                case "Dolares":
                    _currency = "USD ($)";
                    break;

                case "Euros":
                    _currency = "EUR (€)";
                    break;

                case "Rublos":
                    _currency = "RUB (₽)";
                    break;

                default:
                    _currency = null;
                    break;
            }

            return _currency;

        }

        public void SelectOneWayTripOption()
        {
            oneWayCheckBox.Click();
        }

        public void FillDepartingCity(string iataCode)
        {

            originStationInputLabel.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(originOptionOne));

            foreach (IWebElement originListOption in stationControlListOrigin)
            {
                
                string _iataCode = originListOption.Text.Substring(originListOption.Text.Length - 3);
                if (_iataCode == iataCode)
                {
                    originListOption.Click();

                    break;
                }
            }
        }

        public void FillArrivalCity(string iataCode)
        {
            
            foreach (IWebElement destinationListOption in stationControlListDestination)
            {

                string _iataCode = destinationListOption.Text.Substring(destinationListOption.Text.Length - 3);
                if (_iataCode == iataCode)
                {
                    destinationListOption.Click();

                    break;
                }
            }
        }

        public void ChangeTripDate()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(tripDate));
            tripDate.Click();
        }

        public void AddPassengers(int adults, int teens, int childs, int babys)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(addAdultsButton));

            for (int i = 1; i< adults; i++)
            {
                addAdultsButton.Click();
            }
            for (int i = 0; i < teens; i++)
            {
                addTeensButton.Click();
            }
            for (int i = 0; i < childs; i++)
            {
                 addChildsButton.Click();
            }
            for (int i = 0; i < babys; i++)
            {
                addBabysButton.Click();
            }

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(donePassengersButton));
            donePassengersButton.Click();
        }

    }
}
