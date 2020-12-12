Feature: PobedaFlightFlow
	- Prueba de navegacion a la URL de aerolinea pobeda
	- Prueba de Interacción con página de Búsqueda
	- Prueba de Interacción con la Selección de Vuelos



	Scenario: Acceso a url automatizada
		Given Navegar al sitio web de la aerolínea Pobeda
			And Esperar que cargue el sitio web
		Then La pagina carga correctamente