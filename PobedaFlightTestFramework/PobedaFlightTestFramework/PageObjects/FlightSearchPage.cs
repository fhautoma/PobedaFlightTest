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
       //panelItemContentClas = By.ClassName("multiple-panel_item_content ng-tns-c1-1 ng-trigger ng-trigger-collapse active ng-star-inserted");
        IWebElement panelItemContentClass => 
            driver.FindElement(By.ClassName("multiple-panel_item_content ng-tns-c1-1 ng-trigger ng-trigger-collapse active ng-star-inserted"));
        IWebElement searchButton => driver.FindElement(By.Id("searchButton"));
        IWebElement languageSelector => driver.FindElement(By.Id("idLanguageSelector"));
        IList<IWebElement> languageDropDownItemOptionsCount =>
            driver.FindElements(By.XPath("/html/body/div[1]/div[1]/ibe-main-menu/header/div/div[2]/div[2]/header-secondary-nav-custom/nav/ul/li[3]/ibe-language-selector/div/ibe-select/div/div[2]/ul/li"));
        IList<IWebElement> currencyDropDownItemOptionsCount =>
          driver.FindElements(By.XPath("/html/body/div[1]/div[1]/ibe-main-menu/header/div/div[2]/div[2]/header-secondary-nav-custom/nav/ul/li[4]/div/ibe-currency-selector/div/ibe-select/div/div[2]/ul/li"));
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


        //List<IWebElement> a = driver.FindElements(By.CssSelector("/html/body/div[1]/div[1]/ibe-main-menu/header/div/div[2]/div[2]/header-secondary-nav-custom/nav/ul/li[3]/ibe-language-selector/div/ibe-select/div/div[2]/ul"));
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
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            //wait.Until(ExpectedConditions.ElementToBeClickable(searchButton));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.ClassName("multiple-panel_item_content_inner")));
            //Thread.Sleep(60000000);
        }
        
        public void SearchPageLoadValidation()
        {
            Assert.IsTrue(javaScriptExecutor.ExecuteScript("return document.readyState").ToString() == "complete");
        }

        public void ChangeLanguageOption(string language)
        {
            string _language = TranslateLanguage(language);
            languageSelector.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementToBeClickable(languageDropDownItemOptionOne));

            foreach (IWebElement languageDropDownItemOption in languageDropDownItemOptionsCount)
            {
                if (languageDropDownItemOption.Text == _language)
                {
                    languageDropDownItemOption.Click();
                    break;
                }
            }
            //IList<IWebElement> el_count = driver.FindElements(By.XPath("/html/body/div[1]/div[1]/ibe-main-menu/header/div/div[2]/div[2]/header-secondary-nav-custom/nav/ul/li[3]/ibe-language-selector/div/ibe-select/div/div[2]/ul/li"));
            //var  = driver.FindElements(By.CssSelector("#idLanguageSelector > div > span"));

            //List<IWebElement> listOfElements = driver.FindElements(By.XPath("//div"));
            //listOfElements.Click();
            //SelectElement selectElement = new SelectElement(a);
            
            //selectElement.SelectByText($"{_language}");
            //new SelectElement(a).SelectByText($"{_language}");

        }

        public void ChangeCurrencyOption(string currency)
        {
            string _currency = TranslateCurrency(currency);
            currencySelector.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementToBeClickable(currencyDropDownItemOptionOne));

            foreach (IWebElement currencyDropDownItemOption in currencyDropDownItemOptionsCount)
            {
                if (currencyDropDownItemOption.Text == _currency)
                {
                    currencyDropDownItemOption.Click();
                    break;
                }
            }
            //IList<IWebElement> el_count = driver.FindElements(By.XPath("/html/body/div[1]/div[1]/ibe-main-menu/header/div/div[2]/div[2]/header-secondary-nav-custom/nav/ul/li[3]/ibe-language-selector/div/ibe-select/div/div[2]/ul/li"));
            //var  = driver.FindElements(By.CssSelector("#idLanguageSelector > div > span"));

            //List<IWebElement> listOfElements = driver.FindElements(By.XPath("//div"));
            //listOfElements.Click();
            //SelectElement selectElement = new SelectElement(a);

            //selectElement.SelectByText($"{_language}");
            //new SelectElement(a).SelectByText($"{_language}");

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

    }
}
