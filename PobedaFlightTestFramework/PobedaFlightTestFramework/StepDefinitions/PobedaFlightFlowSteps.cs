using System;
using TechTalk.SpecFlow;

namespace PobedaFlightTestFramework.StepDefinitions
{
    [Binding]
    public class PobedaFlightFlowSteps
    {
        [Given(@"Navegar al sitio web de la aerolínea Pobeda")]
        public void GivenNavegarAlSitioWebDeLaAerolineaPobeda()
        {
            //ScenarioContext.Current.Pending();
        }
        
        [Given(@"Esperar que cargue la pagina de busqueda")]
        public void GivenEsperarQueCargueElSitioWeb()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"La pagina de busqueda carga correctamente")]
        public void ThenLaPaginaCargaCorrectamente()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Cambiar el lenguaje del sitio Web a ""(.*)""")]
        public void ThenCambiarElLenguajeDelSitioWebA(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Cambiar el tipo de moneda del sitio Web a ""(.*)""")]
        public void ThenCambiarElTipoDeMonedaDelSitioWebA(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Hacer click en el boton de busqueda")]
        public void ThenHacerClickEnElBotonDeBusqueda()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Esperar que se muestre la pagina de seleccion de vuelos")]
        public void ThenEsperarQueSeMuestreLaPaginaDeSeleccionDeVuelos()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Regresar a la pagina de busqueda")]
        public void ThenRegresarALaPaginaDeBusqueda()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Esperar que cargue la pagina de busqueda")]
        public void ThenEsperarQueCargueLaPaginaDeBusqueda()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Cambiar el tipo de vuelo a Solo Ida")]
        public void ThenCambiarElTipoDeVueloASoloIda()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Cambiar el lugar origen")]
        public void ThenCambiarElLugarOrigen()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Cambiar el lugar destino")]
        public void ThenCambiarElLugarDestino()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"En la seccion de pasajeros elegir (.*) adultos y (.*) niño")]
        public void ThenEnLaSeccionDePasajerosElegirAdultosYNino(int p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }


    }
}
