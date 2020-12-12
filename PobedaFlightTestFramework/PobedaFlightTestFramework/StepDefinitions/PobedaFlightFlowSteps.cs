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
        
        [Given(@"Esperar que cargue el sitio web")]
        public void GivenEsperarQueCargueElSitioWeb()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"La pagina carga correctamente")]
        public void ThenLaPaginaCargaCorrectamente()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
