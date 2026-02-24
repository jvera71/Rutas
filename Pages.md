# 📱 Mapa de Pantallas (Wireframes / Vistas de la App)

## 1. Acceso y Configuración Inicial (Onboarding)
*Dado que es una app institucional de acceso restringido, no hay pantalla de "Registro", solo de acceso y configuración.*

*   **1.1. Pantalla de Bienvenida (Splash Screen):** Logos del Ayuntamiento/Entidad oficial y de la aplicación.
*   **1.2. Pantalla de Acceso (Login):** Único campo para introducir el **Código de Usuaria** proporcionado por el ayuntamiento. Botón de "Entrar".
*   **1.3. Configuración de Contactos de Emergencia (Local):** Formulario para añadir teléfonos de "Familiares" a los que se avisará por SMS (guardados solo en el móvil).
*   **1.4. Configuración de PIN de Seguridad:** Creación de un PIN de 4-6 dígitos necesario para cancelar falsas alarmas.
*   **1.5. Tutorial Rápido:** Breve explicación de los gestos ocultos, activación por botón físico y el funcionamiento de la privacidad.

## 2. Planificación del Trayecto
*   **2.1. Pantalla Principal (Mapa de Inicio):** 
    *   Mapa tipo Google Maps centrado en la ubicación actual.
    *   Buscador para introducir el destino.
    *   Iconos visibles en el mapa indicando **Puntos Refugio** (farmacias, gasolineras, etc.).
    *   Botón de acceso rápido al "Botón del Pánico" siempre visible.
    *   Botón/Gesto para activar el **Modo Camuflaje**.
*   **2.2. Selector de Ruta:**
    *   Muestra dos opciones trazadas en el mapa con tiempo estimado: **"Ruta Segura"** (destacada) y **"Ruta Rápida"**.
    *   Botón grande: "Iniciar Trayecto".

## 3. Modo Trayecto Activo (Navegación)
*   **3.1. Pantalla de Navegación Activa:**
    *   Mapa en movimiento siguiendo el GPS.
    *   Indicaciones de hacia dónde girar.
    *   **Botones flotantes de prevención:** "Botón del Pánico", "Llamada Falsa" y "Hombre Muerto".
*   **3.2. Pantalla de Llamada Falsa (Simulador):** Interfaz idéntica a la llamada entrante nativa del sistema operativo (iOS/Android) con el nombre "Mamá" o similar. Al descolgar, muestra un temporizador de llamada activa.
*   **3.3. Pantalla "Botón de Hombre Muerto":** Pantalla simplificada con un gran botón central (ej. una huella dactilar) que dice *"Mantén pulsado. Si sueltas, se activará la alarma"*.
*   **3.4. Pop-up de Alerta de Desvío (Modo Monitor):** Pantalla superpuesta (overlay) que salta si hay una anomalía GPS. Mensaje: *"Hemos detectado un desvío. ¿Estás bien?"* con cuenta atrás de 15 segundos y botón para indicar "Sí, estoy bien" (pide PIN).

## 4. Comunidad y Encuentros
*   **4.1. Notificación / Lista de Usuarias Cercanas:** Pequeño panel desplegable que muestra si hay mujeres cerca y botones de acción: "Llamar", "Mensaje", "Pedir acompañamiento".
*   **4.2. Chat Privado y Seguro:** 
    *   Interfaz de mensajería básica (texto).
    *   **Botón crucial:** "Denunciar usuario/conversación" (para enviar el log al servidor oficial).
*   **4.3. Pop-up de Propuesta de Encuentro:** *"Hay una usuaria con tu misma ruta. ¿Deseas que os presentemos para ir juntas?"* (Botones: Sí / No).
*   **4.4. Pantalla de Validación (Santo y Seña):** Pantalla que aparece cuando dos usuarias aceptan encontrarse. Muestra un color sólido brillante en toda la pantalla o una palabra clave (ej. "MANZANA") en texto gigante para reconocerse físicamente.

## 5. Emergencia y Botón del Pánico
*   **5.1. Cuenta Atrás de Pánico:** Pantalla roja parpadeante con un número gigante del 10 al 0. Botón de "Cancelar Alarma" debajo (que obligará a meter el PIN).
*   **5.2. Pánico Activo (Modo Grabación):** 
    *   La alarma ya se ha enviado. 
    *   La pantalla puede ponerse **negra** o mostrar una interfaz falsa para engañar al agresor.
    *   Internamente indica que se está grabando audio/vídeo cifrado y compartiendo la ubicación en vivo con la Policía/Familiares.
*   **5.3. Pantalla de Desactivación de Pánico:** Teclado numérico para introducir el PIN que detiene la alarma, la grabación y avisa de que el peligro ha pasado.

## 6. Fin de Trayecto y Participación Ciudadana
*   **6.1. Pantalla de Llegada Exitosa:** Animación de éxito. Mensaje: *"Has llegado a tu destino. Avisando a tus familiares..."*. (Esta pantalla destruye la ruta activa temporal).
*   **6.2. Pantalla de Evaluación (Mapa de Calor):** 
    *   Pregunta: *"¿Qué tal tu ruta de hoy?"* (Caritas: Bien / Regular / Mal).
    *   Si elige Regular/Mal, pasa a un mapa donde puede dejar un **Pin de Reporte Anónimo** (Opciones: Poca luz, Grupo intimidante, Calle cortada, Zona solitaria). Botón: "Enviar reporte anónimo al Ayuntamiento".

## 7. Configuración y Ajustes (Menú Lateral o Perfil)
*   **7.1. Mi Perfil Institucional:** Muestra el código de usuaria asignado (único dato).
*   **7.2. Gestión de Familiares:** Para añadir, editar o borrar los números de teléfono para SMS automáticos.
*   **7.3. Configuración de Modo Camuflaje:** Selector para elegir cómo quiere que se camufle la app si activa el modo incógnito (Opciones: *Reproductor de Música, Calculadora, Feed de Noticias*).
*   **7.4. Ajustes de Hardware:** Activación/desactivación del pánico mediante pulsaciones del botón de encendido físico del móvil o por agitación del dispositivo.
*   **7.5. Pantalla de Camuflaje (Fake UI):** La interfaz falsa elegida (ej. una calculadora funcional) que esconde un gesto secreto (ej. mantener pulsado el símbolo "=") para volver a la app real o lanzar la alarma oculta.