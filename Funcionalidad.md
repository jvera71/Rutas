
# 🛡️ Proyecto: Aplicación de Seguridad Urbana para Mujeres

## 1. Introducción y Propósito
La funcionalidad principal de esta aplicación es garantizar que las mujeres que caminen solas por la calle, especialmente de noche, se sientan más seguras. Mediante una interfaz basada en mapas (tipo Google Maps), la usuaria podrá indicar su punto de origen y destino a pie.

> **Distribución Restringida:** Esta aplicación no estará disponible para su descarga pública general. Será distribuida e instalada exclusivamente a través de entidades oficiales, como ayuntamientos y gobiernos locales, para garantizar la integridad de la red de usuarias.

---

## 2. Privacidad y Gestión de Datos
La privacidad y el anonimato son los pilares fundamentales de la arquitectura del sistema.

*   **Anonimato en la Red:** La aplicación no contendrá ningún dato personal de las usuarias. El sistema funcionará mediante un código único. El ayuntamiento será el único ente con capacidad para vincular dicho código a la identidad real de la persona; el servidor de la aplicación operará exclusivamente con códigos.
*   **Gestión Efímera de Trayectos:** Los datos del trayecto se eliminarán automáticamente en cuanto este finalice.
*   **Excepción por Denuncia:** Dado que existe la posibilidad de interactuar por chat con otras usuarias, si al finalizar un trayecto alguien reporta contenido inapropiado, los datos no se borrarán. Se enviarán al organismo oficial para su evaluación.
*   **Modo Camuflaje (Incógnito):** Para evitar que un agresor sepa que se está usando una app de seguridad, la interfaz principal puede adoptar la apariencia de otra aplicación (ej. reproductor de música, calculadora o noticias). Las funciones de emergencia se activarían mediante gestos ocultos (ej. deslizar dos dedos).

---

## 3. Funcionalidades durante el Trayecto (Prevención y Seguridad Pasiva)

### 🗺️ Rutas y Navegación
*   **Rutas "Seguras" vs. Rápidas:** En lugar de priorizar la ruta más corta, la app sugerirá una "Ruta Segura". Basándose en datos del ayuntamiento, priorizará calles bien iluminadas, zonas con cámaras de seguridad y vías principales.
*   **Aviso Automático de Llegada:** La gestión de contactos se realiza localmente en el teléfono. Al llegar al destino, el dispositivo enviará automáticamente un SMS (sin pasar por el servidor central) a los familiares configurados indicando: *"He llegado bien"*.

### 🤝 Comunidad y Acompañamiento
*   **Red de Apoyo Cercana:** Al iniciar un trayecto, la app avisa a usuarias cercanas por si desean acompañar a la usuaria, llamarla o enviarle un mensaje para que se sienta segura.
*   **Encuentros Físicos Voluntarios:** Si dos usuarias tienen un recorrido común, la app les preguntará a ambas si desean ser presentadas para caminar juntas. Si ambas aceptan, se las pondrá en contacto. Si alguna rechaza, la presentación se omite.
*   **Validación de Identidad (Anti-Suplantación):** Para asegurar que la persona que se acerca es la usuaria correcta y no un intruso, al acordar un encuentro, ambas pantallas mostrarán un color específico o una palabra clave aleatoria (ej. "Manzana") que servirá como santo y seña.

### ⚠️ Prevención Activa
*   **Alerta de Desviación (Modo Monitor):** Si el GPS detecta un desvío drástico, una detención inusual o un cambio brusco de velocidad, la app lanzará un aviso en pantalla: *"¿Estás bien?"*. Si no hay respuesta en 15 segundos, se activa la secuencia de Pánico.
*   **Modo "Llamada Falsa":** Botón discreto que simula una llamada entrante realista (con voz grabada y pausas) de un familiar. Funciona como elemento disuasorio ante la sospecha de ser seguida.
*   **Puntos Refugio (Safe Havens):** El mapa mostrará comercios locales adheridos (farmacias 24h, gasolineras, bares) donde el personal está formado por el ayuntamiento para ofrecer auxilio.

---

## 4. Sistema de Emergencias: El Botón del Pánico

La aplicación cuenta con un botón de gran tamaño diseñado para ser utilizado en situaciones de miedo, acoso o seguimiento.

### ⏳ Secuencia de Activación
Al pulsarlo, se inicia una cuenta atrás de **10 segundos de cortesía**. Esto permite cancelar la alerta en caso de pulsación accidental, evitando falsas alarmas. Si no se detiene, la alarma se emite automáticamente.

**Destinatarios de la Alarma:**
1. Usuarias que se encuentren cerca.
2. Organismos oficiales correspondientes.
3. Cuerpos de Policía.
4. Familiares de la usuaria.

### 🚨 Modos de Activación Avanzados
*   **Botón de "Hombre Muerto" (Alta Tensión):** Al atravesar una zona percibida como peligrosa, la usuaria puede caminar manteniendo el dedo presionado en la pantalla. Si suelta el dispositivo (por ejemplo, en un forcejeo), se solicita un PIN. Si no se introduce en 5 segundos, salta la alarma.
*   **Activación por Hardware:** Posibilidad de lanzar la alerta sin mirar la pantalla, ya sea pulsando repetidamente (ej. 5 veces) el botón físico de encendido o agitando violentamente el dispositivo desde el bolsillo.
*   **Grabación A\V Cifrada Automática:** Tras los 10 segundos de cortesía del botón del pánico, el micrófono y la cámara comenzarán a grabar. **Por privacidad:** Este archivo se cifra en el acto y se envía *exclusivamente* al servidor policial/oficial. Ni siquiera la propia usuaria podrá reproducirlo.

---

## 5. Participación Ciudadana y Urbanismo

*   **Mapas de Calor Anónimos:** Al finalizar un trayecto con éxito, la app preguntará por la percepción de seguridad. La usuaria podrá marcar puntos en el mapa reportando *"Poca iluminación"* o *"Presencia intimidatoria"*. Estos datos viajarán 100% anonimizados al ayuntamiento para optimizar el envío de patrullas o el mantenimiento del mobiliario urbano.

---

## 📊 Resumen del Flujo del Sistema y Privacidad

Para garantizar un ecosistema seguro y privado, las responsabilidades se dividen de la siguiente manera:

1. **Servidor del Ayuntamiento:** 
   * Solo visualiza **códigos de usuario**, coordenadas temporales, alertas de pánico y reportes de urbanismo totalmente anónimos.
2. **Dispositivo de la Usuaria (Local):** 
   * Guarda temporalmente la ruta, ejecuta las validaciones (como desvíos de mapa) y gestiona el envío de SMS a familiares. De este modo, el servidor central *nunca* tiene acceso a la agenda de contactos ni al nombre real de la mujer.


 