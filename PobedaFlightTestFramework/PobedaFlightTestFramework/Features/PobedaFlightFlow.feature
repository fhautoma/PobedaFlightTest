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
		Then Cambiar el lenguaje del sitio Web a "Aleman"
			And Cambiar el tipo de moneda del sitio Web a "Dolares"
			And Hacer click en el boton de busqueda
		Then Esperar que se muestre la pagina de seleccion de vuelos
			And Regresar a la pagina de busqueda
			And Esperar que cargue la pagina de busqueda
			And Cambiar el tipo de vuelo a Solo Ida
			And Seleccionar ciudad de origen con iata "AAQ"
			And Seleccionar ciudad de destino con iata "VKO"
			And Cambiar Fecha de Vuelo
			And En la seccion de pasajeros elegir 3 adulto(s), 0 adolecente(s), 1 niño(s) y 0 bebe(s)
			And Hacer click en el boton de busqueda
			And Esperar que se muestre la pagina de seleccion de vuelos
	
	Scenario: Interacción con la Selección de Vuelos
		Then Cambiar el tipo de moneda del sitio Web a "Euros"
			And Cambiar el tipo de vuelo a Solo Ida
			And Hacer click en el boton de busqueda
			And Esperar que se muestre la pagina de seleccion de vuelos
			And Validar disponibilidad de de vuelos y seleccionar tarifa

	Scenario: Interacción con la Selección de Vuelos Sin Resultados
		Then Cambiar el tipo de moneda del sitio Web a "Euros"
			And Cambiar el tipo de vuelo a Solo Ida
			And Seleccionar ciudad de origen con iata "VKO"
			And Seleccionar ciudad de destino con iata "GZP"
			And Hacer click en el boton de busqueda
			And Esperar que se muestre la pagina de seleccion de vuelos
			And Validar disponibilidad de de vuelos y seleccionar tarifa