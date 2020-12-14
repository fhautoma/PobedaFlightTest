using System;
using TechTalk.SpecFlow;
using PobedaFlightTestFramework.PageObjects;
using System.Threading;

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
            flightSearchPage.ChangeCurrencyOption(flightResultPage, currency);
        }

        [Then(@"Hacer click en el boton de busqueda")]
        public void ThenHacerClickEnElBotonDeBusqueda()
        {
            flightSearchPage.ClickSearchButton();
            flightResultPage.BookingCurrencyChangeisPresent();
        }

        [Then(@"Esperar que se muestre la pagina de seleccion de vuelos")]
        public void ThenEsperarQueSeMuestreLaPaginaDeSeleccionDeVuelos()
        {
            
            flightResultPage.WaitUntilResulPagetLoad();
        }

        [Then(@"Regresar a la pagina de busqueda")]
        public void ThenRegresarALaPaginaDeBusqueda()
        {
            flightResultPage.ReturnToSearchPage();
        }

        [Then(@"Esperar que cargue la pagina de busqueda")]
        public void ThenEsperarQueCargueLaPaginaDeBusqueda()
        {
            flightSearchPage.WaitUntilSearchPageLoad();
        }

        [Then(@"Cambiar el tipo de vuelo a Solo Ida")]
        public void ThenCambiarElTipoDeVueloASoloIda()
        {
            flightSearchPage.SelectOneWayTripOption();
        }

        [Then(@"Seleccionar ciudad de origen con iata ""(.*)""")]
        public void ThenSeleccionarCiudadDeOrigenConIata(string iataCode)
        {
            flightSearchPage.FillDepartingCity(iataCode);
        }

        [Then(@"Seleccionar ciudad de destino con iata ""(.*)""")]
        public void ThenSeleccionarCiudadDeDestinoConIata(string iataCode)
        {
            flightSearchPage.FillArrivalCity(iataCode);
        }

        [Then(@"Cambiar Fecha de Vuelo")]
        public void ThenCambiarFechaDeVuelo()
        {
            flightSearchPage.ChangeTripDate();
        }

        [Then(@"En la seccion de pasajeros elegir (.*) adulto\(s\), (.*) adolecente\(s\), (.*) niño\(s\) y (.*) bebe\(s\)")]
        public void ThenEnLaSeccionDePasajerosElegirAdultoSAdolecenteSNinoSYBebeS(int adults, int teens, int childs, int babys)
        {
            flightSearchPage.AddPassengers(adults, teens, childs, babys);
        }

        [Then(@"Validar disponibilidad de de vuelos y seleccionar tarifa")]
        public void ThenValidarDias()
        {
            flightResultPage.ValidateTripAvailabilityAndSelectFre();
            Thread.Sleep(5000);
        }



    }
}
