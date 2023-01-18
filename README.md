# Autores

**Hernández Abreu, Lucas**: alu0101317496

**Pérez González, Lorenzo Gabriel**: alu0101233499

# Contenido

1. Cuestiones importantes para el uso
2. Hitos de programación logrados relacionándolos con los contenidos que se han impartido
3. Aspectos que destacarías en la aplicación. Especificar si se han incluido sensores de los que se han trabajado en interfaces multimodales
4. GIF animado de ejecución
5. Acta de los acuerdos del grupo respecto al trabajo en equipo: reparto de tareas, tareas desarrolladas individualmente, tareas desarrolladas en grupo, etc.

# Cuestiones importantes para el uso
## Elementos necesarios
**PC:**
- Teclado y Ratón.

**ANDROID:**
- Google Cardboard
- Mando PS4 Dualshock 


## Controles
### PC
**Movimiento:** W-A-S-D 

**Rotación de cámara:** Ratón 

**Colocar marcador:** E 

**Reiniciar partida:** M 
### Android

**Movimiento:** PS4 Dualshock Joystick Izquierdo

**Rotación de cámara:** Girar la cabeza (Android)

**Colocar marcador:** X (PS4 Dualshock)

**Reiniciar partida:** O (PS4 Dualshock)

# Hitos relacionados con los contenidos de la asignatura

- Sistema con Eventos: Hemos implementado sistemas de cerrado de puertas que 
interacciona con el paso del jugador por ciertos triggers. También se ha 
implementado un sistema para reiniciar el juego en caso de necesidad. Por 
último, se ha creado un sistema de control de la música.
- Recolección de objetos mediante Triggers.
- Colisión con paredes.
- Controlador de personaje.
- Interfaz inmersiva.
- Interfaz adaptada cumpliendo los requisitos de RV.
- Uso de los sensores Android: se ha empleado el sistema de giroscopio 
del que hace uso Cardboard para capturar el movimiento de la cabeza. Se ha 
implementado un sistema para saber la geolocalización del usuario y darle una 
experiencia más inmersiva al decirle en qué país se encuentra (hemos obtado por
comunicarle al usuario que se ha abierto un portal en su país de origen y debe 
resolver el laberinto de cristales para volver a la Tierra).
- Inclusión de prefabs de la Asset Store de Unity.
## Hitos no relacionados con la asignatura

- Modelado en Blender: Hemos utilizado Blender para unir sectores del laberinto
y poder optimizar de forma fácil.
- Creación de LODs en Blender: Los cristales tienen diferentes niveles de 
detalle según la distancia a la cual estemos con respecto del cristal.
- Optimización de luces: las luces se han generado de forma estática para que 
no tengan que calcularse a tiempo real y nos permite tener mayores fps.
- Optimización del renderizado: El renderizado se realiza por partes según el 
jugador esté mirando a un punto u otro, de esta forma obtenemos mejoras 
considerables en los fps.
- Creación procedural de laberintos: Se ha creado un script para generar
laberintos de forma aleatoria (solo se ha usado al principio para obtener
un laberinto sobre el que trabajar).

# Aspectos a destacar 
- La inclusión del GPS para determinar el país en el que el usuario está 
ubicado.
- La inclusión del giroscopio para determinar los movimientos de cabeza del 
usuario.
- La inclusión de musica de producción propia para la inmersión dentro del 
laberinto.
- La utilización de rampas poco pronunciadas y velocidades constantes
para evitar el mareo del usuario.

# Acta de los acuerdos del grupo

**Mapa:**

- Implementación del laberinto: Lucas Hernández Abreu
- Implementación de los carteles y la brújula: Lorenzo Gabriel Pérez González
- Elementos decorativos y coleccionables: Lucas Hernández Abreu y Lorenzo Gabriel Pérez González

**Sistema:**

- Implementación del controlador de juego: Lorenzo Gabriel Pérez González
- Implementación del controlador de audio: Lucas Hernández Abreu
- Animaciones para el reinicio de nivel: Lorenzo Gabriel Pérez González

**Música:**

- Implementación de la música: Lucas Hernández Abreu 

*Composición Musical:*
- *The Labyrinth*: Jonás Hernández Abreu
- *Crystals*: Lucas Hernández Abreu
- *Exit The Labyrinth*: Violeta Carrillo García-Ramos

**Jugabilidad:**

- Implementación del jugador: Lorenzo Gabriel Pérez González

**Optimización:**

- Tareas de optimización: Lucas Hernández Abreu y Lorenzo Gabriel Pérez González



# GIF animado de ejecución
