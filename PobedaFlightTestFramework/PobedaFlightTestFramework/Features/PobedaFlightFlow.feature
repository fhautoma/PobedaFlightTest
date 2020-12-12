Feature: PobedaFlightFlow
	- Prueba de navegacion a la URL de aerolinea pobeda
	- Prueba de Interacción con página de Búsqueda
	- Prueba de Interacción con la Selección de Vuelos

	Background: 
			Given Navegar al sitio web de la aerolínea Pobeda
			And Esperar que cargue la pagina de busqueda

	Scenario: Acceso a url automatizada

		Then La pagina de busqueda carga correctamente


	Scenario: Interacción con página de Búsqueda
		Then Cambiar el lenguaje del sitio Web a "DE"
			And Cambiar el tipo de moneda del sitio Web a "EUR"
			And Hacer click en el boton de busqueda
		Then Esperar que se muestre la pagina de seleccion de vuelos
			And Regresar a la pagina de busqueda
			And Esperar que cargue la pagina de busqueda
			And Cambiar el tipo de vuelo a Solo Ida
			And Cambiar el lugar origen
			And Cambiar el lugar destino
			And En la seccion de pasajeros elegir 3 adultos y 1 niño
			And Hacer click en el boton de busqueda
			And Esperar que se muestre la pagina de seleccion de vuelos
		
