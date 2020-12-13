using System;
using TechTalk.SpecFlow;
using PobedaFlightTestFramework.PageObjects;

namespace PobedaFlightTestFramework.StepDefinitions
{
    [Binding]
    public class PobedaFlightFlowSteps
    {

        FlightSearchPage flightSearchPage = new FlightSearchPage();
        FlightResultPage flightResultPage = new FlightResultPage();

        [Given(@"Navegar al sitio web de la aerolínea Pobeda")]
        public void GivenNavegarAlSitioWebDeLaAerolineaPobeda()
        {
            flightSearchPage.NavigateToWebSite();
        }
        
        [Given(@"Esperar que cargue la pagina de busqueda")]
        public void GivenEsperarQueCargueElSitioWeb()
        {
            flightSearchPage.WaitUntilSearchPageLoad();
        }
        
        [Then(@"La pagina de busqueda carga correctamente")]
        public void ThenLaPaginaCargaCorrectamente()
        {
            flightSearchPage.SearchPageLoadValidation();
        }

        [Then(@"Cambiar el lenguaje del sitio Web a ""(.*)""")]
        public void ThenCambiarElLenguajeDelSitioWebA(string language)
        {
            flightSearchPage.ChangeLanguageOption(language);
        }

        [Then(@"Cambiar el tipo de moneda del sitio Web a ""(.*)""")]
        public void ThenCambiarElTipoDeMonedaDelSitioWebA(string currency)
        {
            flightSearchPage.ChangeCurrencyOption(currency);
        }

        [Then(@"Hacer click en el boton de busqueda")]
        public void ThenHacerClickEnElBotonDeBusqueda()
        {
            flightSearchPage.ClickSearchButton();
        }

        [Then(@"Esperar que se muestre la pagina de seleccion de vuelos")]
        public void ThenEsperarQueSeMuestreLaPaginaDeSeleccionDeVuelos()
        {
            flightResultPage.BookingCurrencyChangeisPresent();
            flightResultPage.WaitUntilResulPagetLoad();
        }

        [Then(@"Regresar a la pagina de busqueda")]
        public void ThenRegresarALaPaginaDeBusqueda()
        {
            
        }

        [Then(@"Esperar que cargue la pagina de busqueda")]
        public void ThenEsperarQueCargueLaPaginaDeBusqueda()
        {
            
        }

        [Then(@"Cambiar el tipo de vuelo a Solo Ida")]
        public void ThenCambiarElTipoDeVueloASoloIda()
        {
            
        }

        [Then(@"Cambiar el lugar origen")]
        public void ThenCambiarElLugarOrigen()
        {
           
        }

        [Then(@"Cambiar el lugar destino")]
        public void ThenCambiarElLugarDestino()
        {
            
        }

        [Then(@"En la seccion de pasajeros elegir (.*) adultos y (.*) niño")]
        public void ThenEnLaSeccionDePasajerosElegirAdultosYNino(int p0, int p1)
        {
            
        }


    }
}
